using GestionMagasinFleurs.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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

        public void PasserCommandeFleur(Commande commande)
        {
            try
            {
                List<Commande> tousLesCommandes = new List<Commande>();
                string cheminFichier = Path.GetFullPath("CommandesFleurs.json");

                // Lire les commandes existantes si le fichier existe  
                if (File.Exists(cheminFichier))
                {
                    string contenuFichier = File.ReadAllText(cheminFichier);
                    tousLesCommandes = JsonConvert.DeserializeObject<List<Commande>>(contenuFichier)
                                    ?? new List<Commande>();
                }

                // Ajouter la commande actuel  
                tousLesCommandes.Add(commande);
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    Formatting = Formatting.Indented,
                    TypeNameHandling = TypeNameHandling.Auto,
                    //Converters = new List<JsonConverter> { new ConvertisseurProduit(), new StringEnumConverter() }
                };

                string json = JsonConvert.SerializeObject(tousLesCommandes, settings);
                File.WriteAllText(cheminFichier, json);
                Console.WriteLine("Commande passée avec succès !");
                Console.WriteLine();
            }

            catch (JsonException ex)
            {
                Console.WriteLine($"Erreur lors du passage de la commande : \n\n\n{ex.Message}");
            }
        }

        public void PasserCommandeBouquet(Commande commande)
        {
            try
            {
                List<Commande> tousLesCommandes = new List<Commande>();
                string cheminFichier = Path.GetFullPath("CommandesBouquets.json");

                // Lire les commandes existantes si le fichier existe  
                if (File.Exists(cheminFichier))
                {
                    string contenuFichier = File.ReadAllText(cheminFichier);
                    tousLesCommandes = JsonConvert.DeserializeObject<List<Commande>>(contenuFichier)
                                    ?? new List<Commande>();
                }

                // Ajouter la commande actuel  
                tousLesCommandes.Add(commande);
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    Formatting = Formatting.Indented,
                    TypeNameHandling = TypeNameHandling.Auto,
                };

                string json = JsonConvert.SerializeObject(tousLesCommandes, settings);
                File.WriteAllText(cheminFichier, json);
                Console.WriteLine("Commande passée avec succès !");
                Console.WriteLine();
            }

            catch (JsonException ex)
            {
                Console.WriteLine($"Erreur lors du passage de la commande : \n\n\n{ex.Message}");
            }
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
            Console.WriteLine("1. Afficher le catalogue des Fleurs\n");
            Console.WriteLine("2. Commander une seul fleur\n");
            Console.WriteLine("3. Constituer et commander un bouquet\n");
            Console.WriteLine("4. Commander un bouquet parmis ceux disponibles\n");
            Console.WriteLine("5. Quitter\n");
            int choix = int.Parse(Console.ReadLine());
            return choix;
        }

    }
}
