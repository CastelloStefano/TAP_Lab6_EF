using System;
using System.Collections.Generic;
using BugReportFactory;
using Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace BugTrackerTest.Test
{
    [TestFixture]
    public class UnitTest
    {
        public BugReportContext Db;
        public Utente User1, User2;
        public Prodotto Prod1, Prod2, Prod3;
        public Segnalazione Report1;
        public Commento Comment1;

        [SetUp]
        public void SetUp()
        {
            Factory.InitializeBugTracking(null, "password");
            Db = Factory.LoadBugTracking(null, "password");
            User1 = new Utente()
            {
                Name = "Stefano",
                Surname = "Castello",
                Dob = new DateTime(93, 12, 12),
                CodFisc = "CSTSFN93D12D969U",
                Age = 24,
                LogIn = "pwd",
                Indirizzo = new Address() { Civico = 9, Interno = 2, Via = "viale Villa Chiesa" }
            };
            User2 = new Utente()
            {
                Name = "Giorgio",
                Surname = "Castello",
                Dob = new DateTime(60, 07, 20),
                CodFisc = "CSTGRG60L20D969A",
                Age = 57,
                LogIn = "pwwd",
                Indirizzo = new Address() { Civico = 9, Interno = 2, Via = "viale Villa Chiesa" }
            };
            Prod1 = new Prodotto()
            {
                CommName = "Schermo",
                Id = 10,
                Req = new List<Prodotto>(),
                NotComp = new List<Prodotto>()
            };
            Prod3 = new Prodotto()
            {
                CommName = "Android",
                Id = 12,
                Req = new List<Prodotto>(),
                NotComp = new List<Prodotto>()
            };
            Prod2 = new Prodotto()
            {
                CommName = "iPhone",
                Id = 11,
                Req = new List<Prodotto> { Prod1 },
                NotComp = new List<Prodotto> { Prod3 }
            };
            Prod3.NotComp.Add(Prod2);
            Report1 = new Segnalazione()
            {
                Author = User1,
                CreationDate = DateTime.Today,
                Descr = "Sistema Orrendo!",
                SigProd = Prod3,
                State = "Aperta",
                Text = "Nulla da aggingere !",
                Comments = new List<Commento>()
            };
            Comment1 = new Commento()
            {
                Author = User2,
                CreationDate = DateTime.Today,
                Text = "Vero Meglio Apple!"
            };
        }

        [Test]
        public void Insert()
        {
            Db.Users.Add(User1);
            Db.Users.Add(User2);
            Db.Products.Add(Prod1);
            Db.Products.Add(Prod2);
            Db.Products.Add(Prod3);
            Db.Reports.Add(Report1);
            Db.Comments.Add(Comment1);
            Db.SaveChanges();

        }
    }
}
