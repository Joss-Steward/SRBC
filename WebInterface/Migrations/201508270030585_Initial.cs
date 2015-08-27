namespace WebInterface.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Samples",
                c => new
                    {
                        SampleId = c.Long(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Temperature = c.Double(nullable: false),
                        SC = c.Double(nullable: false),
                        PH = c.Double(nullable: false),
                        Turbidity = c.Double(nullable: false),
                        Oxygen = c.Double(nullable: false),
                        Station_StationId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.SampleId)
                .ForeignKey("dbo.Stations", t => t.Station_StationId, cascadeDelete: true)
                .Index(t => t.Station_StationId);
            
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        StationId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.StationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Samples", "Station_StationId", "dbo.Stations");
            DropIndex("dbo.Samples", new[] { "Station_StationId" });
            DropTable("dbo.Stations");
            DropTable("dbo.Samples");
        }
    }
}
