using GestionMagasinFleurs;
using GestionMagasinFleurs.Classes;
using Newtonsoft.Json;
using System.Reflection;

//Instanciation des utilisateurs
Utilisateur u1 = new Proprietaire(1, "Zitraaf", "zitraafbasics@gmail.com", 0000);
Utilisateur u2 = new Client(1, "Ivan", "ivan@gmail.com", 1234);
Utilisateur u3 = new Vendeur(1, "keni", "keni@gmail.com", 1000, 2000);
Utilisateur u4 = new Fournisseur(1, "Junior", "junior@gmail.com", 134, "0788888888");

//Création de la liste d'utilisateurs 
List<Utilisateur> utilisateurs = new List<Utilisateur>();
utilisateurs.Add(u1);
utilisateurs.Add(u2);
utilisateurs.Add(u3);
utilisateurs.Add(u4);


//Instanciation de la boutique
MagasinFleur boutique = new MagasinFleur("ZitraafFleurs");

//Fonction pour afficher le message de bienvenue, centré.
string message = "Bienvenue chez ZitraafFleurs!";
void AffichageCentrale(string message) 
{ 
    int largeurConsole = Console.WindowWidth;
    int position = (largeurConsole - message.Length) / 2;
    Console.WriteLine(new string(' ', position) + message);
}


//Boucle principale du programme

