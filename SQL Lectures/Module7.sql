# MODULE 7 SCHEMA
/*
CREATE SCHEMA Module7;
USE Module7;
*/


DROP TABLE IF EXISTS `inner join A`;
CREATE TABLE `inner join A` (
	ID int,
    NAME CHAR(20)
);


INSERT INTO `inner join A` (ID, NAME) VALUES
	(1, "RED"), 
    (2, "BLUE"),
    (3, "GOLD"),
    (4, "SILVER");

#SELECT * FROM `inner join A`;

DROP TABLE IF EXISTS `inner join B`;
CREATE TABLE `inner join B` (
	ID int,
    STARTER CHAR(20)
);

INSERT INTO `inner join B` (ID, STARTER) VALUES
	(1, "WATER"), 
    (2, "WATER"),
    (1, "GRASS"),
    (1, "FIRE");

# SELECT * FROM `inner join B`;

DROP VIEW IF EXISTS view_inner;
CREATE VIEW view_inner AS
SELECT NAME, STARTER FROM `inner join A` AS a
	INNER JOIN `inner join B` AS b
    ON a.ID = b.ID;
    
    
    
    
    
    
    
    
    
    
# LEFT JOIN
DROP TABLE IF EXISTS `left join A`;
CREATE TABLE `left join A` (
	ID int,
    NAME CHAR(20)
);


INSERT INTO `left join A` (ID, NAME) VALUES
	(1, "RED"), 
    (2, "BLUE"),
    (3, "GOLD"),
    (4, "SILVER");

#SELECT * FROM `inner join A`;

DROP TABLE IF EXISTS `left join B`;
CREATE TABLE `left join B` (
	ID int,
    STARTER CHAR(20)
);

INSERT INTO `left join B` (ID, STARTER) VALUES
	(1, "WATER"), 
    (2, "WATER"),
    (1, "GRASS"),
    (1, "FIRE");

# SELECT * FROM `inner join B`;

DROP VIEW IF EXISTS view_left;
CREATE VIEW view_left AS
SELECT NAME, STARTER FROM `left join A` AS a
	LEFT JOIN `left join B` AS b
    ON a.ID = b.ID;

    
    
    
    
    

# RIGHT JOIN
DROP TABLE IF EXISTS `right join A`;
CREATE TABLE `right join A` (
	ID int,
    NAME CHAR(20)
);


INSERT INTO `right join A` (ID, NAME) VALUES
	(1, "RED"), 
    (2, "BLUE"),
    (3, "GOLD"),
    (4, "SILVER");

#SELECT * FROM `inner join A`;

DROP TABLE IF EXISTS `right join B`;
CREATE TABLE `right join B` (
	ID int,
    STARTER CHAR(20)
);

INSERT INTO `right join B` (ID, STARTER) VALUES
	(1, "WATER"), 
    (2, "WATER"),
    (1, "GRASS"),
    (1, "FIRE");

# SELECT * FROM `inner join B`;
DROP VIEW IF EXISTS view_right;

CREATE VIEW view_right AS
SELECT NAME, STARTER FROM `right join A` AS a
	RIGHT JOIN `right join B` AS b
    ON a.ID = b.ID;
    
SELECT * FROM view_left;