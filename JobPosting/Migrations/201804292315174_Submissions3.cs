namespace JobPosting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Submissions3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobSubmissions", "JobID", "dbo.JobLists");
            DropIndex("dbo.JobSubmissions", new[] { "JobID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.JobSubmissions", "JobID");
            AddForeignKey("dbo.JobSubmissions", "JobID", "dbo.JobLists", "JobID", cascadeDelete: true);
        }
    }
}
