using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMagasinFleurs
{
    internal class CartePersonalisée
    {
        public string Nom { get; set; }

        public string Message { get; set; }

        public void AfficherCarte()
        {
            Console.WriteLine();
            Console.WriteLine("Nom: " + Nom);
            Console.WriteLine("Message: " + Message);
            Console.WriteLine();
        }

        public CartePersonalisée(string Nom, string message)
        {
            this.Nom = Nom;
            this.Message = message;
        }
    }
}
