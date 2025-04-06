using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMagasinFleurs.Classes
{
    internal class MagasinFleur
    {
        public string NomMagasin { get; set; }
        public List<Fleur> stockFleur;
        public int QuantitéStock;

        public MagasinFleur(string nomMagasin)
        {
            NomMagasin = nomMagasin;

            //Importer le stock de fleurs
            this.stockFleur = new List<Fleur>();
            Fleur f = new Fleur();
            f.ImporterFleurs();
            this.stockFleur = f.Fleurs;
            this.QuantitéStock = stockFleur.Count;
        }
        public void AfficherStock()
        {
            Console.WriteLine("*********  Le stock de fleurs  *********");
            Console.WriteLine();
            int i = 0;
            foreach (var fleur in stockFleur)
            {
                Console.WriteLine($"Fleur {i + 1}: ");
                fleur.Afficher();
                i++;
            }
        }
    }
}
