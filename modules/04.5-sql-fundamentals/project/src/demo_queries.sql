------------------------------------------------------------
-- DEMO QUERIES - LibraryDB
------------------------------------------------------------

USE LibraryDB;
GO

------------------------------------------------------------
-- 01. Simple reading
------------------------------------------------------------
--SELECT * FROM Authors;
--SELECT * FROM Books;
--SELECT * FROM Loans;


------------------------------------------------------------
-- 02. Joins
------------------------------------------------------------
--SELECT * 
--FROM Authors
--INNER JOIN Books ON Authors.AuthorID = Books.AuthorID;

--SELECT * 
--FROM Authors
--INNER JOIN Books ON Authors.AuthorID = Books.AuthorID
--INNER JOIN Loans ON Loans.BookID = Books.BookID;


------------------------------------------------------------
-- 03. Filters
------------------------------------------------------------
--SELECT * FROM Books WHERE Available = 0;
--SELECT * FROM Loans WHERE ReturnDate IS NULL;
--SELECT * FROM Books WHERE Genre = 'Novel' OR Genre = 'Fantasy';
--SELECT * FROM Loans WHERE LoanDate < '2025-10-01';


------------------------------------------------------------
-- 04. Aggregations
------------------------------------------------------------
--SELECT COUNT(*) FROM Books WHERE Available = 1;

--SELECT Name, COUNT(Books.BookID)
--FROM Authors 
--INNER JOIN Books ON Authors.AuthorID = Books.AuthorID
--GROUP BY Authors.Name;

--SELECT Genre, COUNT(Genre) FROM Books GROUP BY Genre;


------------------------------------------------------------
-- 05. CRUD demo
------------------------------------------------------------

-- CREATE
--INSERT INTO Loans(PersonName, LoanDate, ReturnDate, BookID)
--VALUES ('Jean Michel', '2025-10-01', NULL, 2);
--UPDATE Books SET Available = 0 WHERE BookID = 2;

-- READ
--SELECT * FROM Loans WHERE PersonName = 'Jean Michel';

-- UPDATE
--UPDATE Loans SET ReturnDate = '2025-10-31' WHERE PersonName = 'Jean Michel';
--SELECT * FROM Loans WHERE PersonName = 'Jean Michel';

-- DELETE
--DELETE FROM Loans WHERE PersonName = 'Jean Michel';
--UPDATE Books SET Available = 1 WHERE BookID = 2;

-- Final check
--SELECT * FROM Loans;


------------------------------------------------------------
-- 06. Index and optimization
------------------------------------------------------------

-- Test search
--SELECT * FROM Books WHERE Title = 'Les Miserables';

-- Create nonclustered index
--CREATE NONCLUSTERED INDEX IX_Title_books
--ON Books(Title);

-- Drop index
--DROP INDEX IX_Title_books ON Books;

-- Final check
--SELECT * FROM Books WHERE Title = 'Les Miserables';
