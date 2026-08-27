# 🛒 ShopMart - Shopping Cart & Store Management System

A modern, full-featured desktop E-Commerce Shopping Cart and Store Management application built with **C# Windows Forms**, **.NET Framework 4.7.2**, and **Microsoft SQL Server**.

It features a sleek purple/violet UI theme, user authentication, responsive multi-column product catalog browsing, live shopping cart and order tracking, Bakong KHQR & Card payments, a complete **Stock & Inventory Management System**, interactive analytics reports with MSChart, and an **Intelligent Groq AI Admin Assistant**.

---

## ✨ Key Features

### 🔐 User Authentication & Role-Based Access
- **User Registration & Login** with client-side and server-side validation.
- **Admin Access**: Automatic administrator role detection with seamless access to the Admin Dashboard.
- **Session Management**: Persistent tracking of active `UserId`, `UserName`, `UserEmail`, and roles across forms.

### 📦 Stock & Inventory Management
- **Live Inventory Tracking**: Every product tracks real-time available stock quantities (`Stock`).
- **Dynamic Stock Badges**:
  - 🟢 **In Stock**: Displays available quantity count (e.g., `Stock: 25`).
  - 🟠 **Low Stock Alert**: Highlights products with $\le 5$ items remaining (e.g., `Only 3 left!`).
  - 🔴 **Out of Stock**: Displays out-of-stock badge and automatically disables the "Add to Cart" button.
- **Quantity Selector Capping**: The product detail quantity selector dynamically caps at available stock (`numQuantity.Maximum = Stock`).
- **Pre-Checkout Stock Validation**: Re-checks live database stock before allowing checkout to prevent overdrafts.
- **Automated Stock Deduction**: Automatically decrements product stock from SQL Server upon order payment completion.

### 🛍️ Customer Catalog & Shopping Experience
- **Responsive Multi-Card Layout**: Displays responsive product cards per row with dynamic scaling on larger displays.
- **Category Filtering**: Instant category navigation:
  - 🛒 All Products
  - 🔌 Electronics
  - 👗 Fashion
  - 🏠 Home & Living
  - 🏀 Sports
  - 📚 Books
- **Live Search**: Real-time search filtering by product name.
- **Product Card Previews**: High-resolution image zoom, title, formatted price, discount calculation, and special offer tags.
- **Product Detail Gallery**: Multi-image thumbnail gallery support (up to 4 images per product) with zoom preview.

### 🛒 Shopping Cart & Checkout
- **Interactive Cart**: Real-time quantity adjustments, price recalculations, and item removals.
- **Live Price Calculation**: Automatic computation of unit discounts, special offer percentages, and total costs.
- **Checkout Modal**: Collects customer shipping information (Phone, City, Delivery Address).

### 💳 Dual Payment Gateway (Bakong KHQR & Credit Card)
- **Bakong KHQR Payment**:
  - Generates live KHQR QR codes via payment API for instant mobile scanning with any Bakong-supported banking app.
  - Automated background polling timer verifies transaction completion in real-time.
- **Credit / Debit Card Payment**:
  - Cardholder validation (Name, Card Number, Expiry, CVV).
- **Automated Receipt / Invoice**: Generates a detailed order invoice with unique transaction IDs upon payment completion.

### 📊 Admin Dashboard & Store Analytics
- **Live Real-Time Metric Stat Cards**:
  - 🟢 **Total Sales**: Real-time revenue sum of paid/pending orders.
  - 🔵 **Total Orders**: Total volume of customer orders.
  - 🟠 **Total Products**: Count of catalog products.
  - 🔴 **Total Customers**: Count of registered user accounts.
- **Product CRUD Management**:
  - Add, Update, and Delete products with multi-image browsing (`Image1` – `Image4`).
  - Stock quantity input validation and auto-calculation of final price from original price and special offers.
  - Clean data table presentation (internal file paths hidden from the grid for optimal readability).
- **Customer & Order Management**: Drill down into customer orders, shipping details, and individual line items.
- **Interactive Visual Reports & Charts**:
  - **Sales Report**: Revenue trends and order volumes over time.
  - **Order Status Breakdown**: Visual distribution of `Paid`, `Pending`, and `Cancelled` orders.
  - **Top Products**: Best-selling items by revenue and quantity.
  - **Top Customers**: Highest-spending customer rankings.
  - **Activity Log**: Audit log of product creations, updates, and deletions.

### 🤖 Groq AI Admin Assistant
- Integrated AI Store Assistant powered by **Groq Cloud API** (supporting `openai/gpt-oss-120b`, `llama-3.3-70b-versatile`, etc.).
- Natural language database analysis and automated SQL generation/execution.
- Quick prompt chips for common queries:
  - 📈 Sales & revenue breakdown
  - 👥 Top customer spenders
  - 🏷️ Discounted products & special offers
  - 📦 Low stock & inventory queries
  - 📋 System activity logs

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
- **Charting Engine:** Microsoft Chart Controls (`System.Windows.Forms.DataVisualization.Charting`)
- **AI Integration:** Groq REST API (`HttpClient` + `System.Text.Json`)
- **IDE:** Visual Studio 2022

