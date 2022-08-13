using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbeitszeitaufzeichnung
{
    // Create new an erster Position in der TimeList-> Error
    // Pausenzeiten abziehen -> Fehler in Berechnung bei 6h-6,5h

    // ToDo
    // Buttons verschönern
    // Zeitkorrekturantrag(Gehen am Folgetag)
    // Admin Änderungsbestätigung
    // Urlaub beantragen
    // Urlaub vom Admin genehmigen
    // ZA, Krankenstand
    // Monatssoll
    // Resturlaubstage
    // Kernzeitverletzung
    // Berechnung vom Gehalt
    // Abend/ Nachtpauschale/Samstagszuschlag 150%
    // Sonntags/Feiertagszuschlag
    // Dienstreise

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
