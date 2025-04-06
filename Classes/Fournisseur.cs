using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionMagasinFleurs.Classes; 

namespace GestionMagasinFleurs
{
    internal class Fournisseur : Utilisateur
    {
        public string Contact { get; set; }

        //public Fournisseur() { }
        public Fournisseur(int id, string nom, string email, int motDepasse,string contact)
            : base(id, nom, email, motDepasse)
        {
            Contact = contact;
            this.Role = RoleUtilisateur.fournisseur;
        }
        public void ApprovisionnerFleurs(MagasinFleur magasin, List<Fleur> nouveauStock)
        {
            foreach (Fleur fleur in nouveauStock)
            {
                magasin.stockFleur.Add(fleur);
            }
        }


    }
}
