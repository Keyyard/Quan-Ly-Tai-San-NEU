# Financial Tracker dotNet 8 WindowsForm
plans - live: https://keyyard.notion.site/net-prj-2ab7520f92e48041bdc6cff193afa1a3?source=copy_link

## Database

Transactions (Income/Expense/Saving) - balance & detail

Categories - Each type of Transaction has their own types. Savings will have input as name of saving instead of type and can be select later as well.

Users can set the amount they goal to spend a category, and alert if spent over category.

```
users {
userId
username
password
currentBalance
}

categories {
categoryId
userId
type Income/Expense/Saving
name
description
goalAmount?
budget? if expense
currentAmount? 
}

transactions {
transactionId
userId
type Income/Expense/Saving
cateogoryId
amount
date
description
}
```

## Forms

1. Login
2. Register
3. Dashboard:
    
    Current Balance: {number}
    
    Menus:
    
    [Transaction Form]
    
    [Transaction History]
    
    [Savings]
    
    [Categories CRUD]
    
4. Transaction Form
    
    Type [Combo Box]
    
    Category/Name(if savings): Combo Box.
    
    Balance: Input number
    
    Date: date
    
    Description: input text
    
    [Add]
    
5. Transaction History
    
    Can search depends on Transaction Type. {input}
    
    Read | Edit/Update | Delete
    
    {DataGridView shows all transactions}
    
6. Savings
    - Create Savings (Category in type Saving):
    
    Name (category name): input
    
    Goal (goal? in category): input
    
    READ | EDIT | DELETE
    
    Display all names (category) savings with their stats via DataGridView.
    
7. Categories
    - Create Categories:
    
    Type: type of Income/Expense Combo Box

    if Expense -> budget: input
    
    Name: input text
    
    Description?: input text
    
    {GridDataView}