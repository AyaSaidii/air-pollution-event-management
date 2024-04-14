using ControleCodeFirst.Modele;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleCodeFirst.Repository.PollutionDataR
{
     class PollutionDataRepository:IPollutionDataRepository
    {
        private readonly DatabaseContext db;
        public PollutionDataRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public void Add(PollutionData entity)
        {
            db.PollutionDatas.Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<PollutionData> GetAll()
        {
            return db.PollutionDatas.ToList();
        }

        public PollutionData GetById(int id)
        {
            return db.PollutionDatas.Find(id);
        }

        public void Remove(PollutionData entity)
        {
            if (entity != null)
            {
                db.PollutionDatas.Remove(entity);
                db.SaveChanges();

            }
            else
            {
                MessageBox.Show(" Id not Found !!", "Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Update(PollutionData entity)
        {
            var even = db.PollutionDatas.Find(entity.Id);
            if (even != null)
            {
                db.PollutionDatas.AddOrUpdate(entity);
                db.SaveChanges();

            }
            else
            {
                MessageBox.Show(" Id not Found !!", "Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
