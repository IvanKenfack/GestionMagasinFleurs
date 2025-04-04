using GestionMagasinFleurs.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMagasinFleurs
{
    internal class Client : Utilisateur
    {
        private 

        public Client(int id, string nom, string email, int motDepasse, string role) 
            : base(id, nom, email, motDepasse, role)
        {

        }

        public void SelectionnerFleur(string fleur)
        {
            
        }

        public void SelectionnerBouquet(string bouquet)
        {
            Console.WriteLine($"{Nom} a sélectionné le bouquet : {bouquet}");
        }

        public void PasserCommande()
        {
            Console.WriteLine($"{Nom} a passé une commande.");
        }

        public void ChoisirMoyenPaiement()
        {
            Console.WriteLine($"{Nom} a choisi un moyen de paiement.");
        }

        public void EffectuerPaiement()
        {
            Console.WriteLine($"{Nom} a Effectué un paiement.");
        }

       
        

       
 
    }
}
