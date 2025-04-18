using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMagasinFleurs.Classes
{
    internal class ConvertisseurProduit : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IProduit);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);

            // Si l'objet a une propriété "bouquet", c'est un Bouquet
            if (obj["bouquet"] != null)
            {
                var bouquet = new Bouquet
                {
                    bouquet = obj["bouquet"].ToObject<List<Fleur>>(serializer),
                    carte = obj["carte"]?.ToObject<CartePersonalisée>(serializer)
                };
                return bouquet;
            }
            // Sinon, c'est une Fleur simple
            else if (obj["Nom"] != null && obj["PrixUnitaire"] != null)
            {
                return new Fleur
                {
                    Nom = obj["Nom"].ToString(),
                    PrixUnitaire = obj["PrixUnitaire"].Value<float>(),
                    Couleur = obj["Couleur"].ToString(),
                    Caractéristiques = obj["Caractéristiques"].ToString(),
                    Quantité = obj["Quantité"]?.Value<int>() ?? 0
                };
            }

            throw new JsonSerializationException("Type de produit non reconnu");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
