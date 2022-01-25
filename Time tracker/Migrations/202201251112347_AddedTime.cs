namespace Time_tracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Todoes", "time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Todoes", "time");
        }
    }
}
