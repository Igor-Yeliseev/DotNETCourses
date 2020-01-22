# Добавление групп
INSERT INTO `universitydb`.`groups` (`Name`) VALUES ('ИТИ-31');
INSERT INTO `universitydb`.`groups` (`Name`) VALUES ('ИТП-31');
INSERT INTO `universitydb`.`groups` (`Name`) VALUES ('ИП-31');
INSERT INTO `universitydb`.`groups` (`Name`) VALUES ('ИП-32');
INSERT INTO `universitydb`.`groups` (`Name`) VALUES ('ЭТ-31');
INSERT INTO `universitydb`.`groups` (`Name`) VALUES ('ПС-31');
INSERT INTO `universitydb`.`groups` (`Name`) VALUES ('ПР-32');

# Добавление студентов
INSERT INTO `universitydb`.`students` (`LastName`, `FirstName`, `MiddleName`, `GroupID`, `Sex`, `BirthDate`) VALUES ('Карась', 'Ольга', 'Витальевна', '1', 'жен', '1997-05-09');
UPDATE `universitydb`.`students` SET `Birth Date` = '1995-11-05' WHERE (`ID` = '2');
UPDATE `universitydb`.`students` SET `Birth Date` = '1999-04-20' WHERE (`ID` = '1');
INSERT INTO `universitydb`.`students` (`LastName`, `FirstName`, `MiddleName`, `GroupID`, `Sex`, `BirthDate`) VALUES ('Иванов', 'Дмитрий', 'Петрович', '3', 'муж', '1996-07-14');
INSERT INTO `universitydb`.`students` (`LastName`, `FirstName`, `MiddleName`, `GroupID`, `Sex`, `BirthDate`) VALUES ('Стельченко', 'Александр', 'Владимирович', '1', 'муж', '1999-11-13');
INSERT INTO `universitydb`.`students` (`LastName`, `FirstName`, `MiddleName`, `GroupID`, `Sex`, `BirthDate`) VALUES ('Васильев', 'Федор', 'Степанович', '2', 'муж', '1997-10-10');
INSERT INTO `universitydb`.`students` (`LastName`, `FirstName`, `MiddleName`, `GroupID`, `Sex`, `BirthDate`) VALUES ('Гумар', 'Диана', 'Александровна', '3', 'жен', '1998-08-16');
INSERT INTO `universitydb`.`students` (`LastName`, `FirstName`, `MiddleName`, `GroupID`, `Sex`, `BirthDate`) VALUES ('Бартновская', 'Анастасия', 'Сергеевна', '2', 'жен', '2000-1-24');
INSERT INTO `universitydb`.`students` (`LastName`, `FirstName`, `MiddleName`, `GroupID`, `Sex`, `BirthDate`) VALUES ('Малиновский', 'Иван', 'Леонидович', '1', 'муж', '1998-07-07');
INSERT INTO `universitydb`.`students` (`LastName`, `FirstName`, `MiddleName`, `GroupID`, `Sex`, `BirthDate`) VALUES ('Вакулина', 'Ангелина', 'Витальевна', '2', 'жен', '1999-03-08');
INSERT INTO `universitydb`.`students` (`LastName`, `FirstName`, `MiddleName`, `GroupID`, `Sex`, `BirthDate`) VALUES ('Виноградова', 'Валерия', 'Ивановна', '3', 'жен', '1998-11-19');

# Добавление предметов
INSERT INTO `universitydb`.`subjects` (`Name`) VALUES ('Математика');
INSERT INTO `universitydb`.`subjects` (`Name`) VALUES ('Физика');
INSERT INTO `universitydb`.`subjects` (`Name`) VALUES ('История');
INSERT INTO `universitydb`.`subjects` (`Name`) VALUES ('Экономика');
INSERT INTO `universitydb`.`subjects` (`Name`) VALUES ('Программирование');
INSERT INTO `universitydb`.`subjects` (`Name`) VALUES ('Физическая культура');
INSERT INTO `universitydb`.`subjects` (`Name`) VALUES ('Английский язык');
INSERT INTO `universitydb`.`subjects` (`Name`) VALUES ('Философия');
INSERT INTO `universitydb`.`subjects` (`Name`) VALUES ('Начертательная геометрия');
INSERT INTO `universitydb`.`subjects` (`Name`) VALUES ('Теоретическая механика');
INSERT INTO `universitydb`.`subjects` (`Name`) VALUES ('Компьютерные сети');

# Добавление расписания сессии
INSERT INTO `universitydb`.`session_schedule` (`GroupID`, `SubjectID`, `Type`) VALUES ('1', '1', 'экз');
INSERT INTO `universitydb`.`session_schedule` (`GroupID`, `SubjectID`, `Type`) VALUES ('1', '2', 'экз');
INSERT INTO `universitydb`.`session_schedule` (`GroupID`, `SubjectID`, `Type`) VALUES ('1', '3', 'экз');
INSERT INTO `universitydb`.`session_schedule` (`GroupID`, `SubjectID`, `Type`) VALUES ('1', '7', 'экз');
INSERT INTO `universitydb`.`session_schedule` (`GroupID`, `SubjectID`, `Type`) VALUES ('1', '5', 'экз');

# Добавление результатов сессии
INSERT INTO `universitydb`.`session_results` (`StudentID`, `ExamID`, `Grade`) VALUES ('2', '1', '8');
INSERT INTO `universitydb`.`session_results` (`StudentID`, `ExamID`, `Grade`) VALUES ('2', '2', '7');
INSERT INTO `universitydb`.`session_results` (`StudentID`, `ExamID`, `Grade`) VALUES ('3', '1', '6');
INSERT INTO `universitydb`.`session_results` (`StudentID`, `ExamID`, `Grade`) VALUES ('3', '2', '7');
INSERT INTO `universitydb`.`session_results` (`StudentID`, `ExamID`, `Grade`) VALUES ('2', '3', '8');









