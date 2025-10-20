--SELECT * 
--FROM Categories 
--INNER JOIN Products 
--ON Products.CategoryID = Categories.CategoryID;

--SELECT * 
--FROM Categories 
--LEFT JOIN Products 
--ON Products.CategoryID = Categories.CategoryID;

SELECT * 
FROM Categories 
INNER JOIN Products 
ON Products.CategoryID = Categories.CategoryID
INNER JOIN Stock
ON Stock.ProductID = Products.ProductID;
