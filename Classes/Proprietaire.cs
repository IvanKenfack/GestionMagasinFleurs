using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionMagasinFleurs.Classes;

namespace GestionMagasinFleurs
{
    internal class Proprietaire : Utilisateur
    {

        //public Proprietaire() { }

        public Proprietaire(int id, string nom, string email, int motDepasse) 
            : base(id, nom, email, motDepasse)
        {
            this.Role = RoleUtilisateur.proprietaire;
        }
        public void GérerBoutique()
        {
            Console.WriteLine($"{Nom} gère la boutique.");
        }

        public void ConsulterStockFleurs(MagasinFleur magasin)
        {
            if (magasin.stockFleur.Count == 0)
            {
                Console.WriteLine($"Quantité : {magasin.QuantitéStock}");

                Console.WriteLine("Le stock de fleurs est vide.");
            }

            else
            {
                Console.WriteLine("Stock de fleurs Disponible :");
                Console.WriteLine($"Quantité : {magasin.QuantitéStock}");
                Console.WriteLine();
                magasin.AfficherStock();
                Console.WriteLine();   
            }

        }
    }
}
