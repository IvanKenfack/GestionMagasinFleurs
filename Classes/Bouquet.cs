using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GestionMagasinFleurs.Classes;

namespace GestionMagasinFleurs
{
    internal class Bouquet : Produit
    {
        private List<Fleur> bouquet;
        private CartePersonalisée carte; //{ get; set; }
        private List<Bouquet> modeles = new List<Bouquet>();

        public int PrixTotal {  get; set; }

        public Bouquet(List<Fleur> choixFleurs,string nom, string message)
        {
            bouquet = new List<Fleur>();
            carte = new CartePersonalisée(nom,message);
            foreach (Fleur fleur in choixFleurs)
            {
                this.bouquet.Add(fleur);
            }

        }

        //public Bouquet CreerBouquet(List<Fleur> choixFleurs)
        //{
        //    //Bouquet bouquet = new Bouquet();

            

        //    string nom, message;

        //    Console.WriteLine("Veuillez entrez le nom du béneficiare: ");
        //    nom = Console.ReadLine();
        //    Console.WriteLine();
        //    Console.WriteLine("Veuillez entrez le message à insérer dans la carte: ");
        //    message = Console.ReadLine();
        //    Console.WriteLine();
        //    CartePersonalisée carte = new CartePersonalisée();
        //    carte.CustomiserCarte(nom, message);
        //    Console.WriteLine("Bouquet crée avec succèss");
        //    return bouquet;
        //}



        public void EnregistrerModel(Bouquet bouquet)
        {
            modeles.Add(bouquet);
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

        public void AfficherModeles()
        {
            int i = 0;
            foreach (Bouquet bouquet in modeles)
            {
                Console.WriteLine($"Modèle {i + 1}");
                bouquet.AfficherBouquet();
                i++;
            }
        }

        public void ExporterModeles(List<Bouquet> modeles)
        {
            string fichierJSON = "modeles_Bouquets.json";
            using (StreamWriter fichier = File.AppendText(fichierJSON))
            {
                foreach (Bouquet modele in modeles)
                {
                    string modeleSerialise = JsonConvert.SerializeObject(modele);
                    fichier.WriteLine(modeleSerialise);
                }
                    
            }
        }
    }
}
