using ControleCodeFirst.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCodeFirst.Repository.CherchPollutionEventPEvent
{
     interface IChercheurEventPRepository
    {
        CherchPollutionEvent GetById(int id);
        IEnumerable<CherchPollutionEvent> GetAll();

        void Add(CherchPollutionEvent entity);

        void Update(CherchPollutionEvent entity); // Ajout de la méthode Update
        void Remove(CherchPollutionEvent entity);
    }
}
