namespace RAD302CA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Trip : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Guest", "GuestName", c => c.String());
            DropColumn("dbo.Guest", "GuestnName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Guest", "GuestnName", c => c.String());
            DropColumn("dbo.Guest", "GuestName");
        }
    }
}
