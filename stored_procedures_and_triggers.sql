USE financeTrackerdb;
GO

-- ============================================
-- STORED PROCEDURES
-- ============================================

-- ============================================
-- User Authentication and Management
-- ============================================

-- User Login Procedure
IF OBJECT_ID('sp_UserLogin', 'P') IS NOT NULL
    DROP PROCEDURE sp_UserLogin;
GO
CREATE PROCEDURE sp_UserLogin
    @Username NVARCHAR(50),
    @Password NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT UserId, Username 
    FROM Users 
    WHERE Username = @Username AND Password = @Password;
END
GO

-- User Registration Procedure
IF OBJECT_ID('sp_UserRegister', 'P') IS NOT NULL
    DROP PROCEDURE sp_UserRegister;
GO
CREATE PROCEDURE sp_UserRegister
    @Username NVARCHAR(50),
    @Password NVARCHAR(255),
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Check if username already exists
    IF EXISTS(SELECT 1 FROM Users WHERE Username = @Username)
    BEGIN
        SET @Result = -1; -- Username exists
        RETURN;
    END
    
    -- Insert new user
    INSERT INTO Users (Username, Password, CurrentBalance)
    VALUES (@Username, @Password, 0);
    
    SET @Result = SCOPE_IDENTITY(); -- Return new UserId
END
GO

-- ============================================
-- Income Categories Management
-- ============================================

