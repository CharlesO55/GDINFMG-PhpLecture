USE mobile_games;

-- 1. Rename the table
-- RENAME TABLE  `[dataset] mobile games` TO `mobile games (raw)`;
-- SELECT * FROM `mobile games (raw)`;

-- 2. New table
-- “Initial Release Date” which is the DATETIME version of Year, Month, and Day.
-- “Revenue Exponent” which is the INT value of the exponent from Revenue.

DROP TABLE IF EXISTS `mobile games`;
CREATE TABLE `mobile games` AS
	SELECT *,
    CONCAT(Year, '/', Month, '/', Day) AS `Initial Release Date`,
    SUBSTRING_INDEX(Revenue, '+', -1) AS `Revenue Exponent`,
    SUBSTRING(Revenue, 1, 4) AS `Rev Value`
		FROM `mobile games (raw)`;
    
ALTER TABLE `mobile games`
	CHANGE COLUMN `Initial Release Date` `Initial Release Date` DATETIME;

ALTER TABLE `mobile games`
	CHANGE COLUMN `Revenue Exponent` `Revenue Exponent` int;

ALTER TABLE `mobile games`
	CHANGE COLUMN `Rev Value` `Rev Value` decimal;


-- 3. The SQL statement to MOVE “Initial Release Date” before Year
ALTER TABLE `mobile games`
	CHANGE COLUMN `Initial Release Date` `Initial Release Date` DATETIME
    AFTER Revenue;

-- 4. The SQL statement to MOVE “Revenue Exponent” before “Initial Release Date”
ALTER TABLE `mobile games`
	CHANGE COLUMN `Revenue Exponent` `Revenue Exponent` int
    AFTER Revenue;
    
SELECT * FROM `mobile games`;

-- 5. The SQL statement to display the Game and Revenue of the TOP 10 games, ordered
-- by Game and Revenue. Do NOT create a new Table – use Views instead.

-- SELECT `Rev Value` * POWER(10, `Revenue Exponent`) AS `TOTAL` FROM `mobile games`;

DROP VIEW IF EXISTS `top games`;
CREATE VIEW `top games` AS
	SELECT Game, Revenue, `Rev Value` * POWER(10, `Revenue Exponent`) AS `TOTAL`
    FROM `mobile games` ORDER BY `TOTAL` DESC, `Game` ASC LIMIT 9;

SELECT * FROM `top games`;