---

## 📁 Project Structure

```
Shopping_Cart/
├── Shopping_Cart/
│   ├── Authentication.cs          # Login and user registration form & logic
│   ├── Authentication.Designer.cs # Authentication UI design
│   ├── Dashboard.cs               # Admin dashboard, product CRUD, orders, reports & AI chat
│   ├── Dashboard.Designer.cs      # Dashboard UI layout, styled stat cards & AI panel
│   ├── ProductCatalog.cs          # Customer storefront, cart, details, checkout & payment
│   ├── ProductCatalog.Designer.cs # Catalog layout, product cards & payment tabs
│   ├── GroqChatService.cs         # Groq AI chatbot integration & schema prompt
│   ├── Program.cs                 # Application entry point
│   ├── App.config                 # Database connection strings & runtime config
│   ├── packages.config            # NuGet dependencies
│   └── Properties/                # Assembly metadata and resources
├── Shopping_Cart.slnx             # Solution configuration file
└── README.md                      # Project documentation
```

---

## 🗄️ Database Setup

### 1. Create the Database & Tables
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
    Stock INT NOT NULL DEFAULT 0,
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

-- 4. OrderItems Table
CREATE TABLE OrderItems (
    OrderItemId INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NOT NULL FOREIGN KEY REFERENCES Orders(OrderId) ON DELETE CASCADE,
    ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(ProductId),
    ProductName NVARCHAR(150),
    ProductImage NVARCHAR(500),
    ProductPrice DECIMAL(18,2) NOT NULL,
    Quantity INT NOT NULL,
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),
    OrderDate DATETIME DEFAULT GETDATE()
);

-- 5. Payments Table
CREATE TABLE Payments (
    PaymentId INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NOT NULL FOREIGN KEY REFERENCES Orders(OrderId),
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),
    TransactionId NVARCHAR(100),
    PaymentDate DATETIME DEFAULT GETDATE()
);

-- 6. ProductActivityLog Table
CREATE TABLE ProductActivityLog (
    LogId INT IDENTITY(1,1) PRIMARY KEY,
    ActionType NVARCHAR(50) NOT NULL,
    ProductName NVARCHAR(150) NOT NULL,
    ActionDate DATETIME DEFAULT GETDATE()
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

-- Sample Products with Initial Stock
INSERT INTO Products (ProductName, Category, Price, Discount, SpecialOffer, Stock, Image1, CreatedAt)
VALUES 
('ROG STRIX Laptop', 'Electronics', 1600.00, 1440.00, 10, 25, '', GETDATE()),
('Samsung Galaxy Phone', 'Electronics', 490.00, 490.00, 0, 40, '', GETDATE()),
('Spider Man Comic', 'Books', 15.00, 15.00, 0, 100, '', GETDATE()),
('Modern Living Sofa', 'Home & Living', 350.00, 315.00, 10, 15, '', GETDATE()),
('Nike Basketball Shoes', 'Sports', 120.00, 108.00, 10, 3, '', GETDATE());
GO
```

---

## ⚙️ Connection String Configuration

The database connection string is defined in the application source files:

```csharp
Server=[SERVERNAME]\SQLEXPRESS;Database=Shopping_Cart;User ID=sa;Password=[PASSWORD];TrustServerCertificate=True;
``` 

If your SQL Server instance name or credentials differ, update the connection string variable in:
- `Shopping_Cart/Authentication.cs`
- `Shopping_Cart/Dashboard.cs`
- `Shopping_Cart/ProductCatalog.cs`

---

## 🔑 Default Credentials

| Role | Email | Password | Access Level |
|---|---|---|---|
| **Admin** | `admin123@gmail.com` | `admin123` | Full access to Admin Dashboard, Product CRUD, Orders, Reports & AI Assistant |
| **Customer** | `john@example.com` | `123456` | Storefront catalog browsing, cart, checkout & payments |

*(Admin credentials are automatically pre-filled on the login screen for testing convenience.)*

---

## 🚀 How to Run

1. Open `Shopping_Cart.slnx` (or `Shopping_Cart.sln`) in **Visual Studio 2022**.
2. Ensure SQL Server is running and the `Shopping_Cart` database is set up.
3. Restore NuGet packages:
   - In Solution Explorer, right-click the solution and click **Restore NuGet Packages**.
4. Press **F5** or click **Start (Debug)** to run the application.

---

## 📦 Dependencies

- `Microsoft.Data.SqlClient` (v5.2.2+)
- `System.Text.Json` (v8.0.5+)
- `System.Memory` (v4.5.5)
- `Microsoft.Extensions.Caching.Memory` (v8.0.1)
- `System.Windows.Forms.DataVisualization` (MSChart)

---

## 👤 Author

Developed by **Sophea Reaksa**.
