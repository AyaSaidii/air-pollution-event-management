using ControleCodeFirst.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCodeFirst.Repository.ChercheurR
{
     interface IChercheurRepository
    {
        Chercheur GetById(int id);
        IEnumerable<Chercheur> GetAll();

        void Add(Chercheur entity);

        void Update(Chercheur entity); // Ajout de la méthode Update
        void Remove(Chercheur entity);
    }
}
