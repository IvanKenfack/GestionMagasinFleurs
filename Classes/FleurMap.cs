using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMagasinFleurs.Classes
{
    internal class FleurMap : ClassMap<Fleur>
    {
        public FleurMap()
        {
            Map(m => m.Nom).Name("Nom");
            Map(m => m.PrixUnitaire).Name("Prix Unitaire (CAD)");
            Map(m => m.Couleur).Name("Couleur");
            Map(m => m.Caractéristiques).Name("Caractéristiques");
        }
    }
}
