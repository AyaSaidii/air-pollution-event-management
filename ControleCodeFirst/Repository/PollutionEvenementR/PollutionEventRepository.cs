using ControleCodeFirst.Modele;
using ControleCodeFirst.Repository.PollutionDataR;
using ControleCodeFirst.Repository.PollutionPollutionEvenementR;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleCodeFirst.Repository.PollutionEvenementR
{
     class PollutionEventRepository:IPollutionEventRepository
    {

        private readonly DatabaseContext db;

        public PollutionEventRepository()
        {
        }

        public PollutionEventRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public void Add(PollutionEvenement entity)
        {

            db.PollutionEvenements.Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<PollutionEvenement> GetAll()
        {
            return db.PollutionEvenements.ToList();
        }

        public PollutionEvenement GetById(int id)
        {
            return db.PollutionEvenements.Find(id);
        }

        public void Remove(PollutionEvenement entity)
        {
            if (entity != null)
            {
                db.PollutionEvenements.Remove(entity);
                db.SaveChanges();

            }
            else
            {
                MessageBox.Show(" Id not Found !!", "Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Update(PollutionEvenement entity)
        {
            var even = db.PollutionEvenements.Find(entity.Id);
            if (even != null)
            {
                db.PollutionEvenements.AddOrUpdate(entity);
                db.SaveChanges();

            }
            else
            {
                MessageBox.Show(" Id not Found !!", "Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
