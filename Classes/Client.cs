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

        public Client(int id, string nom, string email, int motDepasse) 
            : base(id, nom, email, motDepasse)
        {
            this.Role = RoleUtilisateur.client;
        }

        public void SelectionnerFleur(string fleur)
        {
            
        }

        public void SelectionnerBouquet(string bouquet)
        {
            Console.WriteLine($"{Nom} a sélectionné le bouquet : {bouquet}");
        }

        public void PasserCommande(Commande commande,Magasin magasin)
        {
            ;
        }

        public void ChoisirMoyenPaiement(TypePaiement paiement, Commande commande)
        {
            commande.Etat = paiement;
        }

        public void EffectuerPaiement()
        {
            Console.WriteLine($"{Nom} a Effectué un paiement.");
        }







    }
}
