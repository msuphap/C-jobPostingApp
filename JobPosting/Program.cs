﻿using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPosting
{
   
    public enum TypeOfRole
    {
        Quit,
        Employer,
        [Description("Job Seeker")] JobSeeker
    }

    public enum EmployerOption
    {
        Quit,
        [Description("Create account")] CreateAccount,
        [Description("Post job")] PostJob,
        [Description("Show posted job")] ShowPostedJob,
        [Description("Edit posted job")] EditPostedJob,
        [Description("Delete posted job")] DeletePostedJob,
        [Description("Show job submission")] JobSubmission,
        [Description("Reset account password")] ResetAccountPassword,
        [Description("Delete account")] DeleteAccount
    }

     public enum JobSeekerOption
    {
        Quit,
        [Description("Create account")] CreateAccount,
        [Description("Search job")] SearchJob,
        [Description("Submit job")] SubmitJob,
        [Description("Reset account password")] ResetAccountPassword,
        [Description("Delete account")] DeleteAccount
    }
    
    class Program
    {
        private TypeOfRole Roles { get; set; }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        static void Main(string[] args)
        {
            // select role
            Console.WriteLine("Welcome to Job Posting App");
            Console.WriteLine("Please select option:");
            int i = 0;
            foreach (TypeOfRole roleValue in Enum.GetValues(typeof(TypeOfRole)))
            {
                Console.WriteLine($"Press {i}. {GetEnumDescription(roleValue)}");
                i++;
            }


            // receive role option
            int role = int.Parse(System.Console.ReadLine());
            while(true)
            {
                if (role == 0) // Exit
                {
                    Console.WriteLine("Thank you for visiting!");
                    return;
                }
                else if(role == 1) // show Employer options
                {
                    Console.WriteLine("Please select option:");                    
                    i = 0;
                    foreach (EmployerOption EmployerValue in Enum.GetValues(typeof(EmployerOption)))
                    {
                        Console.WriteLine($"Press {i}. {GetEnumDescription(EmployerValue)}");
                        i++;
                    }
                }
                else // show Job Seeker options
                {
                    Console.WriteLine("Please select option:");                    
                    i = 0;
                    foreach (JobSeekerOption JobSeekerValue in Enum.GetValues(typeof(JobSeekerOption)))
                    {
                        Console.WriteLine($"Press {i}. {GetEnumDescription(JobSeekerValue)}");
                        i++;
                    }
                }

                // receive method option
                int option = int.Parse(System.Console.ReadLine());

                // call method for Employer
                if (role == 1) 
                {
                    switch (option)
                    {
                        case 0: // Quit App
                            Console.WriteLine("Thank you for visiting!");
                            return;
                        case 1: // Create Employer Account
                            Console.WriteLine("Please entry.");
                            Console.Write("Username : ");
                            var username = Console.ReadLine();
                            Console.Write("Password : ");
                            var password = Console.ReadLine();
                            Console.Write("Company name : ");
                            var companyName = Console.ReadLine();
                            Console.Write("Email : ");
                            var email = Console.ReadLine();
                            Console.Write("Phone : ");
                            var phone = Convert.ToInt32(Console.ReadLine());

                            var employerAccount = Jobs.CreateEmployerAccount(username, password, companyName, email, phone);
                            Console.WriteLine($"EmployerID:{employerAccount.EmployerID}, Username: {employerAccount.Username}, Password: {employerAccount.Password}, CompanyName: {employerAccount.CompanyName}, Email: {employerAccount.Email}, Phone: {employerAccount.Phone}, CreatedDate: {employerAccount.CreateDate}");
                            break;
                        case 2: // Post JobList Job
                            Console.WriteLine("Please entry.");
                            Console.Write("Company Name : ");
                            companyName = Console.ReadLine();
                            Console.Write("Title : ");
                            var title = Console.ReadLine();
                            Console.Write("Job description : ");
                            var jobDescription = Console.ReadLine();
                            Console.Write("City : ");
                            var city = Console.ReadLine();
                            Console.Write("State : ");
                            var state = Console.ReadLine();

                            var jobListPost = Jobs.CreateJob(companyName, title, jobDescription, city, state);
                            Console.WriteLine($"JobID:{jobListPost.JobID},  CompanyName: {jobListPost.CompanyName}, Title: {jobListPost.Title}, JobDescription: {jobListPost.JobDescription}, City: {jobListPost.City}, State: {jobListPost.State}, CreatedDate: {jobListPost.CreateDate}");
                            break;
                        case 3: // Show Job List
                            try
                            {
                                PrintAllJobs();
                            }
                            catch (ArgumentNullException ax)
                            {
                                Console.WriteLine($"Error - {ax.Message}. Please try again!");
                            }
                            break;
                        case 4:
                            //JobList jobListEdit = new JobList();
                            //jobListEdit.EditJob();
                            break;
                        case 5: // Delete JobList Job
                            try
                            {
                                PrintAllJobs();
                                // show job and ask to confirm for delete
                                Console.WriteLine("Please entry job ID.");
                                var jobID = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Please confirm to delete job ID {0} (Y/N).", jobID);
                                var confirm_del_job = Console.ReadKey().KeyChar;
                                if (confirm_del_job == 'Y')
                                {
                                    Console.WriteLine("Please entry.");
                                    Console.Write("Company Name : ");
                                    companyName = Console.ReadLine();
                                    Console.Write("Title : ");
                                    title = Console.ReadLine();
                                    Console.Write("Job description : ");
                                    jobDescription = Console.ReadLine();
                                    Console.Write("City : ");
                                    city = Console.ReadLine();
                                    Console.Write("State : ");
                                    state = Console.ReadLine();

                                    var deleteJobListPost = Jobs.DeleteJob(companyName, title, jobDescription, city, state);
                                    Console.WriteLine("Delete was successful.");
                                    Console.WriteLine($"JobID:{deleteJobListPost.JobID},  CompanyName: {deleteJobListPost.CompanyName}, Title: {deleteJobListPost.Title}, JobDescription: {deleteJobListPost.JobDescription}, City: {deleteJobListPost.City}, State: {deleteJobListPost.State}, CreatedDate: {deleteJobListPost.CreateDate}");
                                }
                            }
                            catch (ArgumentNullException ax)
                            {
                                Console.WriteLine($"Error - {ax.Message}. Please try again!");
                            }
                            catch (ArgumentException ax)
                            {
                                Console.WriteLine($"Error - {ax.Message}. Please try again!");
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine($"Job ID is not in the right format.");
                            }
                            break;
                        case 6: // Show job submission
                            try
                            {
                                PrintAllJobs();
                                Console.WriteLine("Please entry job ID.");
                                var jobID = Convert.ToInt32(Console.ReadLine());
                                var jobSubmissions = Jobs.GetJobSubmissions(jobID);
                                foreach (var jobSubmission in jobSubmissions)
                                {
                                    Console.WriteLine($"JobSeekerID:{jobSubmission.JobSeekerID}, Submission:{jobSubmission.SubmissionDate}");
                                }
                            }
                            catch (ArgumentNullException ax)
                            {
                                Console.WriteLine($"Error - {ax.Message}. Please try again!");
                            }
                            catch (ArgumentException ax)
                            {
                                Console.WriteLine($"Error - {ax.Message}. Please try again!");
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine($"Job ID is not in the right format.");
                            }
                            break;
                        case 7: // Reset Employer Password
                            Console.WriteLine("Please confirm to reset your password (Y/N).");
                            var confirm = Console.ReadKey().KeyChar;
                            if (confirm == 'Y')
                            {
                                Console.WriteLine("Please enter your new password.");
                                password = Console.ReadLine();
                            }
                            break;
                        case 8: // Delete Employer Account
                            Console.WriteLine("Please confirm to delete your account (Y/N).");
                            confirm = Console.ReadKey().KeyChar;
                            if(confirm == 'Y')
                            {
                                Console.WriteLine("Please entry.");
                                Console.Write("Username : ");
                                username = Console.ReadLine();
                                Console.Write("Password : ");
                                password = Console.ReadLine();
                                Console.Write("Company name : ");
                                companyName = Console.ReadLine();
                                Console.Write("Email : ");
                                email = Console.ReadLine();
                                Console.Write("Phone : ");
                                phone = Convert.ToInt32(Console.ReadLine());
                                var deleteEmployerAccount = Jobs.DeleteEmployerAccount(username, password, companyName, email, phone);
                                Console.WriteLine("Delete was successful.");
                                Console.WriteLine($"EmployerID:{deleteEmployerAccount.EmployerID}, Username: {deleteEmployerAccount.Username}, Password: {deleteEmployerAccount.Password}, CompanyName: {deleteEmployerAccount.CompanyName}, Email: {deleteEmployerAccount.Email}, Phone: {deleteEmployerAccount.Phone}, CreatedDate: {deleteEmployerAccount.CreateDate}");
                            }
                            break;
                    }
                }
                else // Job Seeker 
                {
                
                    switch (option)
                    {
                        case 0: // Quit App
                            Console.WriteLine("Thank you for visiting!");
                            return;
                        case 1: // Create JobSeeker Account
                            Console.WriteLine("Please entry.");
                            Console.Write("Username : ");
                            var username = Console.ReadLine();
                            Console.Write("Password : ");
                            var password = Console.ReadLine();
                            Console.Write("First name : ");
                            var firstName = Console.ReadLine();
                            Console.Write("Last name : ");
                            var lastName = Console.ReadLine();
                            Console.Write("Email : ");
                            var email = Console.ReadLine();
                            Console.Write("Phone : ");
                            var phone = Convert.ToInt32(Console.ReadLine());

                            var jobSeekerAccount = Jobs.CreateJobSeekerAccount(username, password, firstName, lastName, email, phone);
                            Console.WriteLine($"JobSeekerID:{jobSeekerAccount.JobSeekerID}, Username: {jobSeekerAccount.Username}, Password: {jobSeekerAccount.Password}, FirstName: {jobSeekerAccount.FirstName}, LastName: {jobSeekerAccount.LastName}, Email: {jobSeekerAccount.Email}, Phone: {jobSeekerAccount.Phone}, CreatedDate: {jobSeekerAccount.CreateDate}");
                            break;
                        case 2: // Search JobList
                            Console.Write("Please entry job title for searching: ");
                            string searchWord = Console.ReadLine();

                            var jobListSearch = Jobs.GetAllJobSearch(searchWord);
                            foreach (var job in jobListSearch)
                            {
                                Console.WriteLine($"JobID: {job.JobID}, CompanyName: {job.CompanyName}, Title: {job.Title}, JobDescription: {job.JobDescription}, City: {job.City}, State: {job.State}, CreatedDate: {job.CreateDate}");
                            }
                            break;
                        case 3:
                            //JobList jobListSubmit = new JobList();
                            //jobListSubmit.SubmitJob();
                            Console.Write("Enter your jobSeeker ID: ");
                            var jobSeekerID = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter job ID that you would like to apply: ");
                            var jobID = Convert.ToInt32(Console.ReadLine());
                            Jobs.JobSubmission(jobSeekerID, jobID);
                            Console.WriteLine("Job submission completes successfully.");
                            Console.WriteLine($"JobSeekerID:{jobSeekerID}, JobID: {jobID}");
                            break;
                        case 4: // Reset JobSeeker Password
                            // fetching password
                            Console.WriteLine("Please confirm to reset your password (Y/N).");
                            var confirm = Console.ReadKey().KeyChar;
                            if (confirm == 'Y')
                            {
                                Console.WriteLine("Please enter your new password.");
                                password = Console.ReadLine();
                                // update password in DB
                            }
                            break;
                        case 5: // Delete JobSeeker Account
                            Console.WriteLine("Please confirm to delete your account (Y/N).");
                            confirm = Console.ReadKey().KeyChar;
                            if (confirm == 'Y' || confirm == 'y')
                            {
                                Console.WriteLine("Please entry.");
                                Console.Write("Username : ");
                                username = Console.ReadLine();
                                Console.Write("Password : ");
                                password = Console.ReadLine();
                                Console.Write("First name : ");
                                firstName = Console.ReadLine();
                                Console.Write("Last name : ");
                                lastName = Console.ReadLine();
                                Console.Write("Email : ");
                                email = Console.ReadLine();
                                Console.Write("Phone : ");
                                phone = Convert.ToInt32(Console.ReadLine());

                                var deleteJobSeekerAccount = Jobs.DeleteJobSeekerAccount(username, password, firstName, lastName, email, phone);
                                Console.WriteLine("Delete was successful.");
                                Console.WriteLine($"JobSeekerID:{deleteJobSeekerAccount.JobSeekerID}, Username: {deleteJobSeekerAccount.Username}, Password: {deleteJobSeekerAccount.Password}, FirstName: {deleteJobSeekerAccount.FirstName}, LastName: {deleteJobSeekerAccount.LastName}, Email: {deleteJobSeekerAccount.Email}, Phone: {deleteJobSeekerAccount.Phone}, CreatedDate: {deleteJobSeekerAccount.CreateDate}");
                            }
                            break;
                    }
                }
            }
        }

        private static void PrintAllJobs()
        {
            string companyName;
            Console.Write("Company Name: ");
            companyName = Console.ReadLine();
            if (string.IsNullOrEmpty(companyName))
            {
                throw new ArgumentNullException("Company name is required");
            }
            var jobs = Jobs.GetAllJobs(companyName);
            foreach (var job in jobs)
            {
                Console.WriteLine($"JobID: {job.JobID}, Title: {job.Title}, JobDescription: {job.JobDescription}, City: {job.City}, State: {job.State}, CreatedDate: {job.CreateDate}");
            }
        }


    }
}
