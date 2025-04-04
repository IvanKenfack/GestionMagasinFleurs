using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMagasinFleurs.Classes
{
    internal class Article
    {
        public int ID { get; set; }
        public Produit Produit { get; set; }
        public int Quantite { get; set; }
        public double sousTotal { get; set; }


        public Article(int id, Produit produit, int quantite) 
        {
            this.ID = id;
            this.Produit = produit;
            this.Quantite = quantite;
            this.sousTotal = CalculerSousTotal();
        }

        public double CalculerSousTotal()
        {
            if (this.Produit is Fleur)
                {
                Fleur fleur = (Fleur)this.Produit;
                return fleur.PrixUnitaire * this.Quantite;
                }
            else
            {
                Bouquet bouquet = (Bouquet)this.Produit;
                float prixUnitaire = bouquet.CalculerPrixTotal();
                return prixUnitaire * this.Quantite;
            }
            
        }

        public void AfficherArticle()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"ID: {ID}");
            Produit.Afficher();
            Console.WriteLine($"Quantité: {Quantite}\n, Sous-total: {sousTotal}\n");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
        }
    }
}
