DROP DATABASE IF EXISTS db_dotnet_practicals;

-- `CREATE`...:
CREATE DATABASE db_dotnet_practicals;
USE db_dotnet_practicals;

CREATE TABLE students(
	roll INT PRIMARY KEY,
	name TEXT NOT NULL,
	bday TIMESTAMP NOT NULL,
	branch INT NOT NULL
);

-- `4` is EE, `5` is CSE!:
INSERT INTO students (roll, name, bday, branch) VALUES
	(1, "Aditya", "1999-04-05", 4),
	(2, "Brahvim", "2006-06-02", 4),
	(3, "Vishwambhar", "2002-03-01", 5)
;

-- ...`READ`!:
SELECT * FROM students WHERE branch = 4;

-- `UPDATE`...:
UPDATE students SET branch = 5 WHERE roll = 2;

-- ...`DELETE`!:
DELETE FROM students WHERE roll = 3;
