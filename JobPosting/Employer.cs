using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPosting
{
    public class Employer
    {
        private static int LastEmployerID = 0;

        #region Properties
        [Key]
        public int EmployerID { get; private set; }
        [Required]
        [StringLength(50, ErrorMessage = "The username cannot be more than 50 characters in length.")]
        public string Username { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "The password cannot be more than 30 characters in length.")]
        public string Password { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The company cannot be more than 50 characters in length.")]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The email address cannot be more than 50 characters in length.")]
        [EmailAddress]
        public string Email { get; set; }
        public int Phone { get; set; }
        public DateTime CreateDate { get; private set; }
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
