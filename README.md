# 🛒 ShopMart - Shopping Cart & Store Management System

A desktop E-Commerce Shopping Cart and Store Management application built with **C# Windows Forms**, **.NET Framework**, and **Microsoft SQL Server**.

It features a modern purple/violet UI theme, user authentication, responsive multi-column product catalog browsing (3 product cards per row), live shopping cart and order tracking, and a full-featured Admin Dashboard with real-time sales metrics, product CRUD operations, and reports.

---

## ✨ Features

### 🔐 User Authentication & Roles
- **User Registration & Login** with client-side and server-side validation.
- **Admin Access**: Automatic detection of administrator roles with access to the Admin Dashboard.
- **Session Management**: Tracks active `UserId` and user credentials across forms.

### 🛍️ Product Catalog & Shopping Experience
- **Responsive Multi-Card Layout**: Displays **3 product cards per row** at standard/minimum window sizes with dynamic scaling on larger displays.
- **Category Filtering**: Quickly filter products by category:
  - 🛒 All Products
  - 🔌 Electronics
  - 👗 Fashion
  - 🏠 Home & Living
  - 🏀 Sports
  - 📚 Books
- **Live Search**: Instant search filtering by product name.
- **Product Card Previews**: Displays product images with zoom mode, title, formatted price, discount calculation, and special offer tags.
- **Product Detail View**: Full multi-image gallery support (up to 4 images per product), quantity selectors, and product descriptions.

### 🛒 Shopping Cart & Order Management
- **Interactive Cart**: Add items directly with real-time quantity adjustments and item removals.
- **Live Price Calculation**: Automatic calculation of subtotal, discounts, and total cost.
- **Order Placement**: Checkout flow capturing customer shipping and contact details.
- **My Orders**: View order history, item breakdowns, and fulfillment status (`Pending`, `Paid`, `Completed`).

### 📊 Admin Dashboard & Store Analytics
- **Live Metric Stat Cards**:
  - 🟢 **Total Sales**: Real-time revenue sum of paid/pending orders.
  - 🔵 **Total Orders**: Total volume of customer orders.
  - 🟠 **Total Products**: Count of inventory items in catalog.
  - 🔴 **Total Customers**: Registered user accounts.
- **Product Management (CRUD)**:
  - Add, Update, and Delete products with multi-image file browsing (`Image1` – `Image4`).
  - Auto-calculation of final price from original price and special offer percentages.
  - Clean data table presentation (internal file paths hidden from the grid for optimal readability).
- **Customer & Order Management**: View all customer spending histories and drill down into individual order details.
- **Reports & Analytics**: Tabbed revenue analysis and performance charts.
- **Activity Logging**: System action logs tracked via `ActivityLogs`.

---

## 🎨 Theme & UI Design

| Component | Color Code | Description |
|---|---|---|
| **Header Panel** | `#3F2B68` | Deep Purple top navigation bar |
| **Sidebar Panel** | `#5B4495` | Royal Purple category menu bar |
| **Active Highlight** | `#765BB8` | Light Purple active state for navigation pills |
| **Total Sales Card** | `#22C55E` | Vibrant Green |
| **Total Orders Card** | `#38BDF8` | Bright Sky Blue |
| **Total Products Card** | `#F97316` | Orange |
| **Total Customers Card** | `#EF4444` | Red |
| **Background Canvas** | `#F5F6FA` | Clean light gray/lavender off-white |

---

## 🛠️ Technology Stack

- **Language:** C#
- **Platform:** Windows Forms (WinForms)
- **Framework:** .NET Framework 4.7.2
- **Database:** Microsoft SQL Server (SQL Server Express / Standard / Developer)
- **Data Provider:** ADO.NET (`Microsoft.Data.SqlClient`)
- **IDE:** Visual Studio 2022

---

## 📁 Project Structure

```
Shopping_Cart/
├── Shopping_Cart/
│   ├── Authentication.cs          # Login and user registration form & logic
│   ├── Authentication.Designer.cs # Authentication UI design
│   ├── Dashboard.cs               # Admin dashboard, product CRUD, orders & reports
│   ├── Dashboard.Designer.cs      # Dashboard UI layout & styled stat cards
│   ├── ProductCatalog.cs          # Customer catalog, cart, product details & checkout
│   ├── ProductCatalog.Designer.cs # Catalog layout, 3-card responsive grid & sidebar
│   ├── Program.cs                 # Application entry point
│   ├── App.config                 # Database connection strings & runtime config
│   ├── packages.config            # NuGet dependencies
│   └── Properties/                # Assembly metadata and resources
├── Shopping_Cart.slnx             # Solution configuration file
└── README.md                      # Project documentation
```

