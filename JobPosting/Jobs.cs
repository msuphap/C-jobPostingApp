using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPosting
{
   static class Jobs
    {
        private static List<Employer> employerAccounts = new List<Employer>();
        /// <summary>
        /// This creates an account for employer
        /// </summary>
        /// <param name="username">Name of employer</param>
        /// <param name="password">Password of employer</param>
        /// <param name="companyName">Company of employer</param>
        /// <param name="email">Email of employer</param>
        /// <param name="phone">Phone of employer</param>
        /// <returns></returns>
        public static Employer CreateEmployerAccount(string username, string password,
            string companyName, string email, int phone)
        {
            var employerAccount = new Employer
            {
                Username = username,
                Password = password,
                CompanyName = companyName,
                Email = email,
                Phone = phone,
            };
            employerAccounts.Add(employerAccount);
            return employerAccount;
        }

        private static List<JobList> jobLists = new List<JobList>();
        /// <summary>
        /// Employer create job list
        /// </summary>
        /// <param name="title">title of job</param>
        /// <param name="jobDescription">description of job</param>
        /// <param name="city">cit of job</param>
        /// <param name="state">state of job</param>
        /// <returns></returns>
        public static JobList CreateJob(string companyName, string title, string jobDescription,
            string city, string state)
        {
            var jobListPost = new JobList
            {
                CompanyName = companyName,
                Title = title,
                JobDescription = jobDescription,
                City = city,
                State = state,
        };
            jobLists.Add(jobListPost);
            return jobListPost;
        }

        public static IEnumerable<JobList> GetAllJobs(string CompanyName)
        {
         return jobLists.Where(a => a.CompanyName == CompanyName);
        }

        private static List<JobSeeker> jobSeekerAccounts = new List<JobSeeker>();
        /// <summary>
        /// This creates an account for job seeker
        /// </summary>
        /// <param name="username">Name of job seeker</param>
        /// <param name="password">password of job seeker</param>
        /// <param name="firstName">first name of job seeker</param>
        /// <param name="lastName">last name of job seeker</param>
        /// <param name="email">email of job seeker</param>
        /// <param name="phone">phone of job seeker</param>
        /// <returns></returns>
        public static JobSeeker CreateJobSeekerAccount(string username, string password,
            string firstName, string lastName, string email, int phone)
        {
            var jobSeekerAccount = new JobSeeker
            {
                Username = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
            };
            jobSeekerAccounts.Add(jobSeekerAccount);
            return jobSeekerAccount;
        }

        public static IEnumerable<JobList> GetAllJobSearch(string searchWord)
        {
            return jobLists.Where(a => a.Title == searchWord);
        }
    }
}
