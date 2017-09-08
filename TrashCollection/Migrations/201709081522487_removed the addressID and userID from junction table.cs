namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedtheaddressIDanduserIDfromjunctiontable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserAddressJunctions", "ApplictionUserID");
            DropColumn("dbo.UserAddressJunctions", "AddressModelID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAddressJunctions", "AddressModelID", c => c.Int(nullable: false));
            AddColumn("dbo.UserAddressJunctions", "ApplictionUserID", c => c.Int(nullable: false));
        }
    }
}
