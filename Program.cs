using GestionMagasinFleurs;
using GestionMagasinFleurs.Classes;
using Newtonsoft.Json;
using System.Reflection;

//Instanciation des utilisateurs
Utilisateur u1 = new Proprietaire(1, "Zitraaf", "zitraafbasics@gmail.com", 0000);
Utilisateur u2 = new Client(1, "Ivan", "i", 1);
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
                Console.WriteLine("Que voulez-vous faire ?");
                Console.WriteLine();
                Client c1 = (Client)utilisateurConnecté;

                int preference = c1.IndiquerPreferences();

                switch(preference)
                {
                    case 1:
                    Console.WriteLine();
                    AffichageCentrale("***** FLEURS DISPONIBLES *****");
                    boutique.AfficherStock();
                    break;

                    case 2:
                         List<Article> articles = new List<Article>();
                        Console.Clear();
                        articles.Add(c1.SelectionnerFleur(boutique.stockFleur));
                        Commande commande = new Commande(1,c1,(Vendeur)u3);
                        commande.AjouterArticle(articles[0]);
                        c1.PasserCommandeFleur(commande);
                        Console.WriteLine();
                        break;

                    case 3:
                        
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
                            Console.WriteLine("Entrez le numero de la fleur suivante ou f pour terminer la selection:");
                            choix = Console.ReadLine();
                        }

                        Console.WriteLine("Veuillez entrer le nom du destinataire");
                        string nom = Console.ReadLine();
                        Console.WriteLine("Veuillez entrer le message");
                        string messageCarte = Console.ReadLine();
                        Bouquet bouquet = new Bouquet(choixFleurs, nom, messageCarte);
                        Console.WriteLine();

                        Console.WriteLine("Voici votre bouquet :");
                        bouquet.Afficher();

                        Console.WriteLine("Voulez-vous stocker ce bouquet comme modèle ? (o/n)");
                        char choixEnregistrer = char.ToLower(Console.ReadKey().KeyChar);
                        Console.WriteLine();
                        if (choixEnregistrer == 'o')
                        {
                            Console.WriteLine("Veuillez entrer un nom pour le bouquet\n");
                            string nomBouquet = Console.ReadLine();
                            Console.WriteLine();
                            var m1 = bouquet.ConvertirEnModele(nomBouquet);
                            m1.StockerModele();
                        }
                        Article articleBouquet = bouquet.ConvertirEnArticle(1, 1);
                        var commande_ = new Commande(2, c1, (Vendeur)u3);
                        commande_.AjouterArticle(articleBouquet);
                        c1.PasserCommandeBouquet(commande_);
                        break;

                case 4:
                        List<ModeleBouquet> modelesDispo = ModeleBouquet.ChargerTousModeles();
                        int i = 0;
                        int a = 0;
                        foreach (var modele in modelesDispo)
                        {
                            if (modele == null || modele.Bouquet == null )
                            {
                                Console.WriteLine("Le modele ");
                            }
                            a++;
                        }
                        Console.WriteLine();
                        Console.WriteLine();
                        foreach(ModeleBouquet modele in modelesDispo)
                        {
                            Console.Write($"{i + 1}");
                            modele.Afficher();
                            i++;
                        }
                        Console.WriteLine();
                        Console.WriteLine("Veuillez entrez les numeros de bouquets correspondant a votre choix\n");
                        Console.WriteLine("Entrez f pour terminer la selection\n");
                        List<Article> choixBouquet = new List<Article>();

                        string choix_ = Console.ReadLine();

                        while (choix_ != "f")
                        {
                            int c = int.Parse(choix_);
                            Console.WriteLine("Quel quantite voulez-vous?");
                            int quantite = int.Parse(Console.ReadLine());

                            Bouquet b = modelesDispo[c - 1].ConvertirEnBouquet();

                            choixBouquet.Add(modelesDispo[c - 1].ConvertirEnBouquet().ConvertirEnArticle(1,quantite));

                            modelesDispo.RemoveAt(c - 1);
                            Console.WriteLine("Entrez le numero du bouquet suivant ou f pour terminer la selection:");
                            choix_ = Console.ReadLine();
                            
                            
                        }
                        var cmd = new Commande(2, c1, (Vendeur)u3);
                        cmd.AjouterArticle(choixBouquet[0]);
                        c1.PasserCommandeBouquet(cmd);

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
            char continuer = 'o';
            Console.Clear();
            AffichageCentrale("***** BIENVENUE VENDEUR  *****");
            while (continuer == 'o')
            {
                Console.WriteLine();
                Console.WriteLine("Que voulez-vous faire ?");
                Console.WriteLine();
                Console.WriteLine("1. Suivre une commande");
                Console.WriteLine("2. Quitter\n\n");

                // Demander le choix de l'utilisateur
                Console.WriteLine("Votre choix : \n");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("**************************************************************");
                        Console.WriteLine("******************   Commandes en cour    ********************");
                        Console.WriteLine("**************************************************************");
                        Console.WriteLine();
                        List<Commande> commandesEnCours = Commande.ImporterToutesLesCommandes();
                        
                        foreach(Commande c in commandesEnCours)
                        {
                            c.AfficherCommande();
                        }
                        Console.WriteLine();
                        Console.WriteLine("Veuiller entrer le chiffre correspondant a l'ID de la commande");
                    Console.WriteLine();
                    int iDcommandeAsuivre = int.Parse(Console.ReadLine());
                    Commande commandeAsuivre = commandesEnCours[iDcommandeAsuivre-1];
                    Console.WriteLine("Veuller entrer 'v' pour valider ou 'a' pour annuler");
                    Console.WriteLine();
                    char choix_ = char.ToLower(Console.ReadKey().KeyChar);
                    if (choix_ == 'v')
                    {
                        commandeAsuivre.Etat = Enum.Parse<EtatCommande>("Validée");
                        Console.WriteLine();
                        Facture facture = new Facture();
                        facture.PrixTotal = commandeAsuivre.Montant;
                        TypePaiement tP = commandeAsuivre.ModePaiement;
                        facture.ModePaiement = tP;
                        foreach (Article a in commandeAsuivre.Articles)
                        {
                            facture.Articles.Add(a);
                        }
                        facture.ImprimerFacture();
                    }

                    else if (choix_ == 'a')
                    {
                        commandesEnCours.Remove(commandeAsuivre);
                        Console.WriteLine("Commande annulée");
                    }
                    else 
                        Console.WriteLine("Erreur de frappe");
                    break;

                    case "2":
                        continuer = 'n';
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        break;
                }
            }

    }
        else
        {
            Console.WriteLine("Bienvenue Fournisseur !");
            
        }
        //On  demande à l'utilisateur s'il souhaite continuer
        Console.WriteLine("Voulez-vous continuer ? (o/n)");
        arreter = char.ToLower(Console.ReadKey().KeyChar);
        
}