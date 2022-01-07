CREATE DATABASE RESTFULAPI;

USE RESTFULAPI;

CREATE TABLE Movies(
	MovieID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Title varchar(200),
    Genre varchar(50),
	ReleaseDate INT
);

INSERT INTO Movies VALUES(0, 'Harry Potter Goes to White Castle', 'Romance', 2022),
(0, 'Harry Potter and The Fellowship Of The Ring', 'Thriller', 2009),
(0, 'Monty Python and the Half-Blood Prince', 'Horror', 2005),
(0, 'Shrek Steals Christmas', 'Thriller', 2005),
(0, 'McGuyver', 'Romance', 1997);

