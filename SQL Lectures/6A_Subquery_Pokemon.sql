# CREATE SCHEMA Pokemon;

USE Pokemon;

# SELECT * FROM typeeffectiveness

# LIMIT TO 1 FOR AVG
-- SELECT *, CASE WHEN B1.Attack IS NULL THEN (
-- 	SELECT AVG(B2.Attack) FROM battlestatistics AS B2 LIMIT 1)
-- 			ELSE B1.Attack
--             END AS CleanedAttack
-- 	FROM battlestatistics AS B1;
--     
-- SELECT D.Id, Name, T.Normal
-- FROM descriptions AS D, (SELECT Id, Normal FROM typeeffectiveness) AS T
-- WHERE D.Id = T.Id;

-- SELECT description
-- FROM descriptions
-- WHERE name IN (SELECT name FROM games WHERE publisher='Square Enix');

-- SELECT name_const()FROM games AS G
-- WHERE CHAR_LENGTH(name) > (SELECT AVG(CHAR_LENGTH()



-- ALTER TABLE practicalexercise
-- ADD Family TEXT AFTER `Previous Total`;


-- SELECT * FROM practicalexercise;

-- CREATE TABLE workTable AS
-- 	SELECT * FROM practicalexercise;
    
#SELECT * FROM workTable;

SET SQL_SAFE_UPDATES = 0;


#UPDATE workTable SET workTable.Family = Name WHERE (SELECT * FROM workTable WHERE `Previous Total` > Total);


#1
-- UPDATE workTable SET Family = Name WHERE (`Previous Total` > Total);
-- UPDATE workTable SET Family = Name WHERE (Id = 1);
-- SELECT * FROM workTable;

SELECT *, CASE WHEN T1.Family IS NULL THEN(
	SELECT T2.Family FROM workTable AS T2 WHERE T2.Total=T2.`Previous Total` LIMIT 1)
			ELSE T1.Family
				END AS 'Family'
			FROM workTable as T1;

#SELECT TOP Family FROM workTable LIMIT 1;
#SELECT max(Family) FROM workTable 

SELECT T2.Family FROM workTable AS T2;

#SELECT * FROM workTable  WHERE Family=(SELECT max(Family) FROM workTable );
#SELECT * FROM workTable;

#SELECT LAST(workTable.Family) FROM workTable;