using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPosting
{
    public class JobSeeker
    {
        private static int LastJobSeekerID = 0;

        #region Properties
        [Key]
        public int JobSeekerID { get; private set; }
        [Required]
        [StringLength(50, ErrorMessage = "The username cannot be more than 50 characters in length.")]
        public string Username { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "The password cannot be more than 30 characters in length.")]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The email address cannot be more than 50 characters in length.")]
        [EmailAddress]
        public string Email { get; set; }
        public int Phone { get; set; }
        public DateTime CreateDate { get; private set; }
        #endregion

        #region Constructors
        public JobSeeker()
        {
            JobSeekerID = ++LastJobSeekerID;
            CreateDate = DateTime.UtcNow;
        }

        public JobSeeker(string username, string password) : this()
        {
            Username = username;
            Password = password;
        }

        public JobSeeker(string firstname, string lastName, string email) : this()
        {
            FirstName = firstname;
            LastName = lastName;
            Email = email;
        }

        public JobSeeker(int phone) : this()
        {
            Phone = phone;
        }
        #endregion

        #region Methods
        public void CreateAccount()
        {
            // insert new job seeker account into DB
            // print insert result
        }

        public void ResetPassword()
        {
        }

        public void DeleteAccount()
        {
            // delete account from DB
        }
        #endregion
    }
}
