namespace JSJournal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCompanyToLead : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FollowUp", "Lead_LeadID", "dbo.Lead");
            DropIndex("dbo.FollowUp", new[] { "Lead_LeadID" });
            RenameColumn(table: "dbo.FollowUp", name: "Lead_LeadID", newName: "LeadID");
            AddColumn("dbo.Lead", "Company", c => c.String());
            AlterColumn("dbo.FollowUp", "DueUtc", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.FollowUp", "LeadID", c => c.Int(nullable: false));
            CreateIndex("dbo.FollowUp", "LeadID");
            AddForeignKey("dbo.FollowUp", "LeadID", "dbo.Lead", "LeadID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FollowUp", "LeadID", "dbo.Lead");
            DropIndex("dbo.FollowUp", new[] { "LeadID" });
            AlterColumn("dbo.FollowUp", "LeadID", c => c.Int());
            AlterColumn("dbo.FollowUp", "DueUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.Lead", "Company");
            RenameColumn(table: "dbo.FollowUp", name: "LeadID", newName: "Lead_LeadID");
            CreateIndex("dbo.FollowUp", "Lead_LeadID");
            AddForeignKey("dbo.FollowUp", "Lead_LeadID", "dbo.Lead", "LeadID");
        }
    }
}
