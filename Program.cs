using GestionMagasinFleurs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CsvHelper.Configuration.Attributes;
using CsvHelper;
using System.IO;


Fleur fleur = new Fleur("Rose", "Rouge", "Fleur de l'amour", 10);
fleur.ImporterFleurs();
Console.ReadKey();