# 📇 Contacts Management System

A desktop application built with C# and Windows Forms (WinForms) for managing personal and business contacts. This project implements full CRUD functionality with a connected SQL Server database and features a secure user authentication system.

## 🌟 Key Features

* **User Authentication:** Secure Login and Registration system. Each user gets their own isolated workspace.
* **Data Isolation:** Contacts are strictly linked to the user who created them using database relationships, ensuring you only see your own data.
* **Full CRUD Operations:** Add new contacts, view them in a dynamic grid, seamlessly update existing records, and safely delete them (with confirmation prompts).
* **SQL Injection Protection:** All database interactions use strict parameterized queries (`SqlCommand` parameters) to prevent malicious inputs.
* **Real-Time UI Updates:** The data table automatically refreshes in the background upon any data modification, providing immediate feedback.

## 🛠️ Tech Stack

* **Language:** C#
* **UI Framework:** Windows Forms (WinForms)
* **Database:** Microsoft SQL Server
* **Data Access:** ADO.NET (`SqlConnection`, `SqlCommand`, `SqlDataReader`, `DataTable`)

## ⚙️ Installation & Database Setup

### ⚠️ Database Setup Note
Please note that the SQL setup script or local database files are **not included** in this repository. To run this project locally, you will need to manually configure your SQL Server:

1. Create a database named `DB.Customers` on your local server (`localhost\SQLEXPRESS`).
2. Create a **`USERS`** table with columns: `ID` (Primary Key, Identity), `USERNAME`, `PASSWORD`, `EMAIL`.
3. Create a **`CUSTOMERS`** table with columns: `ID` (Primary Key, Identity), `NAME`, `SURNAME`, `COMPANY`, `COUNTRY`, `PREFIX`, `NUMBER`, `INSERT_USER` (Foreign Key linked to `USERS.ID`).
4. Open the `DALC.cs` file in the project and verify the connection string matches your local SQL Server instance.

### Running the project:
1. Clone the repository:
   ```bash
   git clone [https://github.com/Muhammedali709/CSHARP-Users-Customers-CRUD.git](https://github.com/Muhammedali709/CSHARP-Users-Customers-CRUD.git)
