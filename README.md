# Veggie App

## Inventory Management system for Veggies

## Architecture

Backend: DotNet Core Web API

Client: Create-React-App

CSS: React inline styles, styled components, and some .css files

Database: SQL Server (For development of this project, I've been using Azure SQL Database)

This app functions as an SPA (Single Page Application) that communicates with the Backend through HTTP requests.

The backend makes requests to the database using Dapper, a micro ORM based on ADO<span></span>.NET. I prefer it compared to Entity framework.

All communication with the database is done through stored procedures for security and performance purposes.

## Install Instructions

1. Clone the repo

```
$ git clone https://github.com/githubacct54385/VeggieApp.git
```

2. Run init<span></span>.sh inside the **root** folder.

```
$ chmod 755 ./init.sh # you may need to run this
$ ./init.sh # installs npm dependencies and builds project
```

3. Try out the app!
   Once you have run init<span>.sh</span>, you can use run<span>.sh</span>. This skips the npm install step.

```
$ chmod 755 ./run.sh # you may need to run this
$ ./run.sh # runs the app without npm install
```

This will install all dependencies for npm and dotnet core.  
It will then build the dotnet core app and run it.  
Beware that setting up the SQL Server is done by you.

## Database configuration!!!

#### Please don't skip this section

For security purposes, I have not included the connection string in the app. You'll need to provide your own.

In the root directory, add a file `connectionStrings.json`

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

## Seeding the Database

#### Creating the schema

The schema for the database is located in the `/SQL` folder.  
Please run `CreateDb.sql` to create the table and stored procedures. Do this after you create the database in SQL Server.

#### Seeding the database

You can seed the database by using the sql in `SeedDb.sql`.

#### Dropping tables and stored procedures

You may drop all tables and stored procedures using `DropDb.sql`

## Deployment

This app can be setup for deployment by modifying an existing shell script or creating a new one.  
If I were to deploy this I would look to Heroku or Azure App Service since I have the most experience working with them.
