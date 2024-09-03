#CREATE DATABASE _myDB;
#USE _myDB;
#DROP DATABASE _myDB;

#ALTER DATABASE _myDB READ ONLY = 0;


/*DROP TABLE IF EXISTS _employeesTable;
CREATE TABLE _employeesTable(
	employee_id INT,
    first_name VARCHAR(50),
    family_name VARCHAR(50),
    hourly_pay DECIMAL(6, 2),
    hire_date DATE
);

/*ADDING COLUMNS*/
/*ALTER TABLE _employeesTable
	ADD phone_number VARCHAR(15);*/

/*RENAMING HEADERS*/
/*ALTER TABLE _employeesTable
	RENAME COLUMN family_name TO surname;*/

/*MODIFYING DATA TYPE*/
/*ALTER TABLE _employeesTable
	MODIFY COLUMN surname VARCHAR(20);*/

/*SHIFTING COLUMNS*/
/*ALTER TABLE _employeesTable
	MODIFY COLUMN phone_number VARCHAR(15) AFTER surname;*/

/*DELETING COLS*/
/*ALTER TABLE _employeesTable
	DROP COLUMN phone_number;*/


/*ADDING VALUES*/
INSERT INTO _employeesTable
	VALUES(1, "John", "Doe", 5.30, "2023-05-16"), (2, "Sam", "Smith", 3.1, "2022-10-23");

SELECT * FROM _employeesTable;