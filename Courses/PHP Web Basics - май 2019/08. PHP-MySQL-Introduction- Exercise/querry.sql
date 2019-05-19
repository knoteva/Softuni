CREATE DATABASE firstheididb
USE firstheididb

-- 01. Create Tables

	CREATE TABLE minions(
		id INT NOT NULL primary KEY AUTO_INCREMENT,
		`name` VARCHAR(50) NOT NULL,
		age INT NOT NULL DEFAULT '0',
		town_id INT NOT NULL DEFAULT '0'
	);

	CREATE TABLE towns(
		id INT NOT NULL primary KEY AUTO_INCREMENT,
		`name` VARCHAR(50) NOT NULL
	);


--  02. Insert Records in Both Tables

	INSERT INTO towns (id, name)
	VALUES(1, 'Sofia');

	INSERT INTO towns (id, name)
	VALUES(2, 'Plovdiv');

	INSERT INTO towns (id, name)
	VALUES(3, 'Varna');

	INSERT INTO minions(id, name, age, town_id)
	VALUES(1, 'Kevin', 22, 1);

	INSERT INTO minions(id, name, age, town_id)
	VALUES(2, 'Bob', 15, 3);

	INSERT INTO minions(id, name, age, town_id)
	VALUES(3, 'Steward', NULL, 2);


-- 03. Truncate Table Minions 

	DELETE FROM minions


-- 04. Drop All Tables 

	DROP TABLE minions, towns;


-- 05. Create Table People

	CREATE TABLE people(
	id INT NOT NULL primary KEY AUTO_INCREMENT,
	`name` VARCHAR(200) NOT NULL,
	picture binary(2),
	height float(2),
	weight float(2),
	gender enum('m','f') NOT NULL,
	birthdate date not null,	
	biography longtext,
	CONSTRAINT CH_people_gender CHECK(Gender IN('M', 'F'))
	);

	INSERT INTO people (id, `name`, picture, height, weight, gender, birthdate, biography)
	VALUES(null, 'Kate Note', NULL, 5.20, 3.40, 'F', '2002-12-12', 'No biography');

	INSERT INTO people (id, `name`, picture, height, weight, gender, birthdate, biography)
	VALUES(null, 'Kate Note', NULL, 5.20, 3.40, 'F', '2002-12-12', 'No biography');

	INSERT INTO people (id, `name`, picture, height, weight, gender, birthdate, biography)
	VALUES(null, 'Kate Note', NULL, 5.20, 3.40, 'F', '2002-12-12', 'No biography');

	INSERT INTO people (id, `name`, picture, height, weight, gender, birthdate, biography)
	VALUES(null, 'Kate Note', NULL, 5.20, 3.40, 'F', '2002-12-12', 'No biography');

	INSERT INTO people (id, `name`, picture, height, weight, gender, birthdate, biography)
	VALUES(null, 'Kate Note', NULL, 5.20, 3.40, 'F', '2002-12-12', 'No biography');


-- 06. Create Table Users

	CREATE TABLE users
	(
		id BIGINT UNIQUE PRIMARY KEY AUTO_INCREMENT,
		username VARCHAR(30) UNIQUE NOT NULL,
		password VARCHAR(26) NOT NULL,
		profile_picture MEDIUMBLOB,
		last_login_time DATETIME,
		is_deleted BOOL  
	);

	INSERT INTO users (id, `username`, `password`, profile_picture, last_login_time, is_deleted)
	VALUES(null, 'Kate Note', 'im123', NULL, '2002-12-12', TRUE);

	INSERT INTO users (id, `username`, `password`, profile_picture, last_login_time, is_deleted)
	VALUES(null, 'Kate Note2', 'im123', NULL, '2002-12-12', TRUE);

	INSERT INTO users (id, `username`, `password`, profile_picture, last_login_time, is_deleted)
	VALUES(null, 'Kate Note3', 'im123', NULL, '2002-12-12', TRUE);

	INSERT INTO users (id, `username`, `password`, profile_picture, last_login_time, is_deleted)
	VALUES(null, 'Kate Note4', 'im123', NULL, '2002-12-12', TRUE);

	INSERT INTO users (id, `username`, `password`, profile_picture, last_login_time, is_deleted)
	VALUES(null, 'Kate Note5', 'im123', NULL, '2002-12-12', true);


