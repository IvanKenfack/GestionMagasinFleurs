using GestionMagasinFleurs.Classes;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMagasinFleurs
{
    internal class Commande
    {
        public int ID { get; set; }
                
        public EtatCommande Etat { get; set; }


        public Client Client { get; set; }

        public Vendeur Vendeur { get; set; }

        public float Montant { get; set; }

        public List<Article> articles;

        public TypePaiement ModePaiement { get; set; }

        public Commande(int ID,Client client, Vendeur vendeur)
        {
            this.ID = ID;
            this.Etat = EtatCommande.EnCours;
            this.Client = client;
            this.Vendeur = vendeur;
            this.articles = new List<Article>();
            this.Montant = 0;
            this.ModePaiement = client.ChoisirMoyenPaiement();
        }


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
            Console.WriteLine("ID: " + ID);
            Console.WriteLine("Etat: " + Etat);
            Console.WriteLine("Client: " + Client.Nom);
            Console.WriteLine("Vendeur: " + Vendeur.Nom);
            Console.WriteLine();
        }

        public void AjouterArticle(Article article)
        {
            articles.Add(article);
            Montant = CalculerMontant();

        }

        public float CalculerMontant()
        {
           return articles.Sum(article => article.CalculerSousTotal());
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
            foreach (Article article in articles)
            {
                article.AfficherArticle();
            }
        }
    }
}
