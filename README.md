# Shopping Cart

A desktop shopping cart application built with C# Windows Forms and Microsoft SQL Server. It provides a user-friendly login/registration experience, product catalog browsing with search and filters, a shopping cart, and a checkout flow. An admin dashboard is included for managing products and orders.

## Features

- **User Authentication**
  - Login and registration forms
  - Admin login with default credentials
  - Password validation and SQL injection-safe queries

- **Product Catalog**
  - Browse products by category
  - Search products by name
  - Product cards with images, pricing, discounts, and special offers
  - Product detail view with image gallery
  - Add products to cart with quantity selection

- **Shopping Cart**
  - View cart items
  - Update quantities
  - Remove items
  - Cart total calculation

- **Checkout**
  - Payment details form (name, card number, expiry, CVV)
  - Order placement flow

- **Admin Dashboard**
  - Manage products and view orders
  - Data grid views connected to the SQL Server database

## Technology Stack

- **Language:** C#
- **Framework:** .NET Framework 4.7.2
- **UI:** Windows Forms (WinForms)
- **Database:** Microsoft SQL Server (SQL Server Express)
- **Data Access:** ADO.NET with `Microsoft.Data.SqlClient`
- **IDE:** Visual Studio 2022 (recommended)

## Project Structure

```
Shopping_Cart/
├── Shopping_Cart/
│   ├── Authentication.cs          # Login / registration form
│   ├── Dashboard.cs               # Admin dashboard form
│   ├── ProductCatalog.cs          # Main shopping catalog, cart, and checkout form
│   ├── Program.cs                 # Application entry point
│   ├── App.config                 # .NET Framework runtime configuration
│   ├── packages.config            # NuGet package references
│   └── Properties/                # Assembly info, resources, settings
├── Shopping_Cart.slnx             # Solution file
└── README.md                      # This file
```

## Prerequisites

Before running the application, make sure you have the following installed:

1. **Visual Studio 2022** with the `.NET desktop development` workload
2. **.NET Framework 4.7.2**
3. **Microsoft SQL Server Express** or any SQL Server instance
4. A database named `Shopping_Cart` created on your SQL Server instance

## Database Setup

The application connects to a SQL Server database. The connection string is defined in the C# source files as:

```csharp
Server=DESKTOP-985956K\SQLEXPRESS;Database=Shopping_Cart;User ID=sa;Password=130506;TrustServerCertificate=True;
```

### Steps to configure

1. Open **SQL Server Management Studio (SSMS)** or Azure Data Studio.
2. Connect to your SQL Server instance.
3. Create a new database named `Shopping_Cart`.
4. Create the required tables. At minimum, the application expects:
   - `Users` table (for login/registration)
   - `Products` table (for product catalog)
   - `Orders` / `OrderDetails` tables (for checkout)
5. Update the connection string in the following files if your server name or credentials differ:
   - `Shopping_Cart/Authentication.cs`
   - `Shopping_Cart/Dashboard.cs`
   - `Shopping_Cart/ProductCatalog.cs`

> **Note:** The `sa` account password is hard-coded for local development only. For production or shared environments, use Windows Authentication or store the connection string securely in `App.config`.

## Default Login

Use the following credentials to log in as an admin:

- **Email:** `admin123@gmail.com`
- **Password:** `123456`

These credentials are prefilled automatically when the login form loads.

## How to Run

1. Clone or open the repository in **Visual Studio**.
2. Restore NuGet packages:
   - Right-click the solution in Solution Explorer and choose **Restore NuGet Packages**.
3. Ensure the SQL Server database is running and the `Shopping_Cart` database exists.
4. Update the connection strings if necessary.
5. Press **F5** or click **Start** to run the application.

## Build

- **Debug:** `bin\Debug\Shopping_Cart.exe`
- **Release:** `bin\Release\Shopping_Cart.exe`

## Dependencies

Key NuGet packages used in this project:

- `Microsoft.Data.SqlClient` — SQL Server data provider
- `System.Text.Json` — JSON serialization
- `System.Memory` — Span and memory primitives
- `Microsoft.Extensions.Caching.Memory` — In-memory caching
- `System.IdentityModel.Tokens.Jwt` — JWT token handling

See `packages.config` for the full list.

## Screenshots

Add application screenshots to the `png/` folder and reference them here:

```markdown
![Login Form](png/login.png)
![Product Catalog](png/catalog.png)
![Shopping Cart](png/cart.png)
```

## License

This project is for educational purposes.

## Author

Developed by Sophea Reaksa.
