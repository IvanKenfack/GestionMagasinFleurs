using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GestionMagasinFleurs.Classes;
using System.Reflection;

namespace GestionMagasinFleurs
{
    internal class Bouquet : IProduit
    {
        [JsonProperty("bouquet")]
        public List<Fleur> bouquet { get; set; }

        [JsonProperty("carte")]
        public CartePersonalisée carte; 

        public float PrixUnitaire { 
            get
            {
                return CalculerPrixTotal();
            }
        }

        public Bouquet()
        {

        }

        public Bouquet(List<Fleur> choixFleurs,string nom, string message)
        {
            this.bouquet = new List<Fleur>(choixFleurs);
            carte = new CartePersonalisée(nom,message);

        }

        public List<Fleur> GetFleurs()
        {
            return new List<Fleur>(this.bouquet);
        }
        public CartePersonalisée GetCarte() 
        { 
            return this.carte;
        }

        public ModeleBouquet ConvertirEnModele(string nom)
        {
            return new ModeleBouquet(this, nom);
        }

        public Article ConvertirEnArticle(int id, int quantite)
        {
            return new Article(id,this, quantite);
        }
        public void AjouterFleur(Fleur fleur)
        {
            bouquet.Add(fleur);
        }  
            
        public void Afficher()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------BOUQUET--------------------------");
            this.carte.AfficherCarte();
            foreach (Fleur fleur in this.bouquet)
            {
                fleur.Afficher();
            }
            Console.WriteLine();
            Console.WriteLine($"Prix Total du Bouquet: {this.PrixUnitaire} CAD");
            Console.WriteLine();
        }

        public float CalculerPrixTotal()
        {
            float prixTotal = 0;

            foreach (Fleur fleur in this.bouquet)
            {
                prixTotal += fleur.PrixUnitaire;
            }

            prixTotal += 3;
            return prixTotal;
        }


    }

}

