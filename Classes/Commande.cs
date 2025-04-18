using GestionMagasinFleurs.Classes;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMagasinFleurs
{
    internal class Commande
    {
        [JsonProperty("ID")]
        public int ID { get; set; }

        [JsonProperty("Etat")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EtatCommande Etat { get; set; }

        [JsonProperty("Client")]
        public Client Client { get; set; }

        [JsonProperty("Vendeur")]
        public Vendeur Vendeur { get; set; }

        [JsonProperty("Montant")]
        public float Montant { get; set; }

        [JsonProperty("articles")]
        public List<Article> Articles { get; set; }

        [JsonProperty("ModePaiement")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TypePaiement ModePaiement { get; set; }

        public Commande(int ID,Client client, Vendeur vendeur)
        {
            this.ID = ID;
            this.Etat = EtatCommande.EnCours;
            this.Client = client;
            this.Vendeur = vendeur;
            this.Articles = new List<Article>();
            this.Montant = 0;
            this.ModePaiement = client.ChoisirMoyenPaiement();
        }

        [JsonConstructor]
        public Commande() { }
        public void ValiderCommande()
        {
            this.Etat = EtatCommande.Validée              ;
        }

        public void AnnulerCommande()
        {
            this.Etat = EtatCommande.Annulée;
        }

        public void AfficherCommande()
        {
            Console.WriteLine();
            Console.WriteLine("ID: " + this.ID);
            Console.WriteLine("Etat: " + this.Etat.ToString());
            Console.WriteLine("Client: " + Client.Nom);
            Console.WriteLine("Vendeur: " + Vendeur.Nom);
            Console.WriteLine();
        }

        public void AjouterArticle(Article article)
        {
            Articles.Add(article);
            Montant = CalculerMontant();

        }

        public float CalculerMontant()
        {
           return Articles.Sum(article => article.CalculerSousTotal());
        }

        public void GenererFacture()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Facture de la commande:");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Etat: {Etat}");
            Console.WriteLine($"Client: {Client.Nom}");
            //Console.WriteLine($"Date de commande: {DateCommande}");
            Console.WriteLine($"Vendeur: {Vendeur.Nom}");
            Console.WriteLine($"Montant total: {Montant}");
            Console.WriteLine("--------------------------------------------------");
            foreach (Article article in Articles)
            {
                article.AfficherArticle();
            }
        }

        public static List<Commande> ImporterToutesLesCommandes()
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,  //Pour serialiser correctement l'interface IProduit
                Converters = new List<JsonConverter>
                {
                    new ConvertisseurProduit(),
                    new StringEnumConverter()
                }
            };

            string cheminFichier = Path.GetFullPath("Commandes.json");

            List<Commande> commandes = new List<Commande>();

            try
            {
                if (File.Exists(cheminFichier))
                {
                    var contenu = File.ReadAllText(cheminFichier);
                    commandes = JsonConvert.DeserializeObject<List<Commande>>(contenu) ?? new List<Commande>();
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Erreur lors de la lecture du fichier : \n{ex.Message}");
            }

            return commandes;
        }
    }
}
