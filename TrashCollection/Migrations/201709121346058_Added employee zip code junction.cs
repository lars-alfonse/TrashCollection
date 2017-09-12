namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedemployeezipcodejunction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeZipJunctions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        User_Id = c.String(maxLength: 128),
                        ZipCode_ZipCodeID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.ZipCodes", t => t.ZipCode_ZipCodeID)
                .Index(t => t.User_Id)
                .Index(t => t.ZipCode_ZipCodeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeZipJunctions", "ZipCode_ZipCodeID", "dbo.ZipCodes");
            DropForeignKey("dbo.EmployeeZipJunctions", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.EmployeeZipJunctions", new[] { "ZipCode_ZipCodeID" });
            DropIndex("dbo.EmployeeZipJunctions", new[] { "User_Id" });
            DropTable("dbo.EmployeeZipJunctions");
        }
    }
}
