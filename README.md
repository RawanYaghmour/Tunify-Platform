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

## 🚀 Getting Started

Follow the steps to set up and run the Tunify Platform:

1. **Install the required NuGet packages**:
   ```bash
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.20
   dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0.20
   dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 7.0.12
