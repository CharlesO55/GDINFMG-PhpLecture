-- RESTART;
USE lecture3a_steamdata;

-- DROP TABLE tb_gamespartial;

-- 1. The SUM of [positive_ratings MINUS negative_ratings] for ALL games under the Counter-Strike franchise.
-- SELECT SUM(positive_ratings - negative_ratings) AS `NET RATINGS` FROM tb_games WHERE name LIKE "%Counter-Strike%";

-- The TOTAL number of games developed by BioWare, Telltale, and Square Enix (as attributes)
/*SELECT 
	(SELECT COUNT(*) FROM tb_games WHERE developer LIKE '%Bioware%') AS BIOWARE,
	(SELECT COUNT(*) FROM tb_games WHERE developer LIKE '%Telltale%') AS TELLALE,
    (SELECT COUNT(*) FROM tb_games WHERE developer LIKE '%Square Enix%') AS `SQUARE ENIX`
;*/

SELECT developer, COUNT(developer) FROM tb_games WHERE developer LIKE '%Bioware%' GROUP BY developer;

-- 3. The name of the game with the HIGHEST negative_ratings
/*SELECT * FROM tb_games WHERE negative_ratings =
	(SELECT MAX(negative_ratings) FROM tb_games);*/
    
-- 4. The AVERAGE of the average_playtime for ALL games under the Half-Life franchise.
-- SELECT AVG(average_playtime) FROM tb_games WHERE name LIKE "%Half-Life%";

-- 5. The name, YEAR, MONTH, and DAY of ALL games, in ascending order of release_date
/* SELECT name,  YEAR(release_date) AS YEAR, MONTH(release_date) AS MONTH, DAY(release_date) AS DAY
	FROM tb_gamespartial ORDER BY release_date;*/

-- 6. The name and (YEARS PASSED from the release_date) of ALL games, ordered by YEARS PASSED in ascending order
-- SELECT name, YEAR(NOW()) - YEAR(release_date) AS `YEARS PASSED` FROM tb_gamespartial ORDER BY `YEARS PASSED` ASC;

-- 7. The name and price of the game for prices between 3.00 and 7.00, ordered by price in ascending order.
-- SELECT name, price FROM tb_gamespartial WHERE price >= 3 AND price <= 7 ORDER BY price, name;