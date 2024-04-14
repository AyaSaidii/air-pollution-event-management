using ControleCodeFirst.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCodeFirst.Repository.PollutionPollutionEvenementR
{
     interface IPollutionEventRepository
    {
        PollutionEvenement GetById(int id);
        IEnumerable<PollutionEvenement> GetAll();

        void Add(PollutionEvenement entity);

        void Update(PollutionEvenement entity); // Ajout de la méthode Update
        void Remove(PollutionEvenement entity);
    }
}
