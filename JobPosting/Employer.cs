using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPosting
{
    class Employer
    {
        private static int lastEmployerID = 0;

        #region Properties
        public int EmployerID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        #endregion

        #region Constructors
        public Employer()
        {
            EmployerID = ++lastEmployerID;
            CreateDate = DateTime.UtcNow;
        }
        #endregion

        #region Method
        public void CreateAccount()
        {
            Console.WriteLine("Please entry.");
            Console.Write("Username : ");
            Username = Console.ReadLine();
            Console.Write("Password : ");
            Password = Console.ReadLine();
            Console.Write("Company name : ");
            CompanyName = Console.ReadLine();
            Console.Write("Email : ");
            Email = Console.ReadLine();
            Console.Write("Phone : ");
            Phone = Convert.ToInt32(Console.ReadLine()); 

            // insert new employer account into DB
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
            if(confirm == 'Y')
            {
                // delete account from DB
            }
        }
        #endregion
    }
}
