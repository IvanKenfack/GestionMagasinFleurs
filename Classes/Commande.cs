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

        public DateTime DateCommande { get; set; }

        public Vendeur Vendeur { get; set; }

        public float Montant { get; set; }

        public List<Article> articles = new List<Article>();

        public Commande(int ID, EtatCommande etat, Client client, DateTime dateCommande, Vendeur vendeur)
        {
            this.ID = ID;
            this.Etat = etat;
            this.Client = client;
            this.DateCommande = dateCommande;
            this.Vendeur = vendeur;
            this.Montant = this.CalculerMontant();
        }

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
            Console.WriteLine("Client: " + Client);
            Console.WriteLine("Date de commande: " + DateCommande);
            Console.WriteLine("Vendeur: " + Vendeur);
            Console.WriteLine();
        }

        public void AjouterProduit(Article article)
        {
            articles.Add(article);
        }

        public float CalculerMontant()
        {
            float montant = 0;
            foreach (Article article in articles)
            {
                if (article.Produit is Fleur)
                {
                    Fleur fleur = (Fleur)article.Produit;
                    montant += fleur.PrixUnitaire * fleur.Quantité;
                }
                else if (article.Produit is Bouquet)
                {
                    Bouquet bouquet = (Bouquet)article.Produit;
                    montant += bouquet.PrixTotal;
                }
            }
            return montant;
        }
    }
}
