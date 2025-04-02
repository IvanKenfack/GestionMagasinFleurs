using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMagasinFleurs
{
    internal class Proprietaire : Utilisateur
    {

        public Proprietaire() { }

        public Proprietaire(int id, string nom, string email, int motDepasse) : base(id, nom, email, motDepasse)
        {
        }
        public void GérerBoutique()
        {
            Console.WriteLine($"{Nom} gère la boutique.");
        }
    }
}
