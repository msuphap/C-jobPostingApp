using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPosting
{
   public static class Jobs
    {
        private static JobPostingModel db = new JobPostingModel();
        /// <summary>
        /// This is creation an account for employer
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
            db.Employers.Add(employerAccount); 
            db.SaveChanges();           
            return employerAccount;
        }

        /// <summary>
        /// This is deletion an account for employer
        /// </summary>
        /// <param name="username">Name of employer</param>
        /// <param name="password">Password of employer</param>
        /// <param name="companyName">Company of employer</param>
        /// <param name="email">Email of employer</param>
        /// <param name="phone">Phone of employer</param>
        /// <returns></returns>
        public static Employer DeleteEmployerAccount(string username, string password,
            string companyName, string email, int phone)
        {
            var deleteEmployerAccount = new Employer
            {
                Username = username,
                Password = password,
                CompanyName = companyName,
                Email = email,
                Phone = phone,
            };
            // Query the database for the rows to be deleted.
            var deleteOrderDetails =
                from details in db.Employers
                where details.Username == username
                   && details.Password == password
                   && details.CompanyName == companyName
                   && details.Email == email
                   && details.Phone == phone
               select details;

            foreach (var detail in deleteOrderDetails)
            {
                db.Employers.Remove(detail);
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
            }
            return deleteEmployerAccount;
        }

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
            db.JobLists.Add(jobListPost);
            db.SaveChanges();
            return jobListPost;
        }
        
        /// <summary>
        /// Employer delete job list
        /// </summary>
        /// <param name="title">title of job</param>
        /// <param name="jobDescription">description of job</param>
        /// <param name="city">cit of job</param>
        /// <param name="state">state of job</param>
        /// <returns></returns>
        public static JobList DeleteJob(string companyName, string title, string jobDescription,
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
            // Query the database for the rows to be deleted.
            var deleteOrderDetails =
                from details in db.JobLists
                where details.CompanyName == companyName
                   && details.Title == title
                   && details.JobDescription == jobDescription
                   && details.City == city
                   && details.State == state
                select details;

            foreach (var detail in deleteOrderDetails)
            {
                db.JobLists.Remove(detail);
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
            }
            return jobListPost;
        }

        public static IEnumerable<JobList> GetAllJobs(string CompanyName)
        {
         return db.JobLists.Where(a => a.CompanyName == CompanyName);
        }

        /// <summary>
        /// This is creation an account for job seeker
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
            db.JobSeekers.Add(jobSeekerAccount);
            db.SaveChanges();
            return jobSeekerAccount;
        }

        /// <summary>
        /// This is deletion an account for job seeker
        /// </summary>
        /// <param name="username">Name of job seeker</param>
        /// <param name="password">password of job seeker</param>
        /// <param name="firstName">first name of job seeker</param>
        /// <param name="lastName">last name of job seeker</param>
        /// <param name="email">email of job seeker</param>
        /// <param name="phone">phone of job seeker</param>
        /// <returns></returns>
        public static JobSeeker DeleteJobSeekerAccount(string username, string password,
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
            // Query the database for the rows to be deleted.
            var deleteOrderDetails =
                from details in db.JobSeekers
                where details.Username == username
                   && details.Password == password
                   && details.FirstName == firstName
                   && details.LastName == lastName
                   && details.Email == email
                   && details.Phone == phone
                select details;

            foreach (var detail in deleteOrderDetails)
            {
                db.JobSeekers.Remove(detail);
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
            }
            return jobSeekerAccount;
        }

        public static IEnumerable<JobList> GetAllJobSearch(string searchWord)
        {
            return db.JobLists.Where(a => a.Title == searchWord);
        }

        public static IEnumerable<JobSubmission> GetJobSubmissions(int jobID)
        {
            return db.JobSubmissions.Where(j => j.JobID == jobID).OrderBy(j => j.SubmissionDate);
        }

        public static JobSeeker GetJobSeekerDetail(int jobSeekerID)
        {
            return db.JobSeekers.Find(jobSeekerID);
        }

        public static void JobSubmission(int jobSeekerID, int jobID)
        {
            var jobIDSubmission = db.JobLists.Where(a => a.JobID == jobID).FirstOrDefault();
            if(jobIDSubmission == null)
            {
                //throw exception
                throw new ArgumentNullException("jobIDSubmission", "jobIDSubmission not found");
            }
            jobIDSubmission.SubmitJob();
            //var jobSeekerDetials = Jobs.GetJobSeekerDetail(jobSeekerID);
            
            var jobSubmission = new JobSubmission
            {
                    SubmissionDate = DateTime.UtcNow,
                    JobID = jobID,
                    JobSeekerID = jobSeekerID,
            };

            db.JobSubmissions.Add(jobSubmission);
            db.SaveChanges();
        }
    }
}
