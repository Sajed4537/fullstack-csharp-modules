------------------------------------------------------------
-- RESET LibraryDB
-- Remove all data and reseed identity values
------------------------------------------------------------

USE LibraryDB;
GO

-- Delete data
DELETE FROM Loans;
DELETE FROM Books;
DELETE FROM Authors;

-- Reset identity counters
DBCC CHECKIDENT ('Loans', RESEED, 0);
DBCC CHECKIDENT ('Books', RESEED, 0);
DBCC CHECKIDENT ('Authors', RESEED, 0);

-- Verify reset
SELECT * FROM Authors;
SELECT * FROM Books;
SELECT * FROM Loans;
