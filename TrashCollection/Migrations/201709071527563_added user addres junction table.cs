namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeduseraddresjunctiontable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAddressJunctions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ApplictionUserID = c.Int(nullable: false),
                        AddressModelID = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Address_ID = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AddressModels", t => t.Address_ID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Address_ID)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAddressJunctions", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserAddressJunctions", "Address_ID", "dbo.AddressModels");
            DropIndex("dbo.UserAddressJunctions", new[] { "User_Id" });
            DropIndex("dbo.UserAddressJunctions", new[] { "Address_ID" });
            DropTable("dbo.UserAddressJunctions");
        }
    }
}
