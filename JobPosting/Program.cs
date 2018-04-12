using System;
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
                    return;
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
}
