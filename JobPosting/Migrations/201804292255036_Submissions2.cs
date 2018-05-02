namespace JobPosting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Submissions2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.JobSubmissions", "JobID");
            AddForeignKey("dbo.JobSubmissions", "JobID", "dbo.JobLists", "JobID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobSubmissions", "JobID", "dbo.JobLists");
            DropIndex("dbo.JobSubmissions", new[] { "JobID" });
        }
    }
}
