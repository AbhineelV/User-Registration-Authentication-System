CREATE TABLE registrationDB(
registrationID int IDENTITY(1,1) PRIMARY KEY,
name varchar(50),
mobile varchar(50),
email varchar(100) UNIQUE,
password varchar(50)
);

SELECT * FROM registrationDB;