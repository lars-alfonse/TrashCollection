namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddayanduserAddressjunction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAddressDayJunctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day_Id = c.Int(),
                        UserAddress_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DayOfWeeks", t => t.Day_Id)
                .ForeignKey("dbo.UserAddressJunctions", t => t.UserAddress_ID)
                .Index(t => t.Day_Id)
                .Index(t => t.UserAddress_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAddressDayJunctions", "UserAddress_ID", "dbo.UserAddressJunctions");
            DropForeignKey("dbo.UserAddressDayJunctions", "Day_Id", "dbo.DayOfWeeks");
            DropIndex("dbo.UserAddressDayJunctions", new[] { "UserAddress_ID" });
            DropIndex("dbo.UserAddressDayJunctions", new[] { "Day_Id" });
            DropTable("dbo.UserAddressDayJunctions");
        }
    }
}
