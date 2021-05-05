namespace JSJournal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefinedInterviews : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Interview", "PostInterviewID", "dbo.PostInterview");
            DropForeignKey("dbo.Interview", "Lead_LeadID", "dbo.Lead");
            DropIndex("dbo.Interview", new[] { "PostInterviewID" });
            DropIndex("dbo.Interview", new[] { "Lead_LeadID" });
            RenameColumn(table: "dbo.Interview", name: "Lead_LeadID", newName: "LeadID");
            AddColumn("dbo.Interview", "PrimaryInterviewer", c => c.String());
            AddColumn("dbo.Interview", "SecondaryInterviewer", c => c.String());
            AlterColumn("dbo.Interview", "LeadID", c => c.Int(nullable: false));
            CreateIndex("dbo.Interview", "LeadID");
            AddForeignKey("dbo.Interview", "LeadID", "dbo.Lead", "LeadID", cascadeDelete: true);
            DropColumn("dbo.Interview", "PrimaryInterviwer");
            DropColumn("dbo.Interview", "SecondaryInterviwer");
            DropColumn("dbo.Interview", "PostInterviewID");
            DropTable("dbo.PostInterview");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PostInterview",
                c => new
                    {
                        PostInterviewID = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.PostInterviewID);
            
            AddColumn("dbo.Interview", "PostInterviewID", c => c.Int());
            AddColumn("dbo.Interview", "SecondaryInterviwer", c => c.String());
            AddColumn("dbo.Interview", "PrimaryInterviwer", c => c.String());
            DropForeignKey("dbo.Interview", "LeadID", "dbo.Lead");
            DropIndex("dbo.Interview", new[] { "LeadID" });
            AlterColumn("dbo.Interview", "LeadID", c => c.Int());
            DropColumn("dbo.Interview", "SecondaryInterviewer");
            DropColumn("dbo.Interview", "PrimaryInterviewer");
            RenameColumn(table: "dbo.Interview", name: "LeadID", newName: "Lead_LeadID");
            CreateIndex("dbo.Interview", "Lead_LeadID");
            CreateIndex("dbo.Interview", "PostInterviewID");
            AddForeignKey("dbo.Interview", "Lead_LeadID", "dbo.Lead", "LeadID");
            AddForeignKey("dbo.Interview", "PostInterviewID", "dbo.PostInterview", "PostInterviewID");
        }
    }
}
