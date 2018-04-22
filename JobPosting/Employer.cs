using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPosting
{
    class Employer
    {
        private static int LastEmployerID = 0;

        #region Properties
        public int EmployerID { get; private set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public DateTime CreateDate { get; private set; }
        public DateTime DeleteDate { get; private set; }
        #endregion

        #region Constructors
        public Employer()
        {
            EmployerID = ++LastEmployerID;
            CreateDate = DateTime.UtcNow;
        }

        public Employer(string username, string password) : this()
        {
            Username = username;
            Password = password;
        }

        public Employer(string companyName, string email, int phone) : this()
        {
            CompanyName = companyName;
            Email = email;
            Phone = phone;
        }
        #endregion

        #region Method
        public void CreateAccount()
        {
            // insert new employer account into DB
            // print insert result
        }

        public void ResetPassword()
        {
            // fetching password
        }

        public void DeleteAccount()
        {
            
           // delete account from DB
        }
        #endregion
    }
}
