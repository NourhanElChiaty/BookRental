namespace BookRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "BookId", "dbo.Books");
            DropIndex("dbo.Customers", new[] { "BookId" });
            DropColumn("dbo.Customers", "BookId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "BookId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "BookId");
            AddForeignKey("dbo.Customers", "BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
    }
}
