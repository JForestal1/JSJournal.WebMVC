namespace JSJournal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedOwnerID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artifact", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.FollowUp", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.FollowUpStatusType", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Interview", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.PostInterview", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.SourceType", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.StatusType", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StatusType", "OwnerId");
            DropColumn("dbo.SourceType", "OwnerId");
            DropColumn("dbo.PostInterview", "OwnerId");
            DropColumn("dbo.Interview", "OwnerId");
            DropColumn("dbo.FollowUpStatusType", "OwnerId");
            DropColumn("dbo.FollowUp", "OwnerId");
            DropColumn("dbo.Artifact", "OwnerId");
        }
    }
}
