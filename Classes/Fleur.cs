using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CsvHelper.Configuration.Attributes;
using CsvHelper;
using CsvHelper.Configuration;
using GestionMagasinFleurs.Classes;

namespace GestionMagasinFleurs
{
    internal class Fleur : Produit
    {
        [Name("Nom")]
        public string Nom{ get; set;}

        [Name ("Prix Unitaire(CAD)")]
        public float PrixUnitaire { get; set; }

        [Name("Couleur")]
        public string Couleur { get; set; }

        [Name("Caractéristiques")]
        public string Caractéristiques { get; set; }

        public int Quantité { get; set; }

        private List<Fleur> fleurs = new List<Fleur>();

        public List<Fleur> Fleurs { get => fleurs;}

        public Fleur(string nom, string couleur,float prixUnitaire, string caractéristiques, int quantité)
        {
            this.Nom = nom;
            this.Couleur = couleur;
            this.PrixUnitaire = prixUnitaire;
            this.Caractéristiques = caractéristiques;
            this.Quantité = quantité;
        }


        /// Constructeur par défaut necessaire pour la lecture du CSV
        public Fleur()
        {
        }

        public void ImporterFleurs()
        {

            // Je recupère le chemin absolu du fichier CSV
            string fichierCSV = "C:\\Users\\kenfa\\OneDrive\\Desktop\\COURS\\HIVER 2025\\P.O.O 2\\Tavail_01\\fleurs_db.csv";

            using (var lecture = new StreamReader(fichierCSV))
            using (var csv = new CsvReader(lecture, CultureInfo.InvariantCulture))

            {
                csv.Context.RegisterClassMap<FleurMap>();
                var records = csv.GetRecords<Fleur>().ToList();
                int i = 0;
                foreach (Fleur fleur in records)
                {
                    fleurs.Add(fleur);
                    Console.WriteLine();
                    Console.WriteLine($"Fleur {i+1}\n\nNom : {fleur.Nom}\nCouleur : {fleur.Couleur}\nCaratéristiques : {fleur.Caractéristiques}\nPrix Unitaire : {fleur.PrixUnitaire}");
                    i++;
                    Console.WriteLine();
                }
            }
        }

        public override void Afficher()
        {   
            Console.WriteLine();
            Console.WriteLine($"Nom : {this.Nom}\nCouleur : {this.Couleur}\nCaratéristiques : {this.Caractéristiques}\nPrix Unitaire : {this.PrixUnitaire} CAD");
            Console.WriteLine();
        }
          
    }
}
