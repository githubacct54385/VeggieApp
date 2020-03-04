-- If you want to seed the database, you can use this script
-- Use this after running the CreateDb.sql script if you like

-- Clear the Veggie table
DELETE FROM [dbo].[Veggie];
GO

-- Insert rows into Veggie table
INSERT INTO [dbo].[Veggie]
VALUES (NEWID(), N'Cucumber', 3.45)

INSERT INTO [dbo].[Veggie]
VALUES (NEWID(), N'Radish', 4.32)

INSERT INTO [dbo].[Veggie]
VALUES (NEWID(), N'Leek', 5.00)

INSERT INTO [dbo].[Veggie]
VALUES (NEWID(), N'Beet', 6.23)

INSERT INTO [dbo].[Veggie]
VALUES (NEWID(), N'Cabbage', 1.75)

INSERT INTO [dbo].[Veggie]
VALUES (NEWID(), N'Arugula', 4.32)