﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPosting
{
    class JobList
    {
        #region Properties
        private string Title { get; set; }
        private string JobDescription { get; set; }
        private string City { get; set; }
        private string State { get; set; }
        #endregion

        #region Method
        public void PostJob(JobList jobListPost)
        {
            Console.WriteLine("Please entry.");
            Console.Write("Title : ");
            jobListPost.Title = Console.ReadLine();
            Console.Write("Job description : ");
            jobListPost.JobDescription = Console.ReadLine();
            Console.Write("City : ");
            jobListPost.City = Console.ReadLine();
            Console.Write("State : ");
            jobListPost.State = Console.ReadLine();

            // insert new employer account into DB
            // print insert result

        }

        public void ShowJob()
        {
            // Fetching all job of this employer
        }

        public void EditJob()
        {
            // show job and ask for edit
        }

        public void DeleteJob()
        {
            // show job and ask to confirm for delete
            Console.WriteLine("Please entry jib ID.");
            int jobID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please confirm to delete job ID {0} (Y/N).", jobID);
            char confirm = Console.ReadKey().KeyChar;
            if (confirm == 'Y')
            {
                // delete account from DB
            }
        }

        public void SearchJob()
        {
            //print fetching job from DB
        }

        public void SubmitJob()
        {
            //insert DB
        }
        #endregion
    }
}
