using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPosting
{
    public class JobList
    {
        private static int LastJobID = 0;

        #region Properties
        [Key]
        public int JobID { get; private set; }
        [Required]
        [StringLength(50, ErrorMessage ="The company cannot be more than 50 characters in length.")]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The job title cannot be more than 50 characters in length.")]
        public string Title { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "The job description cannot be more than 500 characters in length.")]
        public string JobDescription { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The city of job location cannot be more than 20 characters in length.")]
        public string City { get; set; }
        [Required]
        [StringLength(2, ErrorMessage = "The state of job location cannot be more than 2 characters in length.")]
        public string State { get; set; }
        public DateTime CreateDate { get; private set; }
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
