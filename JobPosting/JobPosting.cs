using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPosting
{
    static class JobPosting
    {
        private static List<EmployerAccount> employerAccounts = new List<EmployerAccount>();
        /// <summary>
        /// This creates an account in the job posting
        /// </summary>
        /// <param name="username">Name of user</param>
        /// <param name="password">Password of user</param>
        /// <param name="companyName">Company of user</param>
        /// <param name="email">Email of user</param>
        /// <param name="phone">Phone of user</param>
        /// <returns></returns>
        public static EmployerAccount CreateEmployerAccount(string username, string password, 
            string companyName, string email, int phone)
        {
            var employerAccount = new EmployerAccount
            {
                Username = username,
                Password = password,
                CompanyName = companyName,
                Email = email,
                Phone = phone,
            };
            employerAccounts.Add(employerAccount);
            return EmployerAccount;
        }

        public static IEnumerable<Account> GetAllAccounts(string emailAddress)
        {
            return accounts.Where(a => a.EmailAddress == emailAddress);
        }
    }
}
