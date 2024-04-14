using ControleCodeFirst.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCodeFirst.Repository
{
     interface IEvenementRepository
    {
        Evenement GetById(int id);
        IEnumerable<Evenement> GetAll();

        void Add(Evenement entity);

        void Update(Evenement entity); // Ajout de la méthode Update
        void Remove(Evenement entity);
        
    }
}
