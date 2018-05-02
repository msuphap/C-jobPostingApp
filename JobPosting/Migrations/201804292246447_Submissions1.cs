namespace JobPosting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Submissions1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobSubmissions", "JobSubmission_JobSudmissionID", "dbo.JobSubmissions");
            DropIndex("dbo.JobSubmissions", new[] { "JobSubmission_JobSudmissionID" });
            DropColumn("dbo.JobSubmissions", "JobSubmission_JobSudmissionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobSubmissions", "JobSubmission_JobSudmissionID", c => c.Int());
            CreateIndex("dbo.JobSubmissions", "JobSubmission_JobSudmissionID");
            AddForeignKey("dbo.JobSubmissions", "JobSubmission_JobSudmissionID", "dbo.JobSubmissions", "JobSudmissionID");
        }
    }
}