---

## 🗄️ Database Setup

### 1. Create the Database
Open **SQL Server Management Studio (SSMS)** or Azure Data Studio and run the following script:

```sql
CREATE DATABASE Shopping_Cart;
GO

USE Shopping_Cart;
GO

-- 1. Users Table
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    UserName NVARCHAR(100) NOT NULL,
    UserEmail NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- 2. Products Table
CREATE TABLE Products (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(150) NOT NULL,
    Category NVARCHAR(50) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    Discount DECIMAL(18,2) DEFAULT 0,
    SpecialOffer INT DEFAULT 0,
    Image1 NVARCHAR(500),
    Image2 NVARCHAR(500),
    Image3 NVARCHAR(500),
    Image4 NVARCHAR(500),
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- 3. Orders Table
CREATE TABLE Orders (
    OrderId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),
    OrderDate DATETIME DEFAULT GETDATE(),
    TotalCost DECIMAL(18,2) NOT NULL,
    OrderStatus NVARCHAR(50) DEFAULT 'Pending',
    UserPhone NVARCHAR(50),
    UserCity NVARCHAR(100),
    UserAddress NVARCHAR(255)
);

-- 4. OrderDetails Table
CREATE TABLE OrderDetails (
    OrderDetailId INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NOT NULL FOREIGN KEY REFERENCES Orders(OrderId) ON DELETE CASCADE,
    ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(ProductId),
    Quantity INT NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    Total DECIMAL(18,2) NOT NULL
);

-- 5. ActivityLogs Table
CREATE TABLE ActivityLogs (
    LogId INT IDENTITY(1,1) PRIMARY KEY,
    ActivityType NVARCHAR(100),
    Description NVARCHAR(500),
    Timestamp DATETIME DEFAULT GETDATE()
);
GO
```

### 2. Insert Initial Seed Data (Optional)

```sql
USE Shopping_Cart;
GO

-- Default Administrator & Demo Users
INSERT INTO Users (UserName, UserEmail, Password)
VALUES 
('Admin', 'admin123@gmail.com', '123456'),
('John Doe', 'john@example.com', '123456');

-- Sample Products
INSERT INTO Products (ProductName, Category, Price, Discount, SpecialOffer, Image1, CreatedAt)
VALUES 
('ROG STRIX Laptop', 'Electronics', 1600.00, 1440.00, 10, '', GETDATE()),
('Samsung Galaxy Phone', 'Electronics', 490.00, 490.00, 0, '', GETDATE()),
('Spider Man Comic', 'Books', 15.00, 15.00, 0, '', GETDATE()),
('Modern Living Sofa', 'Home & Living', 350.00, 315.00, 10, '', GETDATE());
GO
```

---

## ⚙️ Connection String Configuration

The database connection string is defined in the application source files:

```csharp
Server=[SERVERNAME]\SQLEXPRESS;Database=Shopping_Cart;User ID=sa;Password=[PASSWORD] TrustServerCertificate=True;
``` 

If your SQL Server instance name or credentials differ:
1. Open the project in Visual Studio.
2. Update the connection string variable in:
   - `Shopping_Cart/Authentication.cs`
   - `Shopping_Cart/Dashboard.cs`
   - `Shopping_Cart/ProductCatalog.cs`

---

## 🔑 Default Credentials

| Role | Email | Password |
|---|---|---|
| **Admin** | `admin123@gmail.com` | `admin123` |
| **Customer** | `john@example.com` | `123456` |

*(Admin credentials are automatically pre-filled on the login screen for testing convenience.)*

---

## 🚀 How to Run

1. Open `Shopping_Cart.slnx` (or `Shopping_Cart.sln`) in **Visual Studio 2022**.
2. Ensure SQL Server is running and the `Shopping_Cart` database is created.
3. Restore NuGet packages:
   - In Solution Explorer, right-click the solution and click **Restore NuGet Packages**.
4. Press **F5** or click **Start (Debug)** to run the application.

---

## 📦 Dependencies

- `Microsoft.Data.SqlClient` (v5.2.2+)
- `System.Text.Json` (v8.0.5+)
- `System.Memory` (v4.5.5)
- `Microsoft.Extensions.Caching.Memory` (v8.0.1)

---

## 👤 Author

Developed by **Sophea Reaksa**.
