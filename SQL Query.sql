CREATE DATABASE SmartHomeDB;

CREATE TABLE Relays(
id INT NOT NULL AUTO_INCREMENT,
relayStatus1 VARCHAR(10),
relayStatus2 VARCHAR(10),
relayStatus3 VARCHAR(10),
PRIMARY KEY(id)
);

CREATE TABLE TempAndHumids(
id INT NOT NULL AUTO_INCREMENT,
tempValue FLOAT NOT NULL,
humidValue FLOAT NOT NULL,
PRIMARY KEY(id)
);

USE SmartHomeDB;

SELECT * FROM TempAndHumids;
SELECT * FROM Relays;

