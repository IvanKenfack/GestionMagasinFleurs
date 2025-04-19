using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMagasinFleurs.Classes
{
    public class Article
    {
        [JsonProperty("ID")]
        public int ID { get; set; }

        [JsonProperty("Produit")]
        [JsonConverter(typeof(ConvertisseurProduit))]
        public IProduit Produit { get; set; }

        [JsonProperty("Quantite")]
        public int Quantite { get; set; }

        [JsonProperty("sousTotal")]
        public float sousTotal { get; set; }

        public Article()
        {

        }

        public Article(int id, IProduit produit, int quantite) 
        {
            this.ID = id;
            this.Produit = produit;
            this.Quantite = quantite;
            this.sousTotal = CalculerSousTotal();
        }

        public float CalculerSousTotal()
        {
            return this.Produit.PrixUnitaire * Quantite;
            
        }

        public void AfficherArticle()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");
            string nomArticle = this.Produit.ToString();
            string[] nomArticle_ = nomArticle.Split(".");
            Console.WriteLine();
            Console.WriteLine("Type d'article: "+nomArticle_.Last()); //Affiche le type de l'article: Fleur ou Bouquet
            Console.WriteLine($"Quantité: {Quantite}\nSous-total: {sousTotal}\n");
            Console.WriteLine("--------------------------");
            Console.WriteLine();
            Console.WriteLine($"Sous total : {sousTotal} CAD");
        }

        public void AfficherArticlePourCommande()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------");
            string nomArticle = this.Produit.ToString();
            string[] nomArticle_ = nomArticle.Split(".");
            Console.WriteLine();
            Console.WriteLine("Type d'article: " + nomArticle_.Last()); //Affiche le type de l'article: Fleur ou Bouquet
            Console.WriteLine($"Quantité: {Quantite}");
        }
    }
}
