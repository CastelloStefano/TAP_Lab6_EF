﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
//using System.Linq;

namespace Database
{
    public class Address
    {
        public virtual string Via { get; set; }
        public virtual int Civico { get; set; }
        public virtual int Interno { get; set; }
    }

    public class Utente
    {
        [Key]
        public virtual string CodFisc { get; set; }
        [Required]
        public virtual string LogIn { get; set; }
        [MaxLength(25)]
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        [Column("DoB", TypeName = "DateTime2")]
        public virtual DateTime Dob { get; set; }
        public virtual int Age { get; set; }
        public virtual Address Indirizzo { get; set; }

    }
    public class Segnalazione
    {
        [Key]
        public virtual Prodotto SigProd { get; set; }
        public virtual ICollection<Commento> Comments { get; set; }
        [Key]
        public virtual Utente Author { get; set; }
        [Required]
        public virtual string State { get; set; }
        [Key]
        [Column("CreationDate", TypeName = "DateTime2")]
        public virtual DateTime CreationDate { get; set; }
        [MaxLength(256)]
        public virtual string Descr { get; set; }
        public virtual string Text { get; set; }
    }
    public class Prodotto
    {
        [Key]
        public virtual int Id { get; set; }
        [Required]
        public virtual string CommName { get; set; }
        public virtual ICollection<Prodotto> Req { get; set; }
        public virtual ICollection<Prodotto> NotComp { get; set; }
    }
    public class Commento
    {
        [Key]
        public virtual Utente Author { get; set; }
        [Key]
        [Column("CreationDate", TypeName = "DateTime2")]
        public virtual DateTime CreationDate { get; set; }
        public virtual string Text { get; set; }
    }

    public class BugReportContext : DbContext
    {
        public DbSet<Utente> Users { get; set; }
        public DbSet<Segnalazione> Reports { get; set; }
        public DbSet<Prodotto> Products{ get; set; }
        public DbSet<Commento> Comments{ get; set; }
        
    }

}
