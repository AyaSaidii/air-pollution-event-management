using ControleCodeFirst.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCodeFirst.Repository.LieuR
{
    interface ILieuRepository
    {
        Lieu GetById(int id);
        IEnumerable<Lieu> GetAll();

        void Add(Lieu entity);

        void Update(Lieu entity); // Ajout de la méthode Update
        void Remove(Lieu entity);

    }
}
