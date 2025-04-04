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

    }
}
