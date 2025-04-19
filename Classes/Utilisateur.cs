using GestionMagasinFleurs.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMagasinFleurs
{
    internal abstract class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public int MotDepasse { get; set; }

        public  RoleUtilisateur Role { get; set;}
        public Utilisateur(int id, string nom, string email, int motDepasse)
        {
            Id = id;
            Nom = nom;
            Email = email;
            MotDepasse = motDepasse;
        }

        public static Utilisateur Authentifier(string email, int motDePasse, List<Utilisateur> utilisateurs)
        {
            foreach (var utilisateur in utilisateurs)
            {
                if (utilisateur.Email == email && utilisateur.MotDepasse == motDePasse)
                {
                    
                    return utilisateur;
                }
            }

            Console.WriteLine("Email ou mot de passe incorrect.");
            return null;
        }

        


    }
}
