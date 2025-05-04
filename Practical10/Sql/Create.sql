DROP SCHEMA IF EXISTS db_dotnet_practicals;

CREATE SCHEMA db_dotnet_practicals;
USE db_dotnet_practicals;

CREATE TABLE students(
	roll INT PRIMARY KEY,
	branch INT NOT NULL,
	name TEXT NOT NULL,
	bday TIMESTAMP NOT NULL
);

-- `4` is EE, `5` is CSE!:
INSERT INTO students (roll, name, bday, branch) VALUES
	(1, "Aditya", "1999-04-05", 4),
	(2, "Brahvim", "2006-06-02", 4),
	(3, "Vishwambhar", "2002-03-01", 5)
;

SELECT * FROM students;
