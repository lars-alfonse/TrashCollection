namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedaddressesstatesandsuch : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        addressLine = c.String(),
                        CitiesID = c.Int(nullable: false),
                        ZipCodeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CitiesID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        StatesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CitiesID);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StatesID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        abbreviation = c.String(),
                    })
                .PrimaryKey(t => t.StatesID);
            
            CreateTable(
                "dbo.ZipCodes",
                c => new
                    {
                        ZipCodeID = c.Int(nullable: false, identity: true),
                        zip = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ZipCodeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ZipCodes");
            DropTable("dbo.States");
            DropTable("dbo.Cities");
            DropTable("dbo.AddressModels");
        }
    }
}
