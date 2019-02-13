namespace OrderaTaskVersion2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionRecordToModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategories", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Products", "ProductDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ProductDescription");
            DropColumn("dbo.ProductCategories", "Description");
        }
    }
}
