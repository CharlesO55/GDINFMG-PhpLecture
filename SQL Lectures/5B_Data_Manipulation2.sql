# DATA MANIPULATION
SET SQL_SAFE_UPDATES = 0;

USE db_steam;

# RENAME TABLE '[dataset]mobile games' TO games`[dataset] mobile games`

-- ALTER TABLE tb_games
-- 	ADD my_tags TEXT AFTER steamspy_tags;

-- ALTER TABLE tb_games
-- 	DROP my_tags;

-- ALTER TABLE tb_games
-- 	RENAME COLUMN my_tags TO `main tag`;

-- UPDATE tb_games G
-- 	SET `main tag` = SUBSTRING_INDEX(G.steamspy_tags, ';', 1);
    
-- ALTER TABLE tb_games
-- 	MODIFY COLUMN `main tag` TEXT;

ALTER TABLE tb_games
	CHANGE COLUMN `main tag` `main tag` TEXT
    AFTER genres;

/*
CREATE VIEW `games view` AS
SELECT *, CONCAT(developer, ';', publisher) AS `Developer + Publisher`, SUBSTRING(release_date, 7, 4) AS Year
	FROM tb_games;

SELECT * FROM `games view`;*/

CREATE TABLE `test_table` AS
SELECT *, CONCAT(developer, ';', publisher) AS `Developer + Publisher`, SUBSTRING(release_date, 7, 4) AS Year
	FROM tb_games;

ALTER TABLE `test_table`
	CHANGE COLUMN Year Year TEXT
    AFTER genres;
    
SELECT * FROM `test_table`;