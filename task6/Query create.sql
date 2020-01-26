#CREATE SCHEMA 'universitydb';

  CREATE TABLE `universitydb`.`groups` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) CHARACTER SET 'utf8' NOT NULL,
  PRIMARY KEY (`ID`));

CREATE TABLE `universitydb`.`subjects` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) CHARACTER SET 'utf8' NOT NULL,
  PRIMARY KEY (`ID`));

CREATE TABLE `universitydb`.`students` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `LastName` VARCHAR(45) CHARACTER SET 'utf8' NOT NULL,
  `FirstName` VARCHAR(45) CHARACTER SET 'utf8' NOT NULL ,
  `MiddleName` VARCHAR(45) CHARACTER SET 'utf8' NOT NULL,
  `GroupID` INT NOT NULL,
  `Sex` VARCHAR(45) CHARACTER SET 'utf8' NOT NULL,
  `BirthDate` DATE NULL,
  PRIMARY KEY (`ID`));


/* Добавление внешнего ключа в таблицу Students */
ALTER TABLE `universitydb`.`students` ADD INDEX `fk_students_groups_idx` (`GroupID` ASC);
ALTER TABLE `universitydb`.`students` 
ADD CONSTRAINT `fk_students_groups`
  FOREIGN KEY (`GroupID`)
  REFERENCES `universitydb`.`groups` (`ID`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;
  
  CREATE TABLE `universitydb`.`sessionexams` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `GroupID` INT NOT NULL,
  `SubjectID` INT NOT NULL,
  `Type` VARCHAR(30) CHARACTER SET 'utf8' NOT NULL,
  `SessionNumber` INT NOT NULL,
  `Date` DATETIME NOT NULL,
  PRIMARY KEY (`ID`),
  INDEX `fk_exams_groups_idx` (`GroupID` ASC),
  INDEX `fk_exams_subjects_idx` (`SubjectID` ASC),
  CONSTRAINT `fk_exams_groups`
    FOREIGN KEY (`GroupID`)
    REFERENCES `universitydb`.`groups` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_exams_subjects`
    FOREIGN KEY (`SubjectID`)
    REFERENCES `universitydb`.`subjects` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
    CREATE TABLE `universitydb`.`sessionresults` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `StudentID` INT NOT NULL,
  `ExamID` INT NOT NULL,
  `Grade` TINYINT NOT NULL,
  PRIMARY KEY (`ID`),
  INDEX `fk_results_students_idx` (`StudentID` ASC),
  INDEX `fk_results_exams_idx` (`ExamID` ASC),
  CONSTRAINT `fk_results_students`
    FOREIGN KEY (`StudentID`)
    REFERENCES `universitydb`.`students` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_results_exams`
    FOREIGN KEY (`ExamID`)
    REFERENCES `universitydb`.`sessionexams` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

/* Триггер */
DELIMITER $$
USE `universitydb`$$
CREATE DEFINER=`root`@`localhost` TRIGGER trigger_same_row
BEFORE INSERT ON `sessionresults` FOR EACH ROW
BEGIN
	DECLARE amount INT;
	SET @amount = 0;
    SET @amount = (SELECT COUNT(ExamID) FROM sessionresults WHERE StudentID = NEW.StudentID 
								AND ExamID = NEW.ExamID );
	IF (@amount > 0) THEN
		SIGNAL SQLSTATE '02000' SET MESSAGE_TEXT = 'This student already has a grade in this subject.';
    END IF;
END$$
DELIMITER ;
    