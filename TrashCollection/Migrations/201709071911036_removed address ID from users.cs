namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedaddressIDfromusers : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "AddressID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "AddressID", c => c.Int(nullable: false));
        }
    }
}
