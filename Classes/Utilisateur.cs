using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMagasinFleurs
{
    internal class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public int MotDepasse { get; set; }

        public Utilisateur() { }
        public Utilisateur(int id, string nom, string email, int motDepasse)
        {
            Id = id;
            Nom = nom;
            Email = email;
            MotDepasse = motDepasse;
        }
        public void Authentification()
        {
            Console.WriteLine($"{Nom} est athentifié.");
        }
        public void Deconnexion()
        {
            Console.WriteLine($"{Nom} s'est déconnecté.");
        }

    }
}