-- 07. Change Primary Key

	ALTER TABLE users
	  MODIFY id INT NOT NULL;
	ALTER TABLE users
	  DROP PRIMARY KEY;
	ALTER TABLE users
	  ADD CONSTRAINT pk_users PRIMARY KEY (id,username);


-- 08. Find All Information About 

	SELECT * 
	FROM departments;


-- 09. Find all Department Names 

	SELECT name 
	FROM departments;


-- 10. Find Salary of Each Employee 


	SELECT first_name, last_name, salary 
	FROM employees;


-- 11. Find Full Name of Each Employee 

	SELECT first_name, middle_name, last_name 
	FROM employees;


-- 12. Find Email Address of Each Employee 


	SELECT CONCAT( first_name, '.', last_name, '@softuni.bg')
	FROM employees;


-- 13. Find All Different Employee’s Salaries 

	SELECT distinct(salary)
	FROM employees
	ORDER BY salary


-- 14. Find all Information About Employees 

	SELECT *
	FROM employees
	WHERE job_title = 'Sales Representative'


-- 15. Find Names of All Employees by Salary in Range 

	SELECT first_name, last_name, job_title
	FROM employees
	WHERE salary BETWEEN 20000 AND 30000


-- 16. Find Names of All Employees 

	SELECT CONCAT_WS(" ", first_name, middle_name, last_name) AS `full_name`
	FROM employees
	WHERE salary IN(25000, 14000, 12500, 23600)


-- 17. Find All Employees Without Manager 

	SELECT first_name, last_name
	FROM employees
	WHERE manager_id IS NULL


-- 18. Find All Employees with Salary More Than 

	SELECT first_name, last_name, salary
	FROM employees
	WHERE salary > 50000
	ORDER BY salary DESC


-- 19. Find 5 Best Paid Employees 

	SELECT first_name, last_name
	FROM employees
	ORDER BY salary DESC
	LIMIT 5


-- 20. Find All Employees Except Marketing 

	SELECT first_name, last_name
	FROM employees
	WHERE department_id != 4


-- 21. Sort Employees Table 

	SELECT *
	FROM employees
	ORDER BY salary DESC, first_name, last_name DESC, middle_name


-- 22. Distinct Job Titles 

	SELECT distinct(job_title)
	FROM employees
	ORDER BY job_title


-- 23. Find First 10 Started Projects	

	SELECT *
	FROM projects
	ORDER BY start_date, `name`
	LIMIT 10


-- 24. Last 7 Hired Employees	

	SELECT first_name, last_name, hire_date
	FROM employees
	ORDER BY hire_date desc
	LIMIT 7


-- 25. Increase Salaries

	UPDATE employees
	SET salary = salary * 1.12
	WHERE department_id IN(1, 2, 4, 11);

	SELECT salary FROM employees
	WHERE department_id IN(1, 2, 4, 11);


-- 26. All Mountain Peaks 

	SELECT peak_name
	FROM peaks
	ORDER BY peak_name


-- 27. Biggest Countries by Population 

	SELECT 
	country_name, population
	FROM countries
	WHERE continent_code = 'EU'
	ORDER BY population DESC, country_name
	LIMIT 30


-- 28. Countries and Currency (Euro / Not Euro)

	SELECT country_name, country_code, 
	IF (currency_code = 'EUR', 'Euro', 'Not Euro') AS currency 
	FROM countries
	WHERE currency_code IS NOT NULL
	ORDER BY country_name;