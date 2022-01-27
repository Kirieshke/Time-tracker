namespace Time_tracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDbWithDedlain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Todoes", "Description", c => c.String());
            AddColumn("dbo.Todoes", "Deadline", c => c.DateTime(nullable: false));
            AddColumn("dbo.Todoes", "StartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Todoes", "time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Todoes", "time", c => c.DateTime(nullable: false));
            DropColumn("dbo.Todoes", "StartDate");
            DropColumn("dbo.Todoes", "Deadline");
            DropColumn("dbo.Todoes", "Description");
        }
    }
}
