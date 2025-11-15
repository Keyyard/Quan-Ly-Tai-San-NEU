CREATE DATABASE financeTrackerdb;
USE financeTrackerdb;



-- Users Table
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    CurrentBalance DECIMAL(18,2) DEFAULT 0,
);

-- Categories Table
CREATE TABLE Categories (
    CategoryId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId) ON DELETE CASCADE,
    Type NVARCHAR(20) NOT NULL CHECK (Type IN ('Income', 'Expense', 'Saving')),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    BudgetAmount DECIMAL(18,2) NULL,  -- For Expense: spend limit
    GoalAmount DECIMAL(18,2) NULL,    -- For Saving: save target; NULL for Income/Expense
    CurrentAmount DECIMAL(18,2) DEFAULT 0  -- Running total (earned/spent/saved)
);

-- Transactions Table
CREATE TABLE Transactions (
    TransactionId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),
    Type NVARCHAR(20) NOT NULL CHECK (Type IN ('Income', 'Expense', 'Saving')),
    CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(CategoryId) ON DELETE CASCADE,
    Amount DECIMAL(18,2) NOT NULL CHECK (Amount > 0),
    TransactionDate DATETIME NOT NULL DEFAULT GETDATE(),
    Description NVARCHAR(500)
);

-- Indexes
-- Indexes are created in this search to speed up searching categories by user and type,
-- and transactions by user and date, as well as by category and type.
CREATE INDEX IX_Categories_UserId_Type ON Categories(UserId, Type);
CREATE INDEX IX_Transactions_UserId_Date ON Transactions(UserId, TransactionDate DESC);
CREATE INDEX IX_Transactions_CategoryId_Type ON Transactions(CategoryId, Type);