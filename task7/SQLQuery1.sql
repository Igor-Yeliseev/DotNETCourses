USE [master]
GO
CREATE DATABASE UniversityDB
GO
USE UniversityDB;
GO

CREATE TABLE Examinators
(ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL, Name VARCHAR(50) NOT NULL);

CREATE TABLE Specialties
(ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL, Name VARCHAR(45) NOT NULL);

CREATE TABLE Groups(
ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Name VARCHAR(20) NOT NULL,
SpecID INT NOT NULL,
CONSTRAINT fk_groups_specialties FOREIGN KEY(SpecID)
REFERENCES Specialties(ID) ON DELETE NO ACTION ON UPDATE NO ACTION);

CREATE TABLE Subjects
(ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL, Name VARCHAR(45) NOT NULL);

CREATE TABLE Students (
ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
LastName VARCHAR(45) NOT NULL,
FirstName VARCHAR(45) NOT NULL ,
MiddleName VARCHAR(45) NOT NULL,
GroupID INT NOT NULL,
Sex VARCHAR(45) NOT NULL,
BirthDate DATE NULL,
CONSTRAINT fk_students_groups FOREIGN KEY(GroupID)
REFERENCES Groups(ID) ON DELETE NO ACTION ON UPDATE NO ACTION);

CREATE TABLE Sessionexams (
ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
GroupID INT NOT NULL,
SubjectID INT NOT NULL,
Type VARCHAR(30) NOT NULL,
SessionNumber INT NOT NULL,
Date DATETIME NOT NULL,
ExaminatorID INT NOT NULL,
CONSTRAINT fk_exams_groups FOREIGN KEY(GroupID)
REFERENCES Groups(ID) ON DELETE NO ACTION ON UPDATE NO ACTION,
CONSTRAINT fk_exams_subjects FOREIGN KEY(SubjectID)
REFERENCES Subjects(ID) ON DELETE NO ACTION ON UPDATE NO ACTION,
CONSTRAINT fk_exams_examinators FOREIGN KEY(ExaminatorID)
REFERENCES Examinators(ID) ON DELETE NO ACTION ON UPDATE NO ACTION);

CREATE TABLE Sessionresults (
ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
StudentID INT NOT NULL,
ExamID INT NOT NULL,
Grade TINYINT NOT NULL,
CONSTRAINT fk_results_students FOREIGN KEY(StudentID)
REFERENCES Students(ID) ON DELETE NO ACTION ON UPDATE NO ACTION,
CONSTRAINT fk_results_exams FOREIGN KEY(ExamID)
REFERENCES Sessionexams(ID) ON DELETE NO ACTION ON UPDATE NO ACTION);


INSERT INTO Examinators (Name) VALUES ('Курочка Константин Сергеевич');
INSERT INTO Examinators (Name) VALUES ('Комракова Евгения Владимировна');
INSERT INTO Examinators (Name) VALUES ('Кравченко Ольга Алексеевна');
INSERT INTO Examinators (Name) VALUES ('Стефановский Игорь Леонидович');
INSERT INTO Examinators (Name) VALUES ('Авакян Елена Зиновьевна');
INSERT INTO Examinators (Name) VALUES ('Кравченко Петр Петрович');

INSERT INTO Specialties (Name) VALUES ('Инженер системный программист');
INSERT INTO Specialties (Name) VALUES ('Инженер конструктор');
INSERT INTO Specialties (Name) VALUES ('Инженер строитель');
INSERT INTO Specialties (Name) VALUES ('Инженер электрик');
INSERT INTO Specialties (Name) VALUES ('Горный инженер');

USE UniversityDB;
GO

CREATE TRIGGER trigger_same_row ON Sessionresults
INSTEAD OF INSERT
AS
BEGIN
	DECLARE @amount INT,
			@new_student_id INT,
			@new_exam_id INT;
	SET @amount = 0;
	SELECT @new_student_id = i.StudentID, @new_exam_id = i.ExamID FROM inserted i;
    SET @amount = (SELECT COUNT(s.ExamID) FROM Sessionresults s WHERE s.StudentID = @new_student_id
								AND s.ExamID = @new_exam_id );
	IF (@amount > 0)
	BEGIN
		RAISERROR('This student already has a grade in this subject.', 16, 1);
		ROLLBACK;
	END
END;
