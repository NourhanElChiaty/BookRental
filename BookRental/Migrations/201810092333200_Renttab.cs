namespace BookRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Renttab : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Rentals", new[] { "Book_Id" });
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            DropTable("dbo.Rentals");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(),
                        Book_Id = c.Int(),
                        Customer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Rentals", "Customer_Id");
            CreateIndex("dbo.Rentals", "Book_Id");
            AddForeignKey("dbo.Rentals", "Customer_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Rentals", "Book_Id", "dbo.Books", "Id");
        }
    }
}
