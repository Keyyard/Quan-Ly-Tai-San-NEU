# Financial Tracker dotNet 8 WindowsForm
plans - live: https://keyyard.notion.site/net-prj-2ab7520f92e48041bdc6cff193afa1a3?source=copy_link

## Database

The app uses a local SQL Server database with the following tables:

```sql
users {
userId (PK)
username
password
currentBalance
}

IncomeCategories {
CategoryId (PK)
UserId (FK)
Name
Description
}

ExpenseCategories {
CategoryId (PK)
UserId (FK)
Name
Description
Budget (decimal)
CurrentSpent (decimal)
}

SavingsGoals {
GoalId (PK)
UserId (FK)
Name
GoalAmount (decimal)
CurrentAmount (decimal)
Description
}

transactions {
transactionId (PK)
userId (FK)
type (Income/Expense/Saving)
categoryId (FK to IncomeCategories or ExpenseCategories or SavingsGoals based on type)
amount (decimal)
date (datetime)
description
}
```

- Categories are separated into IncomeCategories and ExpenseCategories for better control.
- ExpenseCategories include Budget and CurrentSpent for tracking spending limits.
- SavingsGoals manage savings targets with current progress.
- Transactions reference the appropriate category table based on type.
- Index on SQl to optimize searches

```
CREATE INDEX idx_product_id
ON Sales (product_id);
```

```
SELECT *
FROM People WITH (INDEX(People_Name))
WHERE [Name] = 'Peter';
```

## Forms

1. **Sign In (FrmSignIn)**: Login form for existing users.

2. **Sign Up (FrmSignUp)**: Registration form for new users.

3. **Dashboard (FrmDashboard)**:
   - Displays current balance.
   - Menus to navigate to other forms:
     - Add Income
     - Add Expense
     - Transaction History
     - Savings Management
     - Expense Categories Management
     - Income Categories Management
     - Reports

4. **Add Income (FrmIncome)**:
   - Select Income Category from IncomeCategories.
   - Amount: Input number
   - Date: Date picker
   - Description: Input text
   - [Add] button to insert transaction and update balance.

5. **Add Expense (FrmExpense)**:
   - Select Expense Category from ExpenseCategories.
   - Amount: Input number
   - Date: Date picker
   - Description: Input text
   - Displays remaining budget for selected category.
   - [Add] button to insert transaction, update balance, and increment CurrentSpent.

6. **Transaction History (FrmTransactionHistory)**:
   - Filter by transaction type (Income/Expense/Saving).
   - DataGridView showing all transactions with category names.
   - Edit/Update and Delete functionality for transactions.
   - Updates category CurrentSpent or SavingsGoals CurrentAmount on edit/delete.

7. **Savings Management (FrmSavings)**:
   - Full CRUD for SavingsGoals: Create, Read, Edit, Delete.
   - Fields: Name, GoalAmount, CurrentAmount, Description.
   - [Deposit] button to add money to a selected goal, inserting a transaction and updating CurrentAmount.

8. **Expense Categories Management (FrmCategories)**:
   - CRUD for ExpenseCategories.
   - Fields: Name, Description, Budget (spending limit).
   - DataGridView for listing and managing categories.

9. **Income Categories Management (FrmIncomeCategories)**:
   - CRUD for IncomeCategories.
   - Fields: Name, Description.
   - DataGridView for listing and managing categories.

9. **Income Categories Management (FrmIncomeCategories)**:
   - CRUD for IncomeCategories.
   - Fields: Name, Description.
   - DataGridView for listing and managing categories.

10. **Reports (FrmBaoCaoThongKe)**:
   - Displays total Income, Expense, Savings by month/year.
   - Simple sum queries grouped by type and date.
