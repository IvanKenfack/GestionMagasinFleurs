using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMagasinFleurs
{
    internal class Vendeur : Utilisateur
    {
       public int Salaire {  get; set; }

        public Vendeur() { }
        public Vendeur(int id, string nom, string email, int motDepasse,int salaire) : base(id, nom, email, motDepasse)
        {
            salaire = salaire;
        }
        public void SuivreCommande()
        {
            Console.WriteLine($"{Nom} suit une commande.");
        }
    }
}
