using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMagasinFleurs
{
    internal class Client : Utilisateur
    {
        public int Adress {  get; set; }
        public int NumeroTel {  get; set; }
        public List<string> Preferences { get; set; }

        public Client() 
        {
            Preferences = new List<string>();
        }

        public Client(int id, string nom, string email, int motDepasse, int adress, int numeroTel) : base(id, nom, email, motDepasse)
        {
            Adress = adress;
            NumeroTel = numeroTel;
            Preferences = new List<string>();
        }

       
        public void IndiquerPreference(string preference)
        {
           Preferences.Add(preference);
            Console.WriteLine($"{Nom} a ajouté une préférence : {preference}");
        }

        public void SelectionnerFleur(string fleur)
        {
            Console.WriteLine($"{Nom} a sélectionné la fleur : {fleur}");
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
            Console.WriteLine($"{Nom} a choisi un moyen de paiyement.");
        }

        public void EffectuerPaiement()
        {
            Console.WriteLine($"{Nom} a Effectué un paiyement.");
        }

       
        

       
 
    }
}
