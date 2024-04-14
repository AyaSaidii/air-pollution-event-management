using ControleCodeFirst.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCodeFirst.Repository.PollutionDataR
{
     interface IPollutionDataRepository
    {
        PollutionData GetById(int id);
        IEnumerable<PollutionData> GetAll();
        void Add(PollutionData entity);
        void Update(PollutionData entity);
        void Remove(PollutionData entity);
    }
}
