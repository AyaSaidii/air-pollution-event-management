using ControleCodeFirst.Modele;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleCodeFirst.Repository
{
    internal class EventRepository : IEvenementRepository
    {
        private readonly DatabaseContext db;

        public EventRepository()
        {
        }

        public EventRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public void Add(Evenement entity)
        {
            db.Evenements.Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<Evenement> GetAll()
        {
            return db.Evenements.ToList();
        }

        public Evenement GetById(int id)
        {
            return db.Evenements.Find(id);
        }

        public void Remove(Evenement entity)
        {
           

            if (entity != null)
            {
                db.Evenements.Remove(entity);
                db.SaveChanges();
               
            }
            else
            {
                MessageBox.Show(" Id not Found !!", "Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Update(Evenement entity)
        {
            var even = db.Evenements.Find(entity.Id);
            if (even != null)
            {
                db.Evenements.AddOrUpdate(entity);
                db.SaveChanges();

            }
            else
            {
                MessageBox.Show(" Id not Found !!", "Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
 
