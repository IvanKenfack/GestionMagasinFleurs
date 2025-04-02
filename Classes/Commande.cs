using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMagasinFleurs
{
    internal class Commande
    {
        public int ID { get; set; }
        public string Date { get; set;}
        public string Statut {  get; set;} 

        public Commande() { }
        public Commande(int ID, string Date, string Statut)
        {
            this.ID = ID;
            this.Date = Date;
            this.Statut = Statut;
        }
        public void ValiderCommande()
        {
            Statut = "Validée";
            Console.WriteLine($"Commande {ID} Validée.");
        }
        public void AnnulerCommande()
        {
            Statut = "Annulée";
            Console.WriteLine($"Commande {ID} annulée.");
        }
       

    }
}
