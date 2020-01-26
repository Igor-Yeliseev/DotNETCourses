TYPE=TRIGGERS
triggers='CREATE DEFINER=`root`@`localhost` TRIGGER trigger_same_row\nBEFORE INSERT ON `sessionresults` FOR EACH ROW\nBEGIN\n	DECLARE amount INT;\n	SET @amount = 0;\n    SET @amount = (SELECT COUNT(ExamID) FROM sessionresults WHERE StudentID = NEW.StudentID \n								AND ExamID = NEW.ExamID );\n	IF (@amount > 0) THEN\n		SIGNAL SQLSTATE \'02000\' SET MESSAGE_TEXT = \'This student already has a grade in this subject.\';\n    END IF;\nEND'
sql_modes=1073741824
definers='root@localhost'
client_cs_names='utf8mb4'
connection_cl_names='utf8mb4_general_ci'
db_cl_names='latin1_swedish_ci'
