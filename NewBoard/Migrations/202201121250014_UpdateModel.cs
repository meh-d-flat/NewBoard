namespace NewBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Catalogs", "Name", c => c.String());
            AddColumn("dbo.Posts", "Message", c => c.String(nullable: false));
            AddColumn("dbo.Posts", "Timestamp", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Timestamp");
            DropColumn("dbo.Posts", "Message");
            DropColumn("dbo.Catalogs", "Name");
        }
    }
}
