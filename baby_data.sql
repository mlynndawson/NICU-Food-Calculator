
-- Switch to the system (aka master) database
USE master;
GO

-- Delete the TEgram Database (IF EXISTS)
IF EXISTS(select * from sys.databases where name='BabyData')
DROP DATABASE BabyData;
GO

-- Create a new TEgram Database
CREATE DATABASE BabyData;
GO

-- Switch to the TEgram Database
USE BabyData
GO

-- Begin a TRANSACTION that must complete with no errors
BEGIN TRANSACTION;

CREATE TABLE Baby
(
	id				int				identity,
	firstname		nvarchar(30)	not null,
	lastname		nvarchar(30)	not null,
	birthweight		decimal			not null,
	birthdate		date			not null,
	todayweight		decimal			not null,
	todaydate		DATETIME DEFAULT GETDATE(),
	foodMouth		decimal			null,
	foodMouthCal	decimal			null,
	foodTube		decimal			null,
	foodTubeCal		decimal			null,
	foodIV			decimal			null,
	foodIVCal		decimal			null

);

INSERT INTO Baby VALUES ('Bob', 'Smith', 2.5,'2019-03-01', 2.45, GetDate(), 300, 20, 20, 20, 0,0);
INSERT INTO Baby VALUES ('Anna', 'Smith', 1.75,'2019-02-28', 1.90, GetDate(), 250,20,45,20,0,0);


COMMIT TRANSACTION;