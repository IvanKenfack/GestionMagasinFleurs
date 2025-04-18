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
            return Produit.PrixUnitaire * Quantite;
            
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
            Console.WriteLine($"Sous total : {sousTotal} CAD");
        }
    }
}
