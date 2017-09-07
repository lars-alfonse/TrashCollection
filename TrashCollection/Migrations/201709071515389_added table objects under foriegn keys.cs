namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtableobjectsunderforiegnkeys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AddressID", c => c.Int(nullable: false));
            CreateIndex("dbo.AddressModels", "CitiesID");
            CreateIndex("dbo.AddressModels", "ZipCodeID");
            CreateIndex("dbo.Cities", "StatesID");
            AddForeignKey("dbo.Cities", "StatesID", "dbo.States", "StatesID", cascadeDelete: true);
            AddForeignKey("dbo.AddressModels", "CitiesID", "dbo.Cities", "CitiesID", cascadeDelete: true);
            AddForeignKey("dbo.AddressModels", "ZipCodeID", "dbo.ZipCodes", "ZipCodeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AddressModels", "ZipCodeID", "dbo.ZipCodes");
            DropForeignKey("dbo.AddressModels", "CitiesID", "dbo.Cities");
            DropForeignKey("dbo.Cities", "StatesID", "dbo.States");
            DropIndex("dbo.Cities", new[] { "StatesID" });
            DropIndex("dbo.AddressModels", new[] { "ZipCodeID" });
            DropIndex("dbo.AddressModels", new[] { "CitiesID" });
            DropColumn("dbo.AspNetUsers", "AddressID");
        }
    }
}
