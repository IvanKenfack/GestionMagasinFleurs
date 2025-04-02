using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMagasinFleurs
{
    internal class Fournisseur : Utilisateur
    {
        public string Contact { get; set; }

        public Fournisseur() { }
        public Fournisseur (int id, string nom, string email, int motDepasse, string contact) : base(id, nom, email, motDepasse)
        {
            Contact = contact;
        }
        public void ApprovisionnerFleurs()
        {
            Console.WriteLine($"{Nom} approvisionne les fleurs.");
        }
    }
}
