namespace BookRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Cust_FName", c => c.String());
            AddColumn("dbo.Customers", "Cust_LName", c => c.String());
            AddColumn("dbo.Customers", "Cust_BOD", c => c.String());
            DropColumn("dbo.Customers", "Cust_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Cust_Name", c => c.String());
            DropColumn("dbo.Customers", "Cust_BOD");
            DropColumn("dbo.Customers", "Cust_LName");
            DropColumn("dbo.Customers", "Cust_FName");
        }
    }
}
