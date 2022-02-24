namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unknown : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "OrderName", c => c.String(maxLength: 64));
            AddColumn("dbo.Order", "OrderDescription", c => c.String());
            DropColumn("dbo.Order", "ItemName");
            DropColumn("dbo.Order", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "Description", c => c.String());
            AddColumn("dbo.Order", "ItemName", c => c.String(maxLength: 64));
            DropColumn("dbo.Order", "OrderDescription");
            DropColumn("dbo.Order", "OrderName");
        }
    }
}
