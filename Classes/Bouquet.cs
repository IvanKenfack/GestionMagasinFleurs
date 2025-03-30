using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMagasinFleurs
{
    internal class Bouquet
    {
        private List<Fleur> bouquet;
        private CartePersonalisée carte; //{ get; set; }


        public int PrixTotal {  get; set; }

        public Bouquet()
        {
            bouquet = new List<Fleur>();
            carte = new CartePersonalisée();
        }

        public Bouquet CreerBouquet(List<Fleur> choixFleurs)
        {
            Bouquet bouquet = new Bouquet();

            foreach (Fleur fleur in choixFleurs)
            {
                bouquet.AjouterFleur(fleur);
            }

            string nom, message;

            Console.WriteLine("Veuillez entrez le nom du béneficiare: ");
            nom = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Veuillez entrez le message à insérer dans la carte: ");
            message = Console.ReadLine();
            Console.WriteLine();
            CartePersonalisée carte = new CartePersonalisée();
            carte.CustomiserCarte(nom, message);
            Console.WriteLine("Bouquet crée avec succèss");
            return bouquet;
        }



        public void EnregistrerModel()
        {
            throw new NotImplementedException();
        }

        public void AjouterFleur(Fleur fleur)
        {
            bouquet.Add(fleur);
        }  
            
        public void AfficherBouquet()
        {
            foreach (Fleur fleur in bouquet)
            {
                fleur.AfficherFleur();
            }
                
            carte.AfficherCarte();
        }

        public float CalculerPrixTotal()
        {
            float prixTotal = 0;

            foreach (Fleur fleur in bouquet)
            {
                prixTotal += fleur.PrixUnitaire;
            }

            prixTotal += 3;
            return PrixTotal;
        }

    }
}
