using ControleCodeFirst.Modele;
using ControleCodeFirst.Repository.CherchPollutionEventPEvent;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleCodeFirst.Repository.ChercheurPEvent
{
    internal class ChercheurEventPRepository:IChercheurEventPRepository
    {
        public ChercheurEventPRepository(DatabaseContext db)
        {
            this.db = db;
        }
        private readonly DatabaseContext db;

        public CherchPollutionEvent GetById(int id)
        {
            return db.CherchPollutionEvents.Find(id);
        }

        public IEnumerable<CherchPollutionEvent> GetAll()
        {
            return db.CherchPollutionEvents.ToList();
        }

        public void Add(CherchPollutionEvent entity)
        {
            db.CherchPollutionEvents.Add(entity);
            db.SaveChanges();
        }

        public void Update(CherchPollutionEvent entity)
        {
            var lieu = db.CherchPollutionEvents.Find(entity.ChercheurId);
            if (lieu != null)
            {
                db.CherchPollutionEvents.AddOrUpdate(entity);
                db.SaveChanges();

            }
            else
            {
                MessageBox.Show(" Id not Found !!", "Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Remove(CherchPollutionEvent entity)
        {
            if (entity != null)
            {
                db.CherchPollutionEvents.Remove(entity);
                db.SaveChanges();

            }
            else
            {
                MessageBox.Show(" Id not Found !!", "Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
