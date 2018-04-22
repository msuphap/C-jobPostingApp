using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPosting
{
    class JobSeeker
    {
        private static int LastJobSeekerID = 0;

        #region Properties
        public int JobSeekerID { get; private set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public DateTime CreateDate { get; private set; }
        public DateTime DeleteDate { get; private set; }
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
