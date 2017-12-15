using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugReportFactory;
using Database;

namespace MainProg
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inizializzo...");
            Factory.InitializeBugTracking(null, "password");

            Console.WriteLine("Accedo...");
            using (var db = Factory.LoadBugTracking(null, "password"))
            {
                var user1 = new Utente()
                {
                    Name = "Stefano",
                    Surname = "Castello",
                    Dob = new DateTime(93, 12, 12),
                    CodFisc = "CSTSFN93D12D969U",
                    Age = 24,
                    LogIn = "pwd",
                    Indirizzo = new Address() {Civico = 9, Interno = 2, Via = "viale Villa Chiesa"}
                };
                var user2 = new Utente()
                {
                    Name = "Giorgio",
                    Surname = "Castello",
                    Dob = new DateTime(60, 07, 20),
                    CodFisc = "CSTGRG60L20D969A",
                    Age = 57,
                    LogIn = "pwwd",
                    Indirizzo = new Address() {Civico = 9, Interno = 2, Via = "viale Villa Chiesa"}
                };
                var prod1 = new Prodotto()
                {
                    CommName = "Schermo",
                    Id = 10,
                    Req = new List<Prodotto>(),
                    NotComp = new List<Prodotto>()
                };
                var prod3 = new Prodotto()
                {
                    CommName = "Android",
                    Id = 12,
                    Req = new List<Prodotto>(),
                    NotComp = new List<Prodotto>()
                };
                var prod2 = new Prodotto()
                {
                    CommName = "iPhone",
                    Id = 11,
                    Req = new List<Prodotto> {prod1},
                    NotComp = new List<Prodotto> {prod3}
                };
                prod3.NotComp.Add(prod2);
                var report1 = new Segnalazione()
                {
                    Author = user1,
                    CreationDate = DateTime.Today,
                    Descr = "Sistema Orrendo!",
                    SigProd = prod3,
                    State = "Aperta",
                    Text = "Nulla da aggingere !",
                    Comments = new List<Commento>()
                };
                var comment1 = new Commento()
                {
                    Author = user2,
                    CreationDate = DateTime.Today,
                    Text = "Vero Meglio Apple!"
                };
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.Products.Add(prod1);
                db.Products.Add(prod2);
                db.Products.Add(prod3);
                db.Reports.Add(report1);
                db.Comments.Add(comment1);
                db.SaveChanges();
            }
            Console.ReadLine();
        }
    }
}
