using ControleCodeFirst.Modele;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleCodeFirst.Repository.LieuR
{
    internal class LieuRepository:ILieuRepository
    {
        private readonly DatabaseContext db;

        public LieuRepository(DatabaseContext db)
        {
            this.db = db;
        }

        
        public void Add(Lieu entity)
        {
            db.Lieus.Add(entity);
            db.SaveChanges();

        }

        public IEnumerable<Lieu> GetAll()
        {
            return db.Lieus.ToList();
        }

        public Lieu GetById(int id)
        {
            return db.Lieus.Find(id);
        }

        public void Remove(Lieu entity)
        {
           
            if (entity != null)
            {
                db.Lieus.Remove(entity);
                db.SaveChanges();

            }
            else
            {
                MessageBox.Show(" Id not Found !!", "Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Update(Lieu entity)
        {
            var lieu = db.Lieus.Find(entity.Id);
            if (lieu != null)
            {
                db.Lieus.AddOrUpdate(entity);
                db.SaveChanges();

            }
            else
            {
                MessageBox.Show(" Id not Found !!", "Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
