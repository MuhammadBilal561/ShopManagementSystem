# 🛒 Shop Management System (C# Console App)

A professional console-based application for managing a shop's inventory, customers, and sales. This project is built with C# and .NET, demonstrating a **layered architecture**, **hybrid data persistence**, and strict adherence to professional coding standards.

![Shop Management System UI Screenshot](https://i.imgur.com/gKj8V5c.png)

## 📋 Key Features

* **Hybrid Data Persistence (DB-First):** All core operations (Add, Update, Delete) prioritize a **SQL Database** connection. Local `.txt` files serve as a backup/fallback for critical data, ensuring system resilience.
* **Customer & Product Management:** Full CRUD (Create, Read, Update, Delete) functionality for both products and customer records.
* **Advanced Search:** Robust searching for customers by Name, Initial Character, **Age, Address, and Phone Number**.
* **Sales & Order History:** Create detailed sales orders and view a complete history, filterable by customer.
* **Robust Architecture:** Utilizes a strict **Layered Facade Pattern** for separation of concerns and maintainability.

---

## 🏛️ Project Architecture (Layered Facade & Hybrid Repository)

The project employs a standard five-layer architecture, with the **Service Layer** handling the business logic of choosing the correct data source.

### Architecture Breakdown

| Layer | Responsibility | Key Component | Data Strategy |
| :--- | :--- | :--- | :--- |
| **1. UI** | Handles **User Input** and **Output** only. | `CustomerUI.cs`, `ProductUI.cs` | N/A |
| **2. Facade** | **Single entry point** for the UI. Delegates all requests. | `Shop.cs` | N/A |
| **3. Service (Business Logic)** | Implements **data strategy (DB-First)**, manages complex validation, and coordinates repositories. | `CustomerService.cs` | Calls `...RepoDB` first, falls back to `...Repository` (File) if necessary. |
| **4. Repository** | Handles **direct data access** for a specific data type (DB or File). | `CustomerRepoDB.cs`, `CustomerRepository.cs` | ADO.NET (`SqlConnection`) or `System.IO` (Files) |
| **5. Model** | Simple data-holding classes (**POCOs**). | `CustomerModel.cs`, `ProductModel.cs` | N/A |

### Key Development Learnings

* **Handling Identity:** Implemented logic using `SELECT SCOPE_IDENTITY()` and `ExecuteScalar()` in the `Create` method to immediately retrieve and assign the auto-generated database `CustomerID` to the C# `CustomerModel` object.
* **Varchar Search Robustness:** Ensured robust string matching for `varchar` database columns (like **Phone Number**) by implementing input cleaning (stripping spaces, dashes) in the UI before executing the SQL query, preventing search failures.

---

## 🚀 Getting Started

### Prerequisites

1.  **C# and .NET Framework:** Ensure you have the required .NET environment installed.
2.  **SQL Server Instance:** A running SQL Server instance (or equivalent) for primary data storage.
3.  **Database Configuration:** You must manually create the `Customer`, `Product`, and `Order` tables in your database before running.

### Installation and Setup

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/YOUR_USERNAME/ShopManagementSystem.git](https://github.com/YOUR_USERNAME/ShopManagementSystem.git)
    cd ShopManagementSystem
    ```

2.  **Update Connection String:**
    * Locate the `Utils.DBConnection()` method (or equivalent configuration file).
    * Update the connection string to point to your local SQL Database.

3.  **Run the project:**
    ```bash
    dotnet run
    ```

---

## 📜 Coding Guidelines

This project was developed under a strict set of guidelines:

* **Accessor Methods:** Data models use private backing fields with public `Get...()` and `Set...()` methods (no auto-properties).
* **Control Flow:** Menu and logic branching are handled exclusively with `if-else if-else` blocks (no `switch` statements).
* **Organization:** Strict separation of classes into individual files, organized by feature folders.
* **Naming Conventions:** Adherence to standard C# Naming Conventions (`PascalCase` for classes/methods, `camelCase` for local variables/parameters).