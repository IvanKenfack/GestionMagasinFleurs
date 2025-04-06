using GestionMagasinFleurs.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMagasinFleurs
{
    internal class Client : Utilisateur
    {
        // public List<Article> articles;
        public MoyenPaiement moyenPaiement;
        public Client(int id, string nom, string email, int motDepasse) 
            : base(id, nom, email, motDepasse)
        {
            this.Role = RoleUtilisateur.client;
            // articles = new List<Article>();
            //historiqueCommandes = new List<Commande>();
        }

        public Article SelectionnerFleur(List<Fleur> fleurs)
        {
            Console.WriteLine();
            Console.WriteLine("Entrez le numero de la fleur que vous souhaitez acheter :");
            int choix = int.Parse(Console.ReadLine());

            Console.WriteLine("Quels quantité de fleurs souhaitez-vous acheter ? :");
            int quantite = int.Parse(Console.ReadLine());

            if (choix > 0 && choix <= fleurs.Count)
            {
                Console.WriteLine($"Vous avez sélectionné : ");
                fleurs[choix - 1].Afficher();
                Console.WriteLine($"Quantité : {quantite}");
                
                Article article = new Article(choix, fleurs[choix - 1], quantite);
                
                fleurs.RemoveAt(choix - 1);
                Console.WriteLine("Prix total : " + article.sousTotal+"CAD");
                return article;

            }
            else
            {
                Console.WriteLine("Choix invalide.");
                return null;
            }

        }

        public void SelectionnerBouquet(string bouquet)
        {
            Console.WriteLine($"{Nom} a sélectionné le bouquet : {bouquet}");
        }

        public void PasserCommande(Commande commande)
        {
            List<Commande> historiqueCommandes = new List<Commande>();
            historiqueCommandes.Add(commande);
            string fichierJSON = "Commandes.json";
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            //string commandes = File.ReadAllText(fichierJSON);

            //List<Commande> commandesClient = JsonConvert.DeserializeObject<List<Commande>>(commande);

            //commandesClient.Add(commandes);
            string json = JsonConvert.SerializeObject(commande, Formatting.Indented);
            File.WriteAllText(fichierJSON, json);
            Console.WriteLine("Commande passée avec succès !");
        }

        public TypePaiement ChoisirMoyenPaiement()
        {
           Console.WriteLine("Veuillez Choisir votre moyen de paiement :\n");
            Console.WriteLine("1. Carte de crédit\n");
            Console.WriteLine("2. Espèces\n");
            Console.WriteLine("3. Carte de débit\n");
            int choix = int.Parse(Console.ReadLine());
            switch (choix)
            {
                case 1:
                    return TypePaiement.carteCredit;
                case 2:
                    return TypePaiement.Espèces;
                case 3:
                    return TypePaiement.carteDebit;
                default:
                    Console.WriteLine("Choix invalide.");
                    return ChoisirMoyenPaiement();
            }
        }


        public int IndiquerPreferences()
        {
            Console.WriteLine("1. Commander une seul fleur\n");
            Console.WriteLine("2. Constituer et commander un bouquet\n");
            Console.WriteLine("3. Commander un bouquet\n");
            Console.WriteLine("4. Consulter mes commandes\n");
            Console.WriteLine("5. Quitter\n");
            int choix = int.Parse(Console.ReadLine());
            return choix;
        }

    }
}
