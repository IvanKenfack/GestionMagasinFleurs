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

            // Détecte le type concret basé sur les propriétés
            if (obj["Fleurs"] != null)  // Si c'est un Bouquet
            {
                return obj.ToObject<Bouquet>(serializer);
            }
            else if (obj["PrixUnitaire"] != null)  // Si c'est une Fleur
            {
                return obj.ToObject<Fleur>(serializer);
            }

            throw new JsonSerializationException("Type de produit non reconnu");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
