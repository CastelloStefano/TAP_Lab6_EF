using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public virtual string CodFisc { get; set; }
        public virtual string LogIn { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual DateTime Dob { get; set; }
        public virtual int Age { get; set; }
        public virtual Address Indirizzo { get; set; }

    }
    public class Segnalazione
    {
        public virtual Prodotto SigProd { get; set; }
        public virtual ICollection<Commento> Comments { get; set; }
        public virtual Utente Author { get; set; }
        public virtual string State { get; set; }
        public virtual DateTime CreationDate { get; set; }
        [MaxLength(256)]
        public virtual string Descr { get; set; }
        public virtual string Text { get; set; }
    }
    public class Prodotto
    {
        public virtual int Id { get; set; }
        public virtual string CommName { get; set; }
        public virtual ICollection<Prodotto> Req { get; set; }
        public virtual ICollection<Prodotto> NotComp { get; set; }
    }
    public class Commento
    {
        public virtual Utente Author { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual string Text { get; set; }
    }

    public class BugReportContext : DbContext
    {
        
    }

}
