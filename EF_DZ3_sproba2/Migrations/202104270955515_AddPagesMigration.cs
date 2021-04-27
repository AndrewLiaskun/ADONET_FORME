namespace EF_DZ3_sproba2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPagesMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Pages", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Pages");
        }
    }
}
