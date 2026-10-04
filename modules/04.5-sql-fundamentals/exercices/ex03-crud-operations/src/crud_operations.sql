DELETE FROM Stock;
DELETE FROM Products;
DELETE FROM Categories;

DBCC CHECKIDENT ('Stock', RESEED, 0);
DBCC CHECKIDENT ('Products', RESEED, 0);
DBCC CHECKIDENT ('Categories', RESEED, 0);

SELECT * FROM Categories;
SELECT * FROM Products;
SELECT * FROM Stock;




INSERT INTO Categories(Name) VALUES ('Électronique');
INSERT INTO Categories(Name) VALUES ('Mobilier');
INSERT INTO Categories(Name) VALUES ('Informatique');
INSERT INTO Categories(Name) VALUES ('Vêtements');
INSERT INTO Categories(Name) VALUES ('Mobilier');

SELECT * FROM Categories;

SELECT * FROM Categories WHERE Name = 'Mobilier';

UPDATE Categories SET Name = 'Alimentation' WHERE CategoryID = 5;

SELECT * FROM Categories;

DELETE FROM Categories WHERE CategoryID = 5;

SELECT * FROM Categories;


INSERT INTO Products(Name, Price, CategoryID) VALUES('Montre connectée', 150.0, 1);
INSERT INTO Products(Name, Price, CategoryID) VALUES('Canapé', 850.0, 2);
INSERT INTO Products(Name, Price, CategoryID) VALUES('Chemise', 49.99, 4);
INSERT INTO Products(Name, Price, CategoryID) VALUES('Pull', 69.99, 4);
INSERT INTO Products(Name, Price, CategoryID) VALUES('Montre connectée pour enfant', 70.0, 1);

SELECT * FROM Products; 

SELECT * FROM Products WHERE Price = 49.99;

DELETE FROM Products WHERE Name = 'Montre connectée pour enfant';

SELECT * FROM Products;


INSERT INTO Stock(Quantity, ProductID) VALUES(5,1);
INSERT INTO Stock(Quantity, ProductID) VALUES(11,2);
INSERT INTO Stock(Quantity, ProductID) VALUES(7,3);
INSERT INTO Stock(Quantity, ProductID) VALUES(6,4);

SELECT * FROM Stock; 

SELECT * FROM Stock WHERE Quantity < 5;

DELETE FROM Stock WHERE Quantity > 10;

SELECT * FROM Stock;





