using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPosting
{
    public class JobSubmission
    {
        private static int LastJobSubmissionID = 0;

        #region Properties
        [Key]
        public int JobSudmissionID { get; set; }
        public DateTime SubmissionDate { get; set; }
        [Required]
        public int JobID { get; set; }
        [ForeignKey("JobSeeker")]
        public int JobSeekerID { get; set; }
        public virtual JobSeeker JobSeeker { get; set; }
        #endregion

        #region Constructors
        public JobSubmission()
        {
            JobSudmissionID = ++LastJobSubmissionID;
        }
        #endregion
    }
}
