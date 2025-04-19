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

        public DateTime Date { get; set; } = DateTime.Now;

        public Commande(int ID,Client client, Vendeur vendeur)
        {
            this.ID = ID;
            this.Etat = EtatCommande.EnCours;
            this.Client = client;
            this.Vendeur = vendeur;
            this.Articles = new List<Article>();
            this.Montant = 0;
            this.ModePaiement = client.ChoisirMoyenPaiement();
            DateTime d = this.Date;
        }

        [JsonConstructor]
        public Commande() { }

        public void AfficherCommande()
        {
            Console.WriteLine();
            Console.WriteLine("ID: " + this.ID);
            Console.WriteLine();
            foreach (Article article in this.Articles)
            {
                article.AfficherArticlePourCommande();
            }    
            Console.WriteLine("Etat: " + this.Etat.ToString());
            Console.WriteLine("Client: " + Client.Nom);
            Console.WriteLine("Vendeur: " + Vendeur.Nom);
            Console.WriteLine("Montant Total: " + this.Montant);
            Console.WriteLine("Mode de paiement: " + this.ModePaiement.ToString());
            Console.WriteLine("Date de la Commande: " + this.Date);
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


        public static List<Commande> ImporterToutesLesCommandes()
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,  //Pour serialiser correctement l'interface IProduit
                Converters = new List<JsonConverter>
                {
                    //Pour la conversion des Enumerations
                    new StringEnumConverter()
                }
            }; 
            //Fichier commandes des fleurs
            string cheminFichierCommandesFleurs = Path.GetFullPath("CommandesFleurs.json");

            //Fichier commandes des Bouquets
            string cheminFichierCommandesBouquet = Path.GetFullPath("CommandesBouquets.json");

            List<Commande> commandes = new List<Commande>();


            try
            {
                // Lecture commandes fleurs
                string cheminFleurs = Path.GetFullPath("CommandesFleurs.json");

                if (File.Exists(cheminFleurs))
                {
                    string jsonFleurs = File.ReadAllText(cheminFleurs);
                    var cmdFleurs = JsonConvert.DeserializeObject<List<Commande>>(jsonFleurs) ?? new List<Commande>();

                    if (cmdFleurs != null) 
                    { 
                        foreach(Commande c in cmdFleurs)
                        {
                            commandes.Add(c);
                        }   
                    }
                }

                // Lecture commande bouquet
                string cheminBouquet = Path.GetFullPath("CommandesBouquets.json");

                if (File.Exists(cheminBouquet))
                {
                    string jsonBouquet = File.ReadAllText(cheminBouquet);
                    var cmdBouquet = JsonConvert.DeserializeObject<List<Commande>>(jsonBouquet) ?? new List<Commande>();
                    if (cmdBouquet != null)
                    {
                        foreach (Commande c in cmdBouquet)
                        {
                            commandes.Add(c);
                        }
                    }
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
