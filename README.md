#  LarmoireArt (.NET MVC)

**LarmoireArt** is a full-featured web application built using **ASP.NET Core MVC** and **Entity Framework Core**. This project simulates an online art wardrobe platform, allowing users to view, browse, and interact with artistic content while administrators can manage products and user accounts via a secure interface.

---

##  Project Overview

LarmoireArt provides a structured MVC (Model-View-Controller) architecture. The front-end is dynamically rendered using Razor Views, while the backend is powered by C# with database integration through Entity Framework Core.

---

##  Features

###  User Side
- View available art products
- Browse details of individual items
- Add items to their personal list (e.g., cart or favorites depending on implementation)

###  Admin Side
- Add, edit, delete art items
- Manage orders (if implemented)

---

##  Technologies Used

- **Framework:** ASP.NET Core MVC (.NET 6+)
- **Language:** C#
- **ORM:** Entity Framework Core
- **Database:** SQL Server (local or Azure)
- **Front-end:** Razor Views, HTML5, CSS3
- **IDE:** Visual Studio 2022 or later

---

##  Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/your-username/larmoireart-dotnet.git
cd larmoireart-dotnet/LarmoireArt
```

### 2. Set up the database

Make sure to:
- Configure your connection string in `appsettings.json`
- Apply EF Core migrations:

```bash
dotnet ef database update
```

### 3. Run the application

```bash
dotnet run
```

Then visit `https://localhost:5001` or the port shown in the terminal.

---

##  Author

- **Name:** Bouhraoua Sami  
- **Email:** samibouhraoua5@gmail.com  
- **Status:** Full-Stack Web & Mobile Developer  
- **Year:** 2025  

---

##  Educational Objective

This project was developed to:
- Learn MVC architecture in .NET
- Implement user and admin authentication
- Practice database integration with Entity Framework Core
- Build a complete and structured ASP.NET Core web app

