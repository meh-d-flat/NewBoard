namespace NewBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDbWithTestData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
SET IDENTITY_INSERT [dbo].[Catalogs] ON
INSERT INTO [dbo].[Catalogs] ([CatalogId], [Name]) VALUES (1, N'random')
SET IDENTITY_INSERT [dbo].[Catalogs] OFF

SET IDENTITY_INSERT [dbo].[Threads] ON
INSERT INTO [dbo].[Threads] ([ThreadId], [Catalog_CatalogId]) VALUES (1, 1)
SET IDENTITY_INSERT [dbo].[Threads] OFF

SET IDENTITY_INSERT [dbo].[Posts] ON
INSERT INTO [dbo].[Posts] ([PostId], [Thread_ThreadId], [Message], [Timestamp]) VALUES (1, 1, N'sup', N'2000-01-01 00:00:00')
INSERT INTO [dbo].[Posts] ([PostId], [Thread_ThreadId], [Message], [Timestamp]) VALUES (2, 1, N'hi', N'2000-01-01 00:01:00')
SET IDENTITY_INSERT [dbo].[Posts] OFF
");
        }

        public override void Down()
        {
            Sql("TRUNCATE TABLE Posts");
            Sql("TRUNCATE TABLE Threads");
            Sql("TRUNCATE TABLE Catalogs");
        }
    }
}
