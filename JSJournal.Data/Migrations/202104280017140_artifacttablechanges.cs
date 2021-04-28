namespace JSJournal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class artifacttablechanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artifact", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Artifact", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artifact", "ModifiedUtc");
            DropColumn("dbo.Artifact", "CreatedUtc");
        }
    }
}
