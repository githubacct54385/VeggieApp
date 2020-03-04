# Veggie App

## Inventory Management system for Veggies

## Architecture

Backend: DotNet Core Web API

Client: Create-React-App

CSS: React inline styles, styled components, and some .css files

Database: SQL Server

This app functions as an SPA (Single Page Application) that communicates with the Backend through HTTP requests.

The backend makes requests to the database using Dapper, a micro ORM based on ADO<span></span>.NET. I prefer it compared to Entity framework.

All communication with the database is done through stored procedures for security and performance purposes.

## Database configuration!!!

#### Please don't skip this section

For security purposes, I have not included the connection string in the app. You'll need to provide your own.

In the root directory (VeggieApp), add a file `connectionStrings.json`

This file is already added to the `.gitignore` file.

Inside, place the following and replace the `Default` value with your connection string to Microsoft SQL Server:

```
{
  "ConnectionStrings": {
    "Default": "<YOUR_SQL_CONNECTION_STRING>"
  }
}

```

For my development, I used a managed SQL Server hosted on Azure. But you can use a local installation of your choice.

## Install Instructions

1. Clone the repo

```
$ git clone https://github.com/githubacct54385/VeggieApp.git
```

2. Run init<span></span>.sh inside the **VeggieApp** folder.

```
$ ./init.sh
```

This will install all dependencies for npm and dotnet core.
