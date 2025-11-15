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
CREATE TABLE IncomeCategories (
    CategoryId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId) ON DELETE CASCADE,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255)
);

CREATE TABLE ExpenseCategories (
    CategoryId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId) ON DELETE CASCADE,
    Name NVARCHAR(100) NOT NULL,
    Budget DECIMAL(18,2) DEFAULT 0,
    CurrentSpent DECIMAL(18,2) DEFAULT 0,
    Description NVARCHAR(255)
);

CREATE TABLE SavingsGoals (
    GoalId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId) ON DELETE CASCADE,
    Name NVARCHAR(100) NOT NULL,
    GoalAmount DECIMAL(18,2) NOT NULL,
    CurrentAmount DECIMAL(18,2) DEFAULT 0,
    Description NVARCHAR(255)
);

-- Transactions Table
CREATE TABLE Transactions (
    TransactionId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),
    Type NVARCHAR(20) NOT NULL CHECK (Type IN ('Income', 'Expense', 'Saving')),
    CategoryId INT NOT NULL,
    Amount DECIMAL(18,2) NOT NULL CHECK (Amount > 0),
    TransactionDate DATETIME NOT NULL DEFAULT GETDATE(),
    Description NVARCHAR(500)
);

 --Insert default users
 INSERT INTO Users (UserId, Username, Password, CurrentBalance) VALUES
 (1, 'hieu', '1', 0)

--Insert default categories for new users
INSERT INTO IncomeCategories (UserId, Name, Description)
VALUES
(1, 'Salary', 'Monthly salary from employer');

INSERT INTO ExpenseCategories (UserId, Name, Budget, CurrentSpent, Description)
VALUES
(1, 'Groceries', 500.00, 0, 'Monthly grocery shopping'),
(1, 'Utilities', 200.00, 0, 'Monthly utility bills');

INSERT INTO SavingsGoals (UserId, Name, GoalAmount, CurrentAmount, Description)
VALUES
(1, 'Emergency Fund', 1000.00, 0, 'Savings for emergencies'),
(1, 'Vacation Fund', 1500.00, 0, 'Savings for vacation');


-- Indexes
-- Indexes are created in this search to speed up searching categories by user and type,
-- and transactions by user and date, as well as by category and type.
CREATE INDEX IX_IncomeCategories_UserId ON IncomeCategories(UserId);
CREATE INDEX IX_ExpenseCategories_UserId ON ExpenseCategories(UserId);
CREATE INDEX IX_SavingsGoals_UserId ON SavingsGoals(UserId);
CREATE INDEX IX_Transactions_UserId_Date ON Transactions(UserId, TransactionDate DESC);
CREATE INDEX IX_Transactions_CategoryId_Type ON Transactions(CategoryId, Type);
