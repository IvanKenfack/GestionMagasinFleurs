using GestionMagasinFleurs.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMagasinFleurs
{
    internal class Facture
    {
        public int ID { get; set;}

        public int PrixTotal { get; set; }

        public TypePaiement ModePaiement { get; set; }

        public DateTime DateFacture { get; set; }

        Produit produit { get; set; }

        

        public Facture(int id )
        {
            
        }
    }
}
