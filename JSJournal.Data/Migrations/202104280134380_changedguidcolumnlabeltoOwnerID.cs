namespace JSJournal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedguidcolumnlabeltoOwnerID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lead", "CoverID", "dbo.Artifact");
            DropForeignKey("dbo.Lead", "OtherArtifactID", "dbo.Artifact");
            DropIndex("dbo.Lead", new[] { "CoverID" });
            DropIndex("dbo.Lead", new[] { "OtherArtifactID" });
            AddColumn("dbo.Lead", "OwnerID", c => c.Guid(nullable: false));
            AddColumn("dbo.Lead", "Role", c => c.String());
            DropColumn("dbo.Lead", "guid");
            DropColumn("dbo.Lead", "CoverID");
            DropColumn("dbo.Lead", "OtherArtifactID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lead", "OtherArtifactID", c => c.Int());
            AddColumn("dbo.Lead", "CoverID", c => c.Int());
            AddColumn("dbo.Lead", "guid", c => c.Guid(nullable: false));
            DropColumn("dbo.Lead", "Role");
            DropColumn("dbo.Lead", "OwnerID");
            CreateIndex("dbo.Lead", "OtherArtifactID");
            CreateIndex("dbo.Lead", "CoverID");
            AddForeignKey("dbo.Lead", "OtherArtifactID", "dbo.Artifact", "ArtifactID");
            AddForeignKey("dbo.Lead", "CoverID", "dbo.Artifact", "ArtifactID");
        }
    }
}
