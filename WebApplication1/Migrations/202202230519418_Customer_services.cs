namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customer_services : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustId = c.Int(nullable: false, identity: true),
                        CustName = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.CustId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        orderId = c.Int(nullable: false, identity: true),
                        orderItemName = c.String(),
                        orderDesc = c.String(),
                    })
                .PrimaryKey(t => t.orderId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
            DropTable("dbo.Customer");
        }
    }
}
