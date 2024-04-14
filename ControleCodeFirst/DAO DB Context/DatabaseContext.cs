using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCodeFirst.Modele
{
    class DatabaseContext : DbContext
    {
        public DbSet<Evenement> Evenements { get; set; }
        public DbSet<Lieu> Lieus { get; set; } // Renommé de Lieus à Lieux
        public DbSet<PollutionData> PollutionDatas { get; set; }
        public DbSet<Chercheur> Chercheurs { get; set; }
        public DbSet<Login> Logins { get; set; }


        public DbSet<PollutionEvenement> PollutionEvenements { get; set; }
        public DbSet<CherchPollutionEvent> CherchPollutionEvents { get; set; }

        public DatabaseContext() : base("name=Mdata") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PollutionEvenement>().ToTable("PollutionEvenement");
       
        }

    }
}
