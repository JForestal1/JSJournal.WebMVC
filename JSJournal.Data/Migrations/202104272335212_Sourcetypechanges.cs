namespace JSJournal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sourcetypechanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SourceType", "Source", c => c.String());
            DropColumn("dbo.SourceType", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SourceType", "Status", c => c.String());
            DropColumn("dbo.SourceType", "Source");
        }
    }
}