char arreter = 'o';
while (arreter == 'o')
    {
    Console.Clear();
    //Affichage du message de bienvenue
    AffichageCentrale(message);


    Utilisateur utilisateurConnecté = null;

    //Boucle pour l'authentification des utilisateurs
    do
    {
        Console.Write("Email : ");
        string email = Console.ReadLine();

        Console.Write("Mot de passe : ");
        int motDePasse = int.Parse(Console.ReadLine());

        utilisateurConnecté = Utilisateur.Authentifier(email, motDePasse, utilisateurs);

    } while (utilisateurConnecté == null);



        // Accès aux fonctionnalités selon le rôle
        if (utilisateurConnecté is Proprietaire)
        {
            char continuer = 'o';
            Console.Clear();
            AffichageCentrale("***** BIENVENUE PATRON  *****");
            while (continuer == 'o')
            {
                Console.WriteLine();
                Console.WriteLine("Que voulez-vous faire ?");
                Console.WriteLine();
                Console.WriteLine("1. Importer et Afficher le stock de fleurs");
                Console.WriteLine("2. Gérer la boutique");
                Console.WriteLine("3. Quitter");

                // Demander le choix de l'utilisateur avec validation
                Console.WriteLine("Votre choix : ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        Console.WriteLine();
                        boutique.AfficherStock();
                        break;

                    case "2":
                        // Gérer la boutique
                        Console.WriteLine("Gestion de la boutique...");

                        break;
                    case "3":
                        continuer = 'n';
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        break;
                }
            }

        }


        else if (utilisateurConnecté is Client)
        {
            
            char continuer = 'o';
            Console.Clear();
            AffichageCentrale("***** BIENVENUE  PARMIS NOUS, CHÈRE CLIENT  *****");
        while (continuer == 'o')
            {
                Console.WriteLine();
                AffichageCentrale("***** FLEURS DISPONIBLES *****");
                Console.WriteLine();
                boutique.AfficherStock();
                Console.WriteLine();
                Console.WriteLine("Que voulez-vous faire ?");
                Console.WriteLine();
                Client c1 = (Client)utilisateurConnecté;

                int preference = c1.IndiquerPreferences();

                switch(preference)
                {
                    case 1:
                        //Console.Clear();
                        //c1.articles.Add(c1.SelectionnerFleur(boutique.stockFleur));
                        //Commande commande = new Commande(1,c1,(Vendeur)u3);
                        //commande.AjouterArticle(c1.articles[0]);
                        //c1.PasserCommande(commande);
                        //Console.WriteLine();
                        break;

                    case 2:
                        Console.Clear();
                        boutique.AfficherStock();
                        Console.WriteLine();    
                        Console.WriteLine("Veuillez entrez les numeros de fleurs pour constituer votre bouquet :");
                        Console.WriteLine("Entrez f pour terminer la selection");
                        List<Fleur> choixFleurs = new List<Fleur>();

                        string choix = Console.ReadLine();
                        while ( choix != "f")
                        {
                            int choixFleur = int.Parse(choix);
                            choixFleurs.Add(boutique.stockFleur[choixFleur - 1]);
                            boutique.stockFleur.RemoveAt(choixFleur - 1);
                            Console.WriteLine("Entrez le numero de la fleur suivante :");
                            choix = Console.ReadLine();
                        }

                        Console.WriteLine("Veuillez entrer le nom du destinataire");
                        string nom = Console.ReadLine();
                        Console.WriteLine("Veuillez entrer le message");
                        string messageCarte = Console.ReadLine();
                        Bouquet bouquet = new Bouquet(choixFleurs, nom, messageCarte);
                        Console.WriteLine();

                    List<Article> ArticlePourCommade = new List<Article>();

                    Article articleUtilisateur = new Article()
                    {
                        ID = 9898,
                        Produit = bouquet, // Corrected this line
                        Quantite = 1,
                        sousTotal = bouquet.CalculerPrixTotal()
                    };

                    ArticlePourCommade.Add(articleUtilisateur);

                    Commande commandeDeUtilisateur = new Commande()
                    {
                        ID = 9898,
                        Client = (Client)u2,
                        Vendeur = (Vendeur)u3,
                        articles = ArticlePourCommade,
                        Montant = 978787,
                        ModePaiement = TypePaiement.carteDebit
                    };

                    string fichierJSON = "Commandes.json";
                    string modelesBouquets = File.ReadAllText(fichierJSON);

                    JsonConvert.DeserializeObject<List<Commande>>(modelesBouquetsList, new ProduitConverter());

                    modelesBouquetsList.Add(commandeDeUtilisateur);

                    //modelesBouquetsList.Add(bouquet);
                    string json = JsonConvert.SerializeObject(modelesBouquetsList, Formatting.Indented);
                    File.WriteAllText(fichierJSON, json);




                    Console.WriteLine("Voici votre bouquet :");
                        bouquet.Afficher();
                        Console.WriteLine();
                        Console.WriteLine("***************************************************");
                        Console.WriteLine();

                        Console.WriteLine("Prix total : " + bouquet.CalculerPrixTotal() + "CAD");
                        Console.WriteLine();

                        Console.WriteLine("Voulez-vous enregistrer ce bouquet comme modèle ? (o/n)");
                        char choixEnregistrer = char.ToLower(Console.ReadKey().KeyChar);
                        if (choixEnregistrer == 'o')
                        {
                            bouquet.StockerModeles(bouquet);
                            Console.WriteLine("Modèle enregistré avec succès !");
                        }
                        else
                        {
                            Console.WriteLine("Modèle non enregistré.");
                        }

                        //Article article = new Article(1, bouquet, 1);
                        //c1.articles.Add(article);
                        //Commande com1 = new Commande(1, c1, (Vendeur)u3);
                        //com1.AjouterArticle(c1.articles[0]);
                        //c1.PasserCommande(com1);
                        //Console.WriteLine();

                    break;
                        

                    case 3:
                      //  c1.articles.Add(c1.AcheterBouquet(boutique.stockFleur));
                        break;

                    case 4:
                        Console.WriteLine("Voici vos commandes :");
                       // c1.AfficherMesCommandes();
                        break;

                    case 5:
                        continuer = 'n';
                        break;
                    default:
                        Console.WriteLine("Choix invalide.");
                        break;
                }
               
            }

        }
        else if (utilisateurConnecté is Vendeur)
        {
            Console.WriteLine("Bienvenue Vendeur !");
            // Ajoutez ici les fonctionnalités spécifiques au vendeur
        }
        else
        {
            Console.WriteLine("Bienvenue Fournisseur !");
            // Ajoutez ici les fonctionnalités spécifiques au fournisseur
        }
        // Demander à l'utilisateur s'il souhaite continuer
        Console.WriteLine("Voulez-vous continuer ? (o/n)");
        arreter = char.ToLower(Console.ReadKey().KeyChar);
        //Console.ReadKey();
}