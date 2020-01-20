CREATE SCHEMA 'universitydb';

CREATE TABLE `universitydb`.`students222` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `FirstName` VARCHAR(45) CHARACTER SET 'utf8' NOT NULL ,
  `LastName` VARCHAR(45) CHARACTER SET 'utf8' NOT NULL,
  `MiddleName` VARCHAR(45) CHARACTER SET 'utf8' NOT NULL,
  `Group_ID` INT NOT NULL,
  `Sex` VARCHAR(45) NOT NULL,
  `Birth_Date` DATE NULL,
  PRIMARY KEY (`ID`));
  
  CREATE TABLE `universitydb`.`groups` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `Group_Name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`ID`));

CREATE TABLE `universitydb`.`subjects` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `Subject_Name` VARCHAR(45) CHARACTER SET 'utf8' NOT NULL,
  PRIMARY KEY (`ID`));

/* Добавление внешнего ключа в таблицу Students */
ALTER TABLE `universitydb`.`students` ADD INDEX `fk_students_groups_idx` (`Group ID` ASC);
ALTER TABLE `universitydb`.`students` 
ADD CONSTRAINT `fk_students_groups`
  FOREIGN KEY (`Group ID`)
  REFERENCES `universitydb`.`groups` (`ID`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;
  
  CREATE TABLE `universitydb`.`session_schedule` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `Group_ID` INT NOT NULL,
  `Subject_ID` INT NOT NULL,
  `Type` VARCHAR(30) CHARACTER SET 'utf8' NOT NULL,
  `Date` DATETIME NOT NULL,
  PRIMARY KEY (`ID`),
  INDEX `fk_ses_sched_groups_idx` (`Group_ID` ASC),
  INDEX `fk_ses_sched_subjects_idx` (`Subject_ID` ASC),
  CONSTRAINT `fk_ses_sched_groups`
    FOREIGN KEY (`Group_ID`)
    REFERENCES `universitydb`.`groups` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ses_sched_subjects`
    FOREIGN KEY (`Subject_ID`)
    REFERENCES `universitydb`.`subjects` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
    
    CREATE TABLE `universitydb`.`session_results` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `Student_ID` INT NOT NULL,
  `Exam_ID` INT NOT NULL,
  `Grade` TINYINT(1) NOT NULL,
  PRIMARY KEY (`ID`),
  INDEX `fk_results_students_idx` (`Student_ID` ASC),
  INDEX `fk_results_ses_schedule_idx` (`Exam_ID` ASC),
  CONSTRAINT `fk_results_students`
    FOREIGN KEY (`Student_ID`)
    REFERENCES `universitydb`.`students` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_results_ses_schedule`
    FOREIGN KEY (`Exam_ID`)
    REFERENCES `universitydb`.`session_schedule` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

/* Триггер */
DROP TRIGGER IF EXISTS `universitydb`.`trigger_same_row`;
DELIMITER $$
USE `universitydb`$$
CREATE DEFINER=`root`@`localhost` TRIGGER trigger_same_row
BEFORE INSERT ON `session_results` FOR EACH ROW
BEGIN
	DECLARE amount INT;
	SET @amount = 0;
    SET @amount = (SELECT COUNT(Exam_ID) FROM session_results WHERE Student_ID = NEW.Student_ID 
								AND Exam_ID = NEW.Exam_ID );
	IF (@amount > 0) THEN
		SIGNAL SQLSTATE '02000' SET MESSAGE_TEXT = 'This student already has a grade in this subject.';
    END IF;
END$$
DELIMITER ;
    