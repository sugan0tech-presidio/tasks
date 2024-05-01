DROP DATABASE EMP;

CREATE DATABASE EMP;

USE EMP;

CREATE TABLE ITEM (
    itemname VARCHAR(50) PRIMARY KEY,
    itemtype VARCHAR(50),
    itemcolor VARCHAR(50)
);

CREATE TABLE EMP (
    empno INT PRIMARY KEY,
    empname VARCHAR(50),
    salary DECIMAL(10, 2),
    bossno INT
);

ALTER TABLE EMP 
ADD CONSTRAINT fk_bossno FOREIGN KEY (bossno) REFERENCES EMP(empno) ON DELETE SET NULL;


-- Populate EMP table
INSERT INTO EMP (empno, empname, salary, bossno) VALUES
(1, 'Alice', 75000, NULL),
(2, 'Ned', 45000, 1),
(3, 'Andrew', 25000, 2),
(4, 'Clare', 22000, 2),
(5, 'Todd', 38000, 1),
(6, 'Nancy', 22000, 5),
(7, 'Brier', 43000, 1),
(8, 'Sarah', 56000, 7),
(9, 'Sophile', 35000, 1),
(10, 'Sanjay', 15000, 3),
(11, 'Rita', 15000, 4),
(12, 'Gigi', 16000, 4),
(13, 'Maggie', 11000, 4),
(14, 'Paul', 15000, 3),
(15, 'James', 15000, 3),
(16, 'Pat', 15000, 3),
(17, 'Mark', 15000, 3);


CREATE TABLE DEPARTMENT (
    deptname VARCHAR(50) PRIMARY KEY,
    deptfloor INT,
    deptphone VARCHAR(15),
    mgrno INT NOT NULL,
    CONSTRAINT fk_empno FOREIGN KEY (mgrno) REFERENCES EMP(empno) ON DELETE CASCADE
);

-- Populate DEPARTMENT table
INSERT INTO DEPARTMENT (deptname, deptfloor, deptphone, mgrno) VALUES
('Management', 5, '34', 1),
('Books', 1, '81', 4),
('Clothes', 2, '24', 4),
('Equipment', 3, '57', 3),
('Furniture', 4, '14', 3),
('Navigation', 1, '41', 3),
('Recreation', 2, '29', 4),
('Accounting', 5, '35', 5),
('Purchasing', 5, '36', 7),
('Personnel', 5, '37', 9),
('Marketing', 5, '38', 2);

-- Add deptname column to EMP table
ALTER TABLE EMP
ADD deptname VARCHAR(50);

ALTER TABLE EMP
ADD CONSTRAINT fk_deptname FOREIGN KEY (deptname) REFERENCES DEPARTMENT(deptname) ON DELETE SET NULL;


-- Update EMP table with department names
UPDATE EMP SET deptname = CASE 
    WHEN empno IN (1, 5, 7, 9) THEN 'Management'
    WHEN empno IN (2, 3, 4) THEN 'Marketing'
    WHEN empno IN (6) THEN 'Accounting'
    WHEN empno IN (8) THEN 'Purchasing'
    WHEN empno IN (10, 14, 15, 16, 17) THEN 'Navigation'
    WHEN empno IN (11, 12, 13) THEN 'Books'
    ELSE 'Unknown' END;



CREATE TABLE SALES (
    salesno INT PRIMARY KEY,
    saleqty INT,
    itemname VARCHAR(50) NOT NULL,
    deptname VARCHAR(50) NOT NULL,
    CONSTRAINT fk_itemname FOREIGN KEY (itemname) REFERENCES ITEM(itemname) ON DELETE CASCADE,
    CONSTRAINT fk_deptname_sales FOREIGN KEY (deptname) REFERENCES DEPARTMENT(deptname) ON DELETE CASCADE
);

-- Seed ITEM table
INSERT INTO ITEM (itemname, itemtype, itemcolor) VALUES
('Pocket Knife-Nile', 'E', 'Brown'),
('Pocket Knife-Avon', 'E', 'Brown'),
('Compass', 'N', ''),
('Geo positioning system', 'N', ''),
('Elephant Polo stick', 'R', 'Bamboo'),
('Camel Saddle', 'R', 'Brown'),
('Sextant', 'N', ''),
('Map Measure', 'N', ''),
('Boots-snake proof', 'C', 'Green'),
('Pith Helmet', 'C', 'Khaki'),
('Hat-polar Explorer', 'C', 'White'),
('Exploring in 10 Easy Lessons', 'B', ''),
('Hammock', 'F', 'Khaki'),
('How to win Foreign Friends', 'B', ''),
('Map case', 'E', 'Brown'),
('Safari Chair', 'F', 'Khaki'),
('Safari cooking kit', 'F', 'Khaki'),
('Stetson', 'C', 'Black'),
('Tent - 2 person', 'F', 'Khaki'),
('Tent -8 person', 'F', 'Khaki');

-- Populate SALES table
INSERT INTO SALES (salesno, saleqty, itemname, deptname) VALUES
(101, 2, 'Boots-snake proof', 'Clothes'),
(102, 1, 'Pith Helmet', 'Clothes'),
(103, 1, 'Sextant', 'Navigation'),
(104, 3, 'Hat-polar Explorer', 'Clothes'),
(105, 5, 'Pith Helmet', 'Equipment'),
(106, 2, 'Pocket Knife-Nile', 'Clothes'),
(107, 3, 'Pocket Knife-Nile', 'Recreation'),
(108, 1, 'Compass', 'Navigation'),
(109, 2, 'Geo positioning system', 'Navigation'),
(110, 5, 'Map Measure', 'Navigation'),
(111, 1, 'Geo positioning system', 'Books'),
(112, 1, 'Sextant', 'Books'),
(113, 3, 'Pocket Knife-Nile', 'Books'),
(114, 1, 'Pocket Knife-Nile', 'Navigation'),
(115, 1, 'Pocket Knife-Nile', 'Equipment'),
(116, 1, 'Sextant', 'Clothes'),
(121, 1, 'Exploring in 10 easy lessons', 'Books'),
(125, 1, 'Elephant Polo stick', 'Recreation'),
(126, 1, 'Camel Saddle', 'Recreation');

-- Fails due to Empty value
-- (117, 1, '', 'Equipment'),
-- (118, 1, '', 'Recreation'),
-- (119, 1, '', 'Furniture'),
-- (120, 1, 'Pocket Knife-Nile', ''),
-- (122, 1, 'How to win foreign friends', ''),
-- (123, 1, 'Compass', ''),
-- (124, 1, 'Pith Helmet', ''),
