namespace JobPosting
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class JobPostingModel : DbContext
    {
        // Your context has been configured to use a 'JobPostingModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'JobPosting.JobPostingModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'JobPostingModel' 
        // connection string in the application configuration file.
        public JobPostingModel()
            : base("name=JobPostingModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Employer> Employers { get; set; }
        public virtual DbSet<JobSeeker> JobSeekers { get; set; }
        public virtual DbSet<JobList> JobLists { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}