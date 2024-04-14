using ControleCodeFirst.Modele;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleCodeFirst.Repository.ChercheurR
{
    internal class ChercheurRepository:IChercheurRepository
    {
        public ChercheurRepository(DatabaseContext db) {
            this.db = db;
        }
        private readonly DatabaseContext db;

        public Chercheur GetById(int id)
        {
            return db.Chercheurs.Find(id);
        }

        public IEnumerable<Chercheur> GetAll()
        {
            return db.Chercheurs.ToList();
        }

        public void Add(Chercheur entity)
        {
            db.Chercheurs.Add(entity);
            db.SaveChanges();
        }

        public void Update(Chercheur entity)
        {
            var lieu = db.Chercheurs.Find(entity.ChercheurId);
            if (lieu != null)
            {
                db.Chercheurs.AddOrUpdate(entity);
                db.SaveChanges();

            }
            else
            {
                MessageBox.Show(" Id not Found !!", "Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Remove(Chercheur entity)
        {
            if (entity != null)
            {
                db.Chercheurs.Remove(entity);
                db.SaveChanges();

            }
            else
            {
                MessageBox.Show(" Id not Found !!", "Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
