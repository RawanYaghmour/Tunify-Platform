# 🎵 Tunify Platform 🎵

Welcome to the Tunify Platform, a web application designed to bring your music experience to the next level! This platform allows users to manage their music collections, including songs, albums, artists, playlists, and subscriptions.

## 📚 Overview

Tunify integrates seamlessly with a database to store and manage music data. This README will guide you through the structure of the application, its database schema, and the relationships between different entities.

## 🗂 ERD Diagram

Below is the Entity Relationship Diagram (ERD) for the Tunify Platform:

![Tunify ERD Diagram](https://github.com/RawanYaghmour/Tunify-Platform/blob/Tunify/Tunify.png)

## 🔗 Entity Relationships

### User 👤
- **User** can have multiple **Subscriptions**.
- **User** can create multiple **Playlists**.

### Subscription 📄
- **Subscription** is linked to one **User**.

### Playlist 🎶
- **Playlist** can contain multiple **Songs**.
- **Playlist** belongs to one **User**.

### Song 🎵
- **Song** can be part of multiple **Playlists**.
- **Song** is performed by one **Artist**.
- **Song** is part of one **Album**.

### Artist 🎤
- **Artist** can have multiple **Songs**.
- **Artist** can have multiple **Albums**.

### Album 💿
- **Album** can contain multiple **Songs**.
- **Album** is created by one **Artist**.

## 📦 Repository Design Pattern

The Tunify Platform leverages the Repository Design Pattern to manage data access and operations. This pattern provides a layer of abstraction between the data access layer and the business logic layer of the application.

### 💡 What is the Repository Design Pattern?

The Repository Design Pattern is a software design pattern that mediates data access by abstracting the data source. It encapsulates the logic required to access the data source and provides a clean API to the rest of the application, ensuring that the data access code is kept separate from the business logic.

### ✨ Benefits of Using the Repository Design Pattern

- **Separation of Concerns**: By using the Repository Pattern, the data access logic is separated from the business logic, making the application easier to maintain and understand.

- **Testability**: The abstraction provided by the Repository Pattern allows for easier unit testing of the business logic by enabling the use of mock repositories.

- **Flexibility**: The Repository Pattern allows you to change the underlying data source without affecting the business logic. For example, switching from SQL Server to another database can be done with minimal changes to the repository layer.

- **Code Reusability**: The pattern encourages the reuse of common data access code, reducing duplication and increasing consistency across the application.

- **Simplified Data Access**: The Repository Pattern provides a clean and straightforward interface for data access, making it easier to perform CRUD (Create, Read, Update, Delete) operations.

By implementing the Repository Design Pattern in the Tunify Platform, we ensure that our application remains modular, maintainable, and adaptable to future changes.


## 🔐 Identity Setup

The Tunify Platform implements user authentication using ASP.NET Core Identity. This section outlines how to register, log in, and log out users.

### 📋 Registration

1. **Navigate to the Registration Page**:
   - Access the registration endpoint at `/Account/Register`.

2. **Fill in the Registration Form**:
   - Provide the following details:
     - **Username**
     - **Email**
     - **Password**

3. **Submit the Form**:
   - Click the "Register" button to create your account.

4. **Confirmation**:
   - If registration is successful, you will be redirected to the login page.

### 🔑 Login

1. **Navigate to the Login Page**:
   - Access the login endpoint at `/Account/Login`.

2. **Fill in the Login Form**:
   - Enter your **Username** and **Password**.

3. **Submit the Form**:
   - Click the "Login" button to authenticate.

4. **Access Granted**:
   - Upon successful login, you will be redirected to the main dashboard of the Tunify Platform.

### 🚪 Logout

1. **Initiate Logout**:
   - Click the "Logout" button available in the user menu or access the logout endpoint at `/Account/Logout`.

2. **Confirmation**:
   - You will be signed out and redirected to the home page.

### ⚠️ Error Handling

- If any error occurs during registration or login, appropriate messages will be displayed.
- Ensure to handle validation errors such as duplicate usernames or weak passwords.




## 🚀 Getting Started

Follow the steps to set up and run the Tunify Platform:

1. **Install the required NuGet packages**:
   ```bash
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.20
   dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0.20
   dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 7.0.12
