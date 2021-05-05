namespace JSJournal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tweakstoLead : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lead", "CoverID", c => c.Int());
            AddColumn("dbo.Lead", "OtherArtifactID", c => c.Int());
            CreateIndex("dbo.Lead", "CoverID");
            CreateIndex("dbo.Lead", "OtherArtifactID");
            AddForeignKey("dbo.Lead", "CoverID", "dbo.Artifact", "ArtifactID");
            AddForeignKey("dbo.Lead", "OtherArtifactID", "dbo.Artifact", "ArtifactID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lead", "OtherArtifactID", "dbo.Artifact");
            DropForeignKey("dbo.Lead", "CoverID", "dbo.Artifact");
            DropIndex("dbo.Lead", new[] { "OtherArtifactID" });
            DropIndex("dbo.Lead", new[] { "CoverID" });
            DropColumn("dbo.Lead", "OtherArtifactID");
            DropColumn("dbo.Lead", "CoverID");
        }
    }
}
