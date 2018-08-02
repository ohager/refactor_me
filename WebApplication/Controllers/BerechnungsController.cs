using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/berechnung")]
    public class BerechnungsController : Controller
    {

        private class Wert
        {
            public string Typ { get; set; }
            public decimal  Kosten { get; set; }
            public string  Anmerkung { get; set; }
        }

        static private List<Wert> Werte;
        
        static BerechnungsController()
        {
            //initialisiere Werte 
            var  wert1 = new Wert();
            wert1.Typ = "vorlaeufig";
            wert1.Kosten = (decimal)100.00;
            
            var  wert2 = new Wert();
            wert2.Typ = "vorlaeufig";
            wert2.Kosten = (decimal)10.00;

            var  wert3 = new Wert();
            wert3.Typ = "endgueltig";
            wert3.Kosten = (decimal)500.00;
                
            Werte = new List<Wert>();
            Werte.Add(wert1);                
            Werte.Add(wert2);                
            Werte.Add(wert3);                
        }     
        
        
        
        // GET api/values
        [HttpGet("kalkuliere")]
        public decimal Get([FromQuery] string typ)
        {
            decimal ergebnis = 0;
                      
            if (typ == "vorlaeufig")
            {
                foreach (var wert in Werte)
                {
                    if (wert.Typ == "vorlaeufig")
                    {
                        ergebnis = ergebnis + wert.Kosten;
                    }
                }   
            }
            else if (typ == "endgueltig")
            {
                foreach (var wert in Werte)
                {
                    if (wert.Typ == "endgueltig")
                    {
                        ergebnis = (ergebnis + wert.Kosten) * (decimal)1.2;
                    }
                }
            }

            return ergebnis;
        }

      
    }
}