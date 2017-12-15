using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace BugReportFactory
{
    public class Factory
    {
        public static void InitializeBugTracking(string connStr, string adminPwd)
        {
            using (var db = new BugReportContext())
            {
                db.Database.Delete();
                db.Database.Create();
                var user = new Utente(){Name = "Admin",CodFisc = "CF", Age = 12, Dob = DateTime.Today, LogIn = adminPwd, Surname = "admin", Indirizzo = new Address(){Civico = 0,Interno = 0, Via = ""}};
                db.Users.Add(user);
                db.SaveChanges();
                //return db;
            }
        }

        public static BugReportContext LoadBugTracking(string connStr, string adminPwd)
        {
            using (var db = new BugReportContext())
            {
                var query = from b in db.Users where b.Name.Equals("Admin")
                    select b;
                if (query.First().LogIn.Equals(adminPwd)) return db;
            }
            throw new Exception("Password Errata");
        }
    }
}
