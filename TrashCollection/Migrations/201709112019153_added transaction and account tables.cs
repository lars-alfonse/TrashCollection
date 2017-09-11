namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtransactionandaccounttables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Balance = c.Double(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Payment = c.Double(),
                        Charges = c.Double(),
                        Balance = c.Double(nullable: false),
                        Account_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.Account_ID)
                .Index(t => t.Account_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Account_ID", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Transactions", new[] { "Account_ID" });
            DropIndex("dbo.Accounts", new[] { "User_Id" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Accounts");
        }
    }
}
