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
        public int JobSeekerID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DeleteDate { get; set; }
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
            Console.WriteLine("Please entry.");
            Console.Write("Username : ");
            Username = Console.ReadLine();
            Console.Write("Password : ");
            Password = Console.ReadLine();
            Console.Write("First name : ");
            FirstName = Console.ReadLine();
            Console.Write("Last name : ");
            LastName = Console.ReadLine();
            Console.Write("Email : ");
            Email = Console.ReadLine();
            Console.Write("Phone : ");
            Phone = Convert.ToInt32(Console.ReadLine());

            // insert new job seeker account into DB
            // print insert result
        }

        public void ResetPassword()
        {
            // fetching password
            Console.WriteLine("Please confirm to reset your password (Y/N).");
            char confirm = Console.ReadKey().KeyChar;
            if (confirm == 'Y')
            {
                Console.WriteLine("Please enter your new password.");
                Password = Console.ReadLine();
                // update password in DB
            }
        }

        public void DeleteAccount()
        {
            Console.WriteLine("Please confirm to delete your account (Y/N).");
            char confirm = Console.ReadKey().KeyChar;
            if (confirm == 'Y')
            {
                // delete account from DB
            }
        }
        #endregion
    }
}
