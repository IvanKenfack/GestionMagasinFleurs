using GestionMagasinFleurs.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMagasinFleurs
{
    internal class Facture
    {
        [JsonProperty("ID")]
        public int ID { get; set;}

        [JsonProperty("PrixTotal")]
        public float PrixTotal { get; set; }

        [JsonProperty("ModePaiement")]
        public TypePaiement ModePaiement { get; set; }

        [JsonProperty("DateFacture")]
        public DateTime DateFacture { get; set; } = DateTime.Now;

        [JsonProperty("Articles")]
        public List<Article> Articles { get; set; } = new List<Article>();

        

        public Facture()
        {
            
        }
        public void ImprimerFacture()
        {
            try{
              

                string cheminFichier = Path.GetFullPath("Facture.json");

                var parametres = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                File.WriteAllText(cheminFichier, JsonConvert.SerializeObject(this, parametres));

                Console.WriteLine($"Facture generée avec succèss");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la sauvegarde : \n {ex.Message}");
            }

        }
    }
}
