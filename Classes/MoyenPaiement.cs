using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMagasinFleurs.Classes
{
    internal class MoyenPaiement
    {
        public float Solde { get; set; }
        public TypePaiement Type { get; set;}
        public void Recharger(float montant)
        {
            Solde += montant;
        }
    }
}
