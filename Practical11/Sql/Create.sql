CREATE SCHEMA IF NOT EXISTS db_dotnet_practicals;
USE db_dotnet_practicals;

CREATE TABLE IF NOT EXISTS students(
	roll INT PRIMARY KEY,
	branch INT NOT NULL,
	name TEXT NOT NULL,
	bday TIMESTAMP NOT NULL
);
