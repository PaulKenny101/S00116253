namespace RAD302CA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trip",
                c => new
                    {
                        TripId = c.Int(nullable: false, identity: true),
                        TripName = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        TripViable = c.Boolean(nullable: false),
                        TripComplete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TripId);
            
            CreateTable(
                "dbo.Leg",
                c => new
                    {
                        LegId = c.Int(nullable: false, identity: true),
                        StartLocation = c.String(nullable: false),
                        EndLocation = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        TripId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LegId)
                .ForeignKey("dbo.Trip", t => t.TripId, cascadeDelete: true)
                .Index(t => t.TripId);
            
            CreateTable(
                "dbo.Guest",
                c => new
                    {
                        GuestId = c.Int(nullable: false, identity: true),
                        GuestnName = c.String(),
                        Leg_LegId = c.Int(),
                    })
                .PrimaryKey(t => t.GuestId)
                .ForeignKey("dbo.Leg", t => t.Leg_LegId)
                .Index(t => t.Leg_LegId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Guest", new[] { "Leg_LegId" });
            DropIndex("dbo.Leg", new[] { "TripId" });
            DropForeignKey("dbo.Guest", "Leg_LegId", "dbo.Leg");
            DropForeignKey("dbo.Leg", "TripId", "dbo.Trip");
            DropTable("dbo.Guest");
            DropTable("dbo.Leg");
            DropTable("dbo.Trip");
        }
    }
}
