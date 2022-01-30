namespace Time_tracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _mig : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Todoes", new[] { "Text" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Todoes", "Text", unique: true);
        }
    }
}
