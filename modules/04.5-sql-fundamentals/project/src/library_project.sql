------------------------------------------------------------
-- LibraryDB - Structure and initial dataset
------------------------------------------------------------

-- Create database if not exists
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'LibraryDB') 
BEGIN
    CREATE DATABASE LibraryDB;
END
GO

USE LibraryDB;
GO


------------------------------------------------------------
-- Table: Authors
------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Authors') AND type in (N'U'))
BEGIN
    CREATE TABLE Authors (
        AuthorID INT PRIMARY KEY IDENTITY(1, 1),
        Name NVARCHAR(100) NOT NULL,
        Nationality NVARCHAR(100)
    );
END
GO


------------------------------------------------------------
-- Table: Books
------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Books') AND type in (N'U'))
BEGIN
    CREATE TABLE Books (
        BookID INT PRIMARY KEY IDENTITY(1, 1),
        Title NVARCHAR(100) NOT NULL,
        Genre NVARCHAR(100) NOT NULL,
        Available BIT DEFAULT 1,
        AuthorID INT,
        FOREIGN KEY(AuthorID) REFERENCES Authors(AuthorID)
    );
END
GO


------------------------------------------------------------
-- Table: Loans
------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Loans') AND type in (N'U'))
BEGIN
    CREATE TABLE Loans (
        LoanID INT PRIMARY KEY IDENTITY(1, 1),
        PersonName NVARCHAR(100) NOT NULL,
        LoanDate DATE NOT NULL,
        ReturnDate DATE NULL,
        BookID INT,
        FOREIGN KEY(BookID) REFERENCES Books(BookID)
    );
END
GO


------------------------------------------------------------
-- Initial data
------------------------------------------------------------

-- Authors
INSERT INTO Authors (Name, Nationality)
VALUES 
('George Orwell', 'English'),
('J.K. Rowling', 'British'),
('Victor Hugo', 'French'),
('Agatha Christie', 'British'),
('Albert Camus', 'French');

-- Books
INSERT INTO Books (Title, Genre, AuthorID, Available)
VALUES
('1984', 'Dystopia', 1, 1),
('Harry Potter', 'Fantasy', 2, 1),
('Les Miserables', 'Novel', 3, 1),
('Murder of Roger Ackroyd', 'Detective', 4, 0),
('The Stranger', 'Philosophy', 5, 1);

-- Loans
INSERT INTO Loans (BookID, PersonName, LoanDate, ReturnDate)
VALUES
(4, 'Sajed Bouchaddakh', '2025-10-10', NULL),
(1, 'Marie Dupont', '2025-10-09', '2025-10-13');
