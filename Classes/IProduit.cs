using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMagasinFleurs.Classes
{
    public interface IProduit
    {
        float PrixUnitaire { get;}
        void Afficher();
        Article ConvertirEnArticle(int id, int quantite);
    }
}
