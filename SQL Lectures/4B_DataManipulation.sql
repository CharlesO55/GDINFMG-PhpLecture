/* CREATE SCHEMA lecture4B_DataManipulation;
 USE lecture4B_DataManipulation;
*/

# CREATING TABLES
DROP TABLE IF EXISTS tb_data;
CREATE TABLE tb_Data(
	id int NOT NULL
			UNIQUE
            AUTO_INCREMENT,
    type INT,
    name CHAR(255)
);

INSERT INTO tb_data (id, type, name)
	VALUES(-1, 3, "E");
    
SELECT * FROM tb_data;


# UPDATING GAMES TABLES
USE lecture3a_steamdata;

SET SQL_SAFE_UPDATES = 0;
UPDATE tb_games SET developer = 'Ubisoft' WHERE tb_games.developer LIKE '%Ubisoft%';
UPDATE tb_games SET developer = 'Tellatale' WHERE tb_games.developer LIKE '%Tellatale%';
UPDATE tb_games SET developer = 'PopCap' WHERE tb_games.developer LIKE '%PopCap%';

SELECT developer FROM tb_games;

SELECT developer, COUNT(*) FROM tb_games WHERE developer in ('Ubisoft', 'Tellatale', 'PopCap') GROUP BY developer;