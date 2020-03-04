-- SQL Script to add tables and stored procedures
-- NOTE: You'll need your own SQL database for this to work
-- Run this only after you have created a database in SQL Server

-- Create Veggie table
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Veggie](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Price] [decimal](5, 2) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Veggie] ADD  CONSTRAINT [PK_Veggie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO

-- Create Stored Procedures

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Alex Barke
-- Description: Get all veggies
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetVeggies]
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

SELECT [Id]
      ,[Name]
      ,[Price]
  FROM [dbo].[Veggie]
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Alex Barke
-- Description: Get a veggie by its Id
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetVeggieById]
@Id uniqueidentifier
AS
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON
	SELECT TOP(1) [Id], [Name], [Price] FROM dbo.[Veggie] WHERE [Id] = @Id
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Alex Barke
-- Description: Inserts one veggie
-- =============================================
CREATE PROCEDURE [dbo].[SP_InsertVeggie]
@Id uniqueidentifier,
@Name varchar(50),
@Price decimal(5,2)
AS
INSERT INTO [dbo].[Veggie]
     VALUES
           (@Id
           ,@Name
           ,@Price)

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:     Alex Barke
-- Description: Updates a veggie's name and price by its Id
-- =============================================
CREATE PROCEDURE [dbo].[SP_UpdateVeggie]
@Id uniqueidentifier,
@Name varchar(50),
@Price decimal(5,2)
AS
	UPDATE dbo.[Veggie]
	SET [Name] = @Name, [Price] = @Price
	WHERE [Id] = @Id

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:     Alex Barke
-- Description: Delete a veggie by it's Id
-- =============================================
CREATE PROCEDURE [dbo].[SP_DeleteVeggie]
@Id uniqueidentifier
AS
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    --SET NOCOUNT ON
	DELETE FROM dbo.[Veggie]
	WHERE [Id] = @Id
GO





