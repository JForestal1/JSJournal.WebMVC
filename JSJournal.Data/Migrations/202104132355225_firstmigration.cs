namespace JSJournal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artifact",
                c => new
                    {
                        ArtifactID = c.Int(nullable: false, identity: true),
                        ArtifactType = c.Int(nullable: false),
                        ShortLabel = c.String(),
                        Description = c.String(),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.ArtifactID);
            
            CreateTable(
                "dbo.FollowUp",
                c => new
                    {
                        FollowUpID = c.Int(nullable: false, identity: true),
                        ShortDescription = c.String(),
                        FollowUpStatusID = c.Int(nullable: false),
                        Notes = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        DueUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        Lead_LeadID = c.Int(),
                    })
                .PrimaryKey(t => t.FollowUpID)
                .ForeignKey("dbo.FollowUpStatusType", t => t.FollowUpStatusID, cascadeDelete: true)
                .ForeignKey("dbo.Lead", t => t.Lead_LeadID)
                .Index(t => t.FollowUpStatusID)
                .Index(t => t.Lead_LeadID);
            
            CreateTable(
                "dbo.FollowUpStatusType",
                c => new
                    {
                        FollowUpStatusTypeID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.FollowUpStatusTypeID);
            
            CreateTable(
                "dbo.Interview",
                c => new
                    {
                        InterviewID = c.Int(nullable: false, identity: true),
                        PrimaryInterviwer = c.String(),
                        SecondaryInterviwer = c.String(),
                        InterviewTimeDateUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        Address = c.String(),
                        InterviewerLink = c.String(),
                        Notes = c.String(),
                        PostInterviewID = c.Int(),
                        Lead_LeadID = c.Int(),
                    })
                .PrimaryKey(t => t.InterviewID)
                .ForeignKey("dbo.PostInterview", t => t.PostInterviewID)
                .ForeignKey("dbo.Lead", t => t.Lead_LeadID)
                .Index(t => t.PostInterviewID)
                .Index(t => t.Lead_LeadID);
            
            CreateTable(
                "dbo.PostInterview",
                c => new
                    {
                        PostInterviewID = c.Int(nullable: false, identity: true),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.PostInterviewID);
            
            CreateTable(
                "dbo.Lead",
                c => new
                    {
                        LeadID = c.Int(nullable: false, identity: true),
                        guid = c.Guid(nullable: false),
                        StatusID = c.Int(nullable: false),
                        SourceID = c.Int(nullable: false),
                        JobDescriptionLink = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        ResumeID = c.Int(),
                        CoverID = c.Int(),
                        OtherArtifactID = c.Int(),
                    })
                .PrimaryKey(t => t.LeadID)
                .ForeignKey("dbo.Artifact", t => t.CoverID)
                .ForeignKey("dbo.Artifact", t => t.OtherArtifactID)
                .ForeignKey("dbo.Artifact", t => t.ResumeID)
                .ForeignKey("dbo.SourceType", t => t.SourceID, cascadeDelete: true)
                .ForeignKey("dbo.StatusType", t => t.StatusID, cascadeDelete: true)
                .Index(t => t.StatusID)
                .Index(t => t.SourceID)
                .Index(t => t.ResumeID)
                .Index(t => t.CoverID)
                .Index(t => t.OtherArtifactID);
            
            CreateTable(
                "dbo.SourceType",
                c => new
                    {
                        SourceTypeID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.SourceTypeID);
            
            CreateTable(
                "dbo.StatusType",
                c => new
                    {
                        StatusTypeID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.StatusTypeID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Lead", "StatusID", "dbo.StatusType");
            DropForeignKey("dbo.Lead", "SourceID", "dbo.SourceType");
            DropForeignKey("dbo.Lead", "ResumeID", "dbo.Artifact");
            DropForeignKey("dbo.Lead", "OtherArtifactID", "dbo.Artifact");
            DropForeignKey("dbo.Interview", "Lead_LeadID", "dbo.Lead");
            DropForeignKey("dbo.FollowUp", "Lead_LeadID", "dbo.Lead");
            DropForeignKey("dbo.Lead", "CoverID", "dbo.Artifact");
            DropForeignKey("dbo.Interview", "PostInterviewID", "dbo.PostInterview");
            DropForeignKey("dbo.FollowUp", "FollowUpStatusID", "dbo.FollowUpStatusType");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Lead", new[] { "OtherArtifactID" });
            DropIndex("dbo.Lead", new[] { "CoverID" });
            DropIndex("dbo.Lead", new[] { "ResumeID" });
            DropIndex("dbo.Lead", new[] { "SourceID" });
            DropIndex("dbo.Lead", new[] { "StatusID" });
            DropIndex("dbo.Interview", new[] { "Lead_LeadID" });
            DropIndex("dbo.Interview", new[] { "PostInterviewID" });
            DropIndex("dbo.FollowUp", new[] { "Lead_LeadID" });
            DropIndex("dbo.FollowUp", new[] { "FollowUpStatusID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.StatusType");
            DropTable("dbo.SourceType");
            DropTable("dbo.Lead");
            DropTable("dbo.PostInterview");
            DropTable("dbo.Interview");
            DropTable("dbo.FollowUpStatusType");
            DropTable("dbo.FollowUp");
            DropTable("dbo.Artifact");
        }
    }
}
