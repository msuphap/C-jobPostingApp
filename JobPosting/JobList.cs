using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPosting
{
    class JobList
    {
        private static int LastJobID = 0;

        #region Properties
        public int JobID { get; private set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string JobDescription { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime CreateDate { get; private set; }
        public DateTime DeleteDate { get; private set; }
        #endregion

        #region Constructors
        public JobList()
        {
            JobID = ++LastJobID;
            CreateDate = DateTime.UtcNow;
        }

        //public JobList(string title, string jobDescription, string city, string state) : this()
        //{
        //    Title = title;
        //    JobDescription = jobDescription;
        //    City = city;
        //    State = state;
        //}
        #endregion

        #region Method
        public void PostJob(JobList jobListPost)
        {
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
            // delete account from DB
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
