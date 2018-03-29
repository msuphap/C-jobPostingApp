using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPosting
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // select role
            Console.WriteLine("Welcome to Job Posting App");
            Console.WriteLine("Please select option:");
            Console.WriteLine("Press 1: Employer");
            Console.WriteLine("Press 2: Job Seeker");

            // receive role option
            int role = int.Parse(System.Console.ReadLine());

            // show Employer options
            if (role == 1)
            {
                Console.WriteLine("Please select option:");
                Console.WriteLine("Press 1: Create account");
                Console.WriteLine("Press 2: Post job");
                Console.WriteLine("Press 3: Show posted job");
                Console.WriteLine("Press 4: Edit posted job");
                Console.WriteLine("Press 5: Delete posted job");
                Console.WriteLine("Press 6: Reset account password");
                Console.WriteLine("Press 7: Delete account");
            }
            else // show Job Seeker options
            {
                Console.WriteLine("Please select option:");
                Console.WriteLine("Press 1: Create account");
                Console.WriteLine("Press 2: Search job");
                Console.WriteLine("Press 3: Submit job");
                Console.WriteLine("Press 4: Reset account password");
                Console.WriteLine("Press 5: Delete account");
            }

            // receive method option
            int option = int.Parse(System.Console.ReadLine());

            // call method for Employer
            if (role == 1) 
            {
                switch (option)
                {
                    case 1:
                        Employer employerCreate = new Employer();
                        employerCreate.CreateAccount();
                        break;
                    case 2:
                        JobList jobListPost = new JobList();
                        jobListPost.PostJob(jobListPost);
                        break;
                    case 3:
                        JobList jobListShow = new JobList();
                        jobListShow.ShowJob();
                        break;
                    case 4:
                        JobList jobListEdit = new JobList();
                        jobListEdit.EditJob();
                        break;
                    case 5:
                        JobList jobListDelete = new JobList();
                        jobListDelete.DeleteJob();
                        break;
                    case 6:
                        Employer employerReset = new Employer();
                        employerReset.ResetPassword();
                        break;
                    case 7:
                        Employer employerDelete = new Employer();
                        employerDelete.DeleteAccount();
                        break;
                }
            }
            else // Job Seeker 
            {
                
                switch (option)
                {
                    case 1:
                        JobSeeker jobSeekerCreate = new JobSeeker();
                        jobSeekerCreate.CreateAccount();
                        break;
                    case 2:
                        JobList jobListSearch = new JobList();
                        jobListSearch.SearchJob();
                        break;
                    case 3:
                        JobList jobListSubmit = new JobList();
                        jobListSubmit.SubmitJob();
                        break;
                    case 4:
                        JobSeeker jobSeekerReset = new JobSeeker();
                        jobSeekerReset.ResetPassword();
                        break;
                    case 5:
                        JobSeeker jobSeekerDelete = new JobSeeker();
                        jobSeekerDelete.DeleteAccount();
                        break;
                }
            }
        }
    }
}