-- Get Income Categories for User
IF OBJECT_ID('sp_GetIncomeCategories', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetIncomeCategories;
GO
CREATE PROCEDURE sp_GetIncomeCategories
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT CategoryId, Name, Description 
    FROM IncomeCategories 
    WHERE UserId = @UserId;
END
GO

-- Insert Income Category
IF OBJECT_ID('sp_InsertIncomeCategory', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertIncomeCategory;
GO
CREATE PROCEDURE sp_InsertIncomeCategory
    @UserId INT,
    @Name NVARCHAR(100),
    @Description NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO IncomeCategories (UserId, Name, Description)
    VALUES (@UserId, @Name, @Description);
END
GO

-- Update Income Category
IF OBJECT_ID('sp_UpdateIncomeCategory', 'P') IS NOT NULL
    DROP PROCEDURE sp_UpdateIncomeCategory;
GO
CREATE PROCEDURE sp_UpdateIncomeCategory
    @CategoryId INT,
    @Name NVARCHAR(100),
    @Description NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE IncomeCategories 
    SET Name = @Name, Description = @Description
    WHERE CategoryId = @CategoryId;
END
GO

-- Delete Income Category
IF OBJECT_ID('sp_DeleteIncomeCategory', 'P') IS NOT NULL
    DROP PROCEDURE sp_DeleteIncomeCategory;
GO
CREATE PROCEDURE sp_DeleteIncomeCategory
    @CategoryId INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM IncomeCategories WHERE CategoryId = @CategoryId;
END
GO

-- ============================================
-- Expense Categories Management
-- ============================================

-- Get Expense Categories for User
IF OBJECT_ID('sp_GetExpenseCategories', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetExpenseCategories;
GO
CREATE PROCEDURE sp_GetExpenseCategories
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT CategoryId, Name, Budget, CurrentSpent, Description,
           Budget - CurrentSpent as Remaining
    FROM ExpenseCategories 
    WHERE UserId = @UserId;
END
GO

-- Insert Expense Category
IF OBJECT_ID('sp_InsertExpenseCategory', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertExpenseCategory;
GO
CREATE PROCEDURE sp_InsertExpenseCategory
    @UserId INT,
    @Name NVARCHAR(100),
    @Budget DECIMAL(18,2),
    @Description NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO ExpenseCategories (UserId, Name, Budget, CurrentSpent, Description)
    VALUES (@UserId, @Name, @Budget, 0, @Description);
END
GO

-- Update Expense Category
IF OBJECT_ID('sp_UpdateExpenseCategory', 'P') IS NOT NULL
    DROP PROCEDURE sp_UpdateExpenseCategory;
GO
CREATE PROCEDURE sp_UpdateExpenseCategory
    @CategoryId INT,
    @Name NVARCHAR(100),
    @Budget DECIMAL(18,2),
    @Description NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE ExpenseCategories 
    SET Name = @Name, Budget = @Budget, Description = @Description
    WHERE CategoryId = @CategoryId;
END
GO

-- Delete Expense Category
IF OBJECT_ID('sp_DeleteExpenseCategory', 'P') IS NOT NULL
    DROP PROCEDURE sp_DeleteExpenseCategory;
GO
CREATE PROCEDURE sp_DeleteExpenseCategory
    @CategoryId INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM ExpenseCategories WHERE CategoryId = @CategoryId;
END
GO

-- Get Remaining Budget for Expense Category
IF OBJECT_ID('sp_GetExpenseCategoryRemaining', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetExpenseCategoryRemaining;
GO
CREATE PROCEDURE sp_GetExpenseCategoryRemaining
    @CategoryId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Budget - CurrentSpent as Remaining
    FROM ExpenseCategories 
    WHERE CategoryId = @CategoryId;
END
GO

-- ============================================
-- Savings Goals Management
-- ============================================

-- Get Savings Goals for User
IF OBJECT_ID('sp_GetSavingsGoals', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetSavingsGoals;
GO
CREATE PROCEDURE sp_GetSavingsGoals
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT GoalId, Name, GoalAmount, CurrentAmount, 
           CASE WHEN GoalAmount > 0 THEN (CurrentAmount / GoalAmount) * 100 ELSE 0 END as Progress,
           Description
    FROM SavingsGoals 
    WHERE UserId = @UserId;
END
GO

-- Insert Savings Goal
IF OBJECT_ID('sp_InsertSavingsGoal', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertSavingsGoal;
GO
CREATE PROCEDURE sp_InsertSavingsGoal
    @UserId INT,
    @Name NVARCHAR(100),
    @GoalAmount DECIMAL(18,2),
    @Description NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO SavingsGoals (UserId, Name, GoalAmount, CurrentAmount, Description)
    VALUES (@UserId, @Name, @GoalAmount, 0, @Description);
END
GO

-- Update Savings Goal
IF OBJECT_ID('sp_UpdateSavingsGoal', 'P') IS NOT NULL
    DROP PROCEDURE sp_UpdateSavingsGoal;
GO
CREATE PROCEDURE sp_UpdateSavingsGoal
    @GoalId INT,
    @Name NVARCHAR(100),
    @GoalAmount DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE SavingsGoals 
    SET Name = @Name, GoalAmount = @GoalAmount
    WHERE GoalId = @GoalId;
END
GO

-- Delete Savings Goal
IF OBJECT_ID('sp_DeleteSavingsGoal', 'P') IS NOT NULL
    DROP PROCEDURE sp_DeleteSavingsGoal;
GO
CREATE PROCEDURE sp_DeleteSavingsGoal
    @GoalId INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM SavingsGoals WHERE GoalId = @GoalId;
END
GO

-- ============================================
-- Transaction Management
-- ============================================

-- Get Income Category ID by Name
IF OBJECT_ID('sp_GetIncomeCategoryId', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetIncomeCategoryId;
GO
CREATE PROCEDURE sp_GetIncomeCategoryId
    @UserId INT,
    @Name NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT CategoryId FROM IncomeCategories 
    WHERE UserId = @UserId AND Name = @Name;
END
GO

-- Insert Income Transaction
IF OBJECT_ID('sp_InsertIncomeTransaction', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertIncomeTransaction;
GO
CREATE PROCEDURE sp_InsertIncomeTransaction
    @UserId INT,
    @CategoryId INT,
    @Amount DECIMAL(18,2),
    @TransactionDate DATETIME,
    @Description NVARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Transactions (UserId, Type, CategoryId, Amount, TransactionDate, Description)
    VALUES (@UserId, 'Income', @CategoryId, @Amount, @TransactionDate, @Description);
END
GO

-- Insert Expense Transaction
IF OBJECT_ID('sp_InsertExpenseTransaction', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertExpenseTransaction;
GO
CREATE PROCEDURE sp_InsertExpenseTransaction
    @UserId INT,
    @CategoryId INT,
    @Amount DECIMAL(18,2),
    @TransactionDate DATETIME,
    @Description NVARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Transactions (UserId, Type, CategoryId, Amount, TransactionDate, Description)
    VALUES (@UserId, 'Expense', @CategoryId, @Amount, @TransactionDate, @Description);
END
GO

-- Insert Saving Transaction
IF OBJECT_ID('sp_InsertSavingTransaction', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertSavingTransaction;
GO
CREATE PROCEDURE sp_InsertSavingTransaction
    @UserId INT,
    @CategoryId INT,
    @Amount DECIMAL(18,2),
    @Description NVARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Transactions (UserId, Type, CategoryId, Amount, Description)
    VALUES (@UserId, 'Saving', @CategoryId, @Amount, @Description);
END
GO

-- Get Income Transactions for User
IF OBJECT_ID('sp_GetIncomeTransactions', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetIncomeTransactions;
GO
CREATE PROCEDURE sp_GetIncomeTransactions
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT t.TransactionId, c.Name as Category, t.Amount, t.TransactionDate, t.Description
    FROM Transactions t
    JOIN IncomeCategories c ON t.CategoryId = c.CategoryId
    WHERE t.UserId = @UserId AND t.Type = 'Income'
    ORDER BY t.TransactionDate DESC;
END
GO

-- Get Expense Transactions for User
IF OBJECT_ID('sp_GetExpenseTransactions', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetExpenseTransactions;
GO
CREATE PROCEDURE sp_GetExpenseTransactions
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT t.TransactionId, c.Name as Category, t.Amount, t.TransactionDate, t.Description
    FROM Transactions t
    JOIN ExpenseCategories c ON t.CategoryId = c.CategoryId
    WHERE t.UserId = @UserId AND t.Type = 'Expense'
    ORDER BY t.TransactionDate DESC;
END
GO

-- Get All Transactions for User
IF OBJECT_ID('sp_GetAllTransactions', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetAllTransactions;
GO
CREATE PROCEDURE sp_GetAllTransactions
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT t.TransactionId, 
           COALESCE(ic.Name, ec.Name, sg.Name) as Category,
           t.Type, t.Amount, t.TransactionDate, t.Description
    FROM Transactions t
    LEFT JOIN IncomeCategories ic ON t.CategoryId = ic.CategoryId AND t.Type = 'Income'
    LEFT JOIN ExpenseCategories ec ON t.CategoryId = ec.CategoryId AND t.Type = 'Expense'
    LEFT JOIN SavingsGoals sg ON t.CategoryId = sg.GoalId AND t.Type = 'Saving'
    WHERE t.UserId = @UserId
    ORDER BY t.TransactionDate DESC;
END
GO

-- Delete Transaction
IF OBJECT_ID('sp_DeleteTransaction', 'P') IS NOT NULL
    DROP PROCEDURE sp_DeleteTransaction;
GO
CREATE PROCEDURE sp_DeleteTransaction
    @TransactionId INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Transactions WHERE TransactionId = @TransactionId;
END
GO

-- Get Transaction Details
IF OBJECT_ID('sp_GetTransactionDetails', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetTransactionDetails;
GO
CREATE PROCEDURE sp_GetTransactionDetails
    @TransactionId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Type, Amount, CategoryId, UserId
    FROM Transactions 
    WHERE TransactionId = @TransactionId;
END
GO

-- ============================================
-- Balance and Summary Procedures
-- ============================================

-- Get User Balance
IF OBJECT_ID('sp_GetUserBalance', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetUserBalance;
GO
CREATE PROCEDURE sp_GetUserBalance
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ISNULL(SUM(CASE WHEN Type = 'Income' THEN Amount ELSE 0 END), 0) - 
           ISNULL(SUM(CASE WHEN Type = 'Expense' THEN Amount ELSE 0 END), 0) - 
           ISNULL(SUM(CASE WHEN Type = 'Saving' THEN Amount ELSE 0 END), 0) AS Balance
    FROM Transactions 
    WHERE UserId = @UserId;
END
GO

-- Get Transaction Totals by Type
IF OBJECT_ID('sp_GetTransactionTotals', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetTransactionTotals;
GO
CREATE PROCEDURE sp_GetTransactionTotals
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        ISNULL(SUM(CASE WHEN Type = 'Income' THEN Amount ELSE 0 END), 0) as TotalIncome,
        ISNULL(SUM(CASE WHEN Type = 'Expense' THEN Amount ELSE 0 END), 0) as TotalExpense,
        ISNULL(SUM(CASE WHEN Type = 'Saving' THEN Amount ELSE 0 END), 0) as TotalSaving
    FROM Transactions 
    WHERE UserId = @UserId;
END
GO

-- Get Dashboard Summary
IF OBJECT_ID('sp_GetDashboardSummary', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetDashboardSummary;
GO
CREATE PROCEDURE sp_GetDashboardSummary
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        ISNULL(SUM(CASE WHEN Type = 'Income' THEN Amount ELSE 0 END), 0) as CurrentIncome,
        ISNULL(SUM(CASE WHEN Type = 'Expense' THEN Amount ELSE 0 END), 0) as CurrentExpense,
        ISNULL(SUM(CASE WHEN Type = 'Saving' THEN Amount ELSE 0 END), 0) as CurrentSaving,
        (ISNULL(SUM(CASE WHEN Type = 'Income' THEN Amount ELSE 0 END), 0) - 
         ISNULL(SUM(CASE WHEN Type = 'Expense' THEN Amount ELSE 0 END), 0) - 
         ISNULL(SUM(CASE WHEN Type = 'Saving' THEN Amount ELSE 0 END), 0)) as CurrentBalance
    FROM Transactions 
    WHERE UserId = @UserId;
END
GO

-- Get Report Transactions
IF OBJECT_ID('sp_GetReportTransactions', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetReportTransactions;
GO
CREATE PROCEDURE sp_GetReportTransactions
    @UserId INT,
    @Type NVARCHAR(20) = NULL,
    @CategoryName NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TransactionId, UserId, Type, CategoryId, Amount, TransactionDate, Description
    FROM Transactions
    WHERE UserId = @UserId
    AND (@Type IS NULL OR Type = @Type)
    AND (@CategoryName IS NULL OR 
         (Type = 'Income' AND CategoryId IN (SELECT CategoryId FROM IncomeCategories WHERE Name = @CategoryName AND UserId = @UserId)) OR
         (Type = 'Expense' AND CategoryId IN (SELECT CategoryId FROM ExpenseCategories WHERE Name = @CategoryName AND UserId = @UserId)) OR
         (Type = 'Saving' AND CategoryId IN (SELECT GoalId FROM SavingsGoals WHERE Name = @CategoryName AND UserId = @UserId)))
    ORDER BY TransactionDate DESC;
END
GO

-- Get Category Names by Type
IF OBJECT_ID('sp_GetCategoryNamesByType', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetCategoryNamesByType;
GO
CREATE PROCEDURE sp_GetCategoryNamesByType
    @UserId INT,
    @Type NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF @Type = 'Income'
        SELECT Name FROM IncomeCategories WHERE UserId = @UserId;
    ELSE IF @Type = 'Expense'
        SELECT Name FROM ExpenseCategories WHERE UserId = @UserId;
    ELSE IF @Type = 'Saving'
        SELECT Name FROM SavingsGoals WHERE UserId = @UserId;
END
GO

-- ============================================
-- TRIGGERS
-- ============================================

-- Trigger to update CurrentBalance when a transaction is inserted
IF OBJECT_ID('trg_UpdateBalanceOnInsert', 'TR') IS NOT NULL
    DROP TRIGGER trg_UpdateBalanceOnInsert;
GO
CREATE TRIGGER trg_UpdateBalanceOnInsert
ON Transactions
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @UserId INT, @Type NVARCHAR(20), @Amount DECIMAL(18,2), @CategoryId INT;
    
    SELECT @UserId = UserId, @Type = Type, @Amount = Amount, @CategoryId = CategoryId
    FROM inserted;
    
    -- Update User Balance
    IF @Type = 'Income'
        UPDATE Users SET CurrentBalance = CurrentBalance + @Amount WHERE UserId = @UserId;
    ELSE IF @Type = 'Expense'
    BEGIN
        UPDATE Users SET CurrentBalance = CurrentBalance - @Amount WHERE UserId = @UserId;
        UPDATE ExpenseCategories SET CurrentSpent = CurrentSpent + @Amount WHERE CategoryId = @CategoryId;
    END
    ELSE IF @Type = 'Saving'
    BEGIN
        UPDATE Users SET CurrentBalance = CurrentBalance - @Amount WHERE UserId = @UserId;
        UPDATE SavingsGoals SET CurrentAmount = CurrentAmount + @Amount WHERE GoalId = @CategoryId;
    END
END
GO

-- Trigger to update CurrentBalance when a transaction is deleted
IF OBJECT_ID('trg_UpdateBalanceOnDelete', 'TR') IS NOT NULL
    DROP TRIGGER trg_UpdateBalanceOnDelete;
GO
CREATE TRIGGER trg_UpdateBalanceOnDelete
ON Transactions
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @UserId INT, @Type NVARCHAR(20), @Amount DECIMAL(18,2), @CategoryId INT;
    
    SELECT @UserId = UserId, @Type = Type, @Amount = Amount, @CategoryId = CategoryId
    FROM deleted;
    
    -- Reverse User Balance changes
    IF @Type = 'Income'
        UPDATE Users SET CurrentBalance = CurrentBalance - @Amount WHERE UserId = @UserId;
    ELSE IF @Type = 'Expense'
    BEGIN
        UPDATE Users SET CurrentBalance = CurrentBalance + @Amount WHERE UserId = @UserId;
        UPDATE ExpenseCategories SET CurrentSpent = CurrentSpent - @Amount WHERE CategoryId = @CategoryId;
    END
    ELSE IF @Type = 'Saving'
    BEGIN
        UPDATE Users SET CurrentBalance = CurrentBalance + @Amount WHERE UserId = @UserId;
        UPDATE SavingsGoals SET CurrentAmount = CurrentAmount - @Amount WHERE GoalId = @CategoryId;
    END
END
GO

-- Trigger to handle transaction updates
IF OBJECT_ID('trg_UpdateBalanceOnUpdate', 'TR') IS NOT NULL
    DROP TRIGGER trg_UpdateBalanceOnUpdate;
GO
CREATE TRIGGER trg_UpdateBalanceOnUpdate
ON Transactions
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @OldUserId INT, @OldType NVARCHAR(20), @OldAmount DECIMAL(18,2), @OldCategoryId INT;
    DECLARE @NewUserId INT, @NewType NVARCHAR(20), @NewAmount DECIMAL(18,2), @NewCategoryId INT;
    
    SELECT @OldUserId = UserId, @OldType = Type, @OldAmount = Amount, @OldCategoryId = CategoryId
    FROM deleted;
    
    SELECT @NewUserId = UserId, @NewType = Type, @NewAmount = Amount, @NewCategoryId = CategoryId
    FROM inserted;
    
    -- Reverse old transaction effects
    IF @OldType = 'Income'
        UPDATE Users SET CurrentBalance = CurrentBalance - @OldAmount WHERE UserId = @OldUserId;
    ELSE IF @OldType = 'Expense'
    BEGIN
        UPDATE Users SET CurrentBalance = CurrentBalance + @OldAmount WHERE UserId = @OldUserId;
        UPDATE ExpenseCategories SET CurrentSpent = CurrentSpent - @OldAmount WHERE CategoryId = @OldCategoryId;
    END
    ELSE IF @OldType = 'Saving'
    BEGIN
        UPDATE Users SET CurrentBalance = CurrentBalance + @OldAmount WHERE UserId = @OldUserId;
        UPDATE SavingsGoals SET CurrentAmount = CurrentAmount - @OldAmount WHERE GoalId = @OldCategoryId;
    END
    
    -- Apply new transaction effects
    IF @NewType = 'Income'
        UPDATE Users SET CurrentBalance = CurrentBalance + @NewAmount WHERE UserId = @NewUserId;
    ELSE IF @NewType = 'Expense'
    BEGIN
        UPDATE Users SET CurrentBalance = CurrentBalance - @NewAmount WHERE UserId = @NewUserId;
        UPDATE ExpenseCategories SET CurrentSpent = CurrentSpent + @NewAmount WHERE CategoryId = @NewCategoryId;
    END
    ELSE IF @NewType = 'Saving'
    BEGIN
        UPDATE Users SET CurrentBalance = CurrentBalance - @NewAmount WHERE UserId = @NewUserId;
        UPDATE SavingsGoals SET CurrentAmount = CurrentAmount + @NewAmount WHERE GoalId = @NewCategoryId;
    END
END
GO

PRINT 'All stored procedures and triggers have been created successfully!';
