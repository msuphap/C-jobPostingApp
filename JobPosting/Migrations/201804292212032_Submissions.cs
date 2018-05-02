namespace JobPosting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Submissions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobSubmissions",
                c => new
                    {
                        JobSudmissionID = c.Int(nullable: false, identity: true),
                        SubmissionDate = c.DateTime(nullable: false),
                        JobID = c.Int(nullable: false),
                        JobSeekerID = c.Int(nullable: false),
                        JobSubmission_JobSudmissionID = c.Int(),
                    })
                .PrimaryKey(t => t.JobSudmissionID)
                .ForeignKey("dbo.JobSeekers", t => t.JobSeekerID, cascadeDelete: true)
                .ForeignKey("dbo.JobSubmissions", t => t.JobSubmission_JobSudmissionID)
                .Index(t => t.JobSeekerID)
                .Index(t => t.JobSubmission_JobSudmissionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobSubmissions", "JobSubmission_JobSudmissionID", "dbo.JobSubmissions");
            DropForeignKey("dbo.JobSubmissions", "JobSeekerID", "dbo.JobSeekers");
            DropIndex("dbo.JobSubmissions", new[] { "JobSubmission_JobSudmissionID" });
            DropIndex("dbo.JobSubmissions", new[] { "JobSeekerID" });
            DropTable("dbo.JobSubmissions");
        }
    }
}
