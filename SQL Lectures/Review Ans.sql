/**************
*   SLIDE 4   *
***************/
#1 ALL games developed by Gearbox Software, arranged in alphabetical order.
# SELECT name, developer FROM tb_steam_games WHERE developer LIKE '%Gearbox Software%' ORDER BY name

#2 The TOP 10 highest rated games among both Valve and Ubisoft publishers.
# SELECT name, positive_ratings, publisher FROM tb_steam_games WHERE publisher LIKE 'Valve' OR publisher LIKE 'Ubisoft' ORDER BY positive_ratings DESC LIMIT 10

#3 A query to print ALL game names and their corresponding short_descriptions.
#SELECT name, short_descriptions FROM tb_steam_games LEFT JOIN tb_descriptions ON tb_steam_games.appid = tb_descriptions.steam_appid

#4 The TOP 5 highest rated Action games for the Mac platform.
#SELECT name, genres, platforms, positive_ratings FROM tb_steam_games WHERE genres LIKE '%Action%' AND platforms LIKE '%Mac%' ORDER BY positive_ratings DESC LIMIT 5



/**************
*   SLIDE 5   *
***************/
# 1 The SUM of [positive_ratings MINUS negative_ratings] for ALL games under the Counter-Strike franchise.
#SELECT name, (positive_ratings - negative_ratings) AS 'net_rating' FROM tb_steam_games WHERE name LIKE '%Counter-Strike%'

# 2 The TOTAL number of games developed by BioWare, Telltale, and Square Enix (as attributes).
#SELECT developer, COUNT(developer) FROM tb_steam_games WHERE developer IN ('BioWare', 'Tellatale', 'Square Enix') GROUP BY developer
 
# 3 The name of the game with the HIGHEST negative_ratings.
#SELECT name, negative_ratings FROM tb_steam_games WHERE negative_ratings = (SELECT MAX(negative_ratings) FROM tb_steam_games)

# 4 The AVERAGE of the average_playtime for ALL games under the Half-Life franchise
#SELECT AVG(average_playtime) FROM tb_steam_games WHERE name LIKE '%Half-Life%'

# 5 The name, YEAR, MONTH, and DAY of ALL games, in ascending order of release_date.
#SELECT name, YEAR(release_date) AS 'year', MONTH(release_date) AS 'month', DAY(release_date) AS 'day' FROM tb_steam_games ORDER BY release_date ASC

# 6 The name and (YEARS PASSED from the release_date) of ALL games, ordered by YEARS PASSED in ascending order.
#SELECT name, (YEAR(CURRENT_DATE) - YEAR(release_date)) AS 'years passed' FROM tb_steam_games ORDER BY (YEAR(CURRENT_DATE) - YEAR(release_date)) ASC

# 7 The name and price of the game for prices between 3.00 and 7.00, ordered by price in ascending order.
#SELECT name, price FROM tb_steam_games WHERE price BETWEEN 3 AND 7 ORDER BY price


/*************
*   SLIDE 8  *
*************/
# 1 The SQL statement to RENAME the table to “mobile games (raw)”.
# ALTER TABLE `_dataset__mobile_games___sheet1` RENAME TO `mobile games (raw)`


/* 2 The SQL statement to CREATE a new table named “mobile games” with the following COLUMNS :
■ ALL columns from “mobile games (raw)”.
■ “Initial Release Date” which is the DATETIME version of Year, Month, and Day.
■ “Revenue Exponent” which is the INT value of the exponent from Revenue.*/
/*SELECT *,
	CONVERT(CONCAT(`Year`, `Month`, `Day`), DATE) AS `Initial Release Date`
FROM `mobile games (raw)`;*/

# 3 The SQL statement to MOVE “Initial Release Date” before Year.
# 4 The SQL statement to MOVE “Revenue Exponent” before “Initial Release Date”. 

#5 The SQL statement to display the Game and Revenue of the TOP 10 games, ordere by Game and Revenue. Do NOT create a new Table – use Views instead.

/**************
*   SLIDE 9   *
***************/
# 1 CREATE and UPDATE the Family column such that if the Previous Total is greater than the Total, SET the Family value to Name. Also SET Id = 1 value to Name.
#ALTER TABLE tb_pokemon_family ADD Family varchar(30)
#UPDATE tb_pokemon_family SET Family = Name WHERE `Previous Total` > Total;
#UPDATE tb_pokemon_family SET Family = Name WHERE Id = 1;

/* 2 Print the Id, Name, and Family columns, but populate the Family as follows :
	■WHEN the Family value is NULL, use the last Family value that is NOT NULL, from the Family value of the closest previous row.
	■ ELSE use the current Family value.*/
    
    
    /* 2 Print the Id, Name, and Family columns, but populate the Family as follows :
	■WHEN the Family value is NULL, use the last Family value that is NOT NULL, from the Family value of the closest previous row.
	■ ELSE use the current Family value.*/

#UPDATE tb_pokemon_family SET Family = Name WHERE `Previous Total` > Total;
#UPDATE tb_pokemon_family SET Family = Name WHERE Id = 1;

UPDATE tb_pokemon_family SET Family = CASE
WHEN Family IS NULL THEN NULL
ELSE Family
END;

SELECT * FROM `tb_pokemon_family` WHERE 1
    
    
    
# 3 Print the Id, Name, HP, Attack, Defense, Sp. Atk, Sp. Def, and Speed of ALL Fire Pokemon.
/*SELECT tb_pokemon_stats.*, FIRE_POKS.Name FROM tb_pokemon_stats, (SELECT name, id FROM tb_pokemon WHERE `Type 1` = 'Fire' OR `Type 2` = 'Fire') AS FIRE_POKS
WHERE tb_pokemon_stats.Id = FIRE_POKS.Id*/

# ALTERNATE USING JOIN
#SELECT tb_pokemon.name, tb_pokemon_stats.* FROM tb_pokemon LEFT JOIN tb_pokemon_stats ON tb_pokemon.Id = tb_pokemon_stats.Id WHERE tb_pokemon.`Type 1` = 'Fire' OR tb_pokemon.`Type 2` = 'Fire'