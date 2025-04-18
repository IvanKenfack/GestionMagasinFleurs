using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMagasinFleurs.Classes
{
    internal class ModeleBouquet
    {
        [JsonProperty("fleurs")]
        public List<Fleur> Fleurs { get; set; } = new List<Fleur>();

        [JsonProperty("carte")]
        public CartePersonalisée Carte { get; set; }

        [JsonProperty("prixTotal")]
        public float PrixTotal { get; set; }

        [JsonProperty("nomModele")]
        public string NomModele { get; set; }

        [JsonProperty("dateCreation")]
        public DateTime DateCreation { get; set; } = DateTime.Now;
        //private static string cheminFichier = "C:\\Users\\kenfa\\Desktop\\COURS\\HIVER 2025\\P.O.O 2\\Tavail_01\\modèlesBouquets.json";
        private static string cheminFichier = "C:\\Users\\kenfa\\Desktop\\COURS\\HIVER 2025\\P.O.O 2\\Tavail_01\\GestionMagasinFleurs\\modèlesBouquets.json";
        public ModeleBouquet() { }

        public ModeleBouquet(Bouquet bouquet, string nomModele)
        {
            this.Fleurs = new List<Fleur>(bouquet.GetFleurs());
            this.Carte = bouquet.GetCarte();
            this.PrixTotal = bouquet.PrixUnitaire;
            this.NomModele = nomModele;
        }

        public Bouquet ConvertirEnBouquet()
        {
            Bouquet nB = new Bouquet();
            nB.bouquet = this.Fleurs;
            nB.carte = this.Carte;
            return nB;
        }

        public void StockerModele()
        {
            try
            {
                List<ModeleBouquet> tousLesModeles = new List<ModeleBouquet>();

                // Lire les modèles existants si le fichier existe  
                if (File.Exists(cheminFichier))
                {
                    string contenuFichier = File.ReadAllText(cheminFichier);
                    tousLesModeles = JsonConvert.DeserializeObject<List<ModeleBouquet>>(contenuFichier)
                                    ?? new List<ModeleBouquet>();
                }

                // Ajouter le modèle actuel  
                tousLesModeles.Add(this);

                var parametres = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                File.WriteAllText(cheminFichier, JsonConvert.SerializeObject(tousLesModeles, parametres));

                Console.WriteLine($"Modèle '{this.NomModele}' sauvegardé");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la sauvegarde : \n {ex.Message}");
            }
        }

        public static List<ModeleBouquet> ChargerTousModeles()
        {
            var modeles = new List<ModeleBouquet>();

            try
            {
                if (File.Exists(cheminFichier))
                {
                    var contenu = File.ReadAllText(cheminFichier);
                    modeles = JsonConvert.DeserializeObject<List<ModeleBouquet>>(contenu) ?? new List<ModeleBouquet>();
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Erreur lors de la lecture du fichier : \n{ex.Message}");
            }

            return modeles;
        }

        public void Afficher()
        {
            Console.WriteLine($"\nModèle : {this.NomModele}");
            Console.WriteLine($"Prix : {this.PrixTotal} CAD");
            Console.WriteLine("Fleurs incluses :");
            foreach (var fleur in this.Fleurs)
            {
                Console.WriteLine($"- {fleur.Nom}");
            }
            this.Carte.AfficherCarte();
        }
    }
}
