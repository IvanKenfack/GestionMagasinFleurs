using GestionMagasinFleurs;

void Authentification()
{
    Console.WriteLine("Veuillez entrer votre nom d'utilisateur: ");
    string nomUtilisateur = Console.ReadLine();
    Console.WriteLine("Veuillez entrer votre mot de passe: ");
    string motDePasse = Console.ReadLine();
    if (nomUtilisateur == "admin" && motDePasse == "admin")
    {
        Console.WriteLine("Authentification réussie");
    }
    else
    {
        Console.WriteLine("Authentification échouée");
    }
}


Fleur fleur = new Fleur();
fleur.ImporterFleurs();
Console.ReadKey();