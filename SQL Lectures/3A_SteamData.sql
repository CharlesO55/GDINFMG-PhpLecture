-- RESTART;
-- SET GLOBAL local_infile = ON;

-- CREATE DATABASE lecture3a_steamdata;
USE lecture3a_steamdata;

/*
-- LIKE WHY? IS NOT EVEN SAVED...
DROP SCHEMA IF EXISTS db_Steam;
CREATE SCHEMA db_Steam;
USE db_Steam;
*/

SET NAMES utf8mb4;
SET CHARACTER SET utf8mb4;

-- IMPORTING THE TABLE DATA
/*
DROP TABLE IF EXISTS tb_Games;
CREATE TABLE tb_Games(
	id	INT,
    appid	INT,
    name	TEXT,
    release_date	VARCHAR(20),
    developer		TEXT,
    publisher		TEXT,
    platforms		TEXT,
    required_age	INT,
    categories		TEXT,
    genres			TEXT,
    steamspy_tags	TEXT,
    achievements	INT,
    positive_ratings	INT,
    negative_ratings	INT,
    average_playtime	INT,
    median_playtime		INT, 
    owners			TEXT,
    price 			DECIMAL(6, 2)
);


LOAD DATA INFILE 'lecture3a_steamdata/tables/game.csv'
INTO TABLE tb_Games
COLUMNS TERMINATED BY ','
OPTIONALLY ENCLOSED BY '"'
LINES TERMINATED BY '\n'
IGNORE 1 LINES;*/

-- ALL game developed by Gearbox Software, arranged in alphabetical order
/*
SELECT name, developer FROM tb_Games
	WHERE developer = "Gearbox Software"
    ORDER BY name ASC;
    */
    
-- The TOP 10 highest rated games among both Valve and Ubisoft publishers
/*
SELECT name, positive_ratings, publisher FROM tb_Games
	WHERE publisher = "Valve" OR publisher = "Ubisoft"
    ORDER BY positive_ratings DESC
    LIMIT 10;
*/

-- A query to print ALL game names and their corresponding short_descriptions.
SELECT name, short_description FROM tb_games
INNER JOIN tb_description
ON tb_description.steam_appid = tb_games.appid;


-- The TOP 5 highest rated Action games for the Mac platform.
/*SELECT name, positive_ratings, genres, platforms FROM tb_Games
	WHERE platforms LIKE "%mac%" AND genres LIKE "%Action%"
	ORDER BY positive_ratings DESC
    LIMIT 5;
*/