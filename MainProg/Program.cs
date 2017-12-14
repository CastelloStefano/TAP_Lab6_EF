using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace MainProg
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BugReportContext())
            {
                // Create and save a new Blog
                Console.Write("Created a Db \nAdd a USer \n Name:: ");
                var name = Console.ReadLine();
                var user = new Utente() { Name = name, CodFisc = "CSTS1FN93T12D9269U", Dob = new DateTime(1993,12,12), Age = 24, Indirizzo = new Address(){Civico = 9, Interno = 2, Via = "Viale Villa Chiesa"}, Surname = "Castello", LogIn = "121212"};
                db.Users.Add(user);
                var user2 = new Utente() { Name = "Ste", CodFisc = "CSTSFN293T121D969A", Dob = new DateTime(1993, 12, 12), Age = 24, Indirizzo = new Address() { Civico = 9, Interno = 2, Via = "Viale Villa Chiesa" }, Surname = "Castello", LogIn = "121212" };
                db.Users.Add(user2);
                db.SaveChanges();
                var query = from b in db.Users
                    orderby b.Name where b.Age > 10
                    select b;
                Console.WriteLine("All User in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.CodFisc);
                }


                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }


        }
    }
}
