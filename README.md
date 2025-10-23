# Shop Management System (C# Console App)

A console-based application for managing a shop's products, customers, and sales, built with C# and .NET. This project demonstrates professional OOP principles, a layered architecture, and strict adherence to coding standards.

![Shop Management System UI Screenshot](https://i.imgur.com/gKj8V5c.png)

## 📋 Features

* **Product Management:** Add, update, delete, and view all products.
* **Customer Management:** Add new customers and view all registered customers.
* **Sales System:** Create new sales orders by selecting a customer (or creating a new one) and adding products.
* **Order History:** View a complete history of all past orders, or filter orders by a specific customer.
* **Persistent Storage:** All data (products, customers, orders) is loaded from local `.txt` files at startup and saved back to them on exit.
* **Attractive UI:** The console is enhanced with colors for a more user-friendly experience.

## 🏛️ Project Architecture (Layered Facade)

This project uses a professional, layered architecture that separates concerns, making the code clean, maintainable, and easy to test.

The project is organized into feature folders (`Product`, `Customer`, `Order`) and a `Core` (the root).

1.  **UI Layer (`...UI.cs` files):**
    * Responsible *only* for displaying menus and handling user input.
    * Gets all its data from the `Shop` facade.
    * **Example:** `ProductUI.cs`, `CustomerUI.cs`, `OrderUI.cs`.

2.  **Facade Layer (`Shop.cs`):**
    * Acts as a single, simple "manager" or "entry point" for the UI layer.
    * The UI classes *only* talk to this `Shop.cs` file.
    * It delegates all work requests to the appropriate service.

3.  **Service Layer (`...Service.cs` files):**
    * Contains all the business logic. Each service is a "mini-brain" for its feature.
    * **Example:** `ProductService.cs` (manages product logic), `CustomerService.cs` (manages customer logic).

4.  **Repository Layer (`...Repository.cs` files):**
    * Responsible *only* for data access.
    * Its job is to read from and write to the `.txt` files.
    * **Example:** `ProductRepository.cs` (handles `products.txt`).

5.  **Model Layer (`...Model.cs` files):**
    * Simple data-holding classes (POCOs) that represent our data.
    * **Example:** `ProductModel.cs`, `CustomerModel.cs`.

### Flow of Control

`Program.cs` ➡️ `...UI` (e.g., `ProductUI`) ➡️ `Shop.cs` (Facade) ➡️ `...Service` (e.g., `ProductService`) ➡️ `...Repository` (e.g., `ProductRepository`)

## 🚀 How to Run

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/YOUR_USERNAME/ShopManagementSystem.git](https://github.com/YOUR_USERNAME/ShopManagementSystem.git)
    cd ShopManagementSystem
    ```

2.  **Trust the Dev Certificate (Optional, but good practice):**
    ```bash
    dotnet dev-certs https --trust
    ```

3.  **Run the project:**
    ```bash
    dotnet run
    ```
    *Note: The program will automatically create `products.txt`, `customers.txt`, and `orders.txt` if they don't exist, as they are included in the project with "Copy if newer".*

## 📜 Coding Guidelines

This project was built to a strict set of academic and professional guidelines:

* **No `get; set;` Properties:** All data models (`ProductModel`, `CustomerModel`) use private backing fields with public `Get...()` and `Set...()` methods.
* **No `switch` Statements:** All menu and logic branching is handled exclusively with `if-else if-else` blocks.
* **File Organization:** Each class is in its own file, organized by feature.
* **Naming Conventions:** All class and method names are `PascalCase`, and all local variables are `camelCase`.
* **Brace Style:** The project uses the Allman brace style (braces on new lines).
