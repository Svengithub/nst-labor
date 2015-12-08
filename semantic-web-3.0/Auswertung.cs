using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semantic_web_3._0
{
    class Auswertung
    {
        private Websuche suche;
        private String suchwort;

        public Auswertung(String suchwort) {
            suche = new Websuche();
            this.suchwort = suchwort;
            suche_start();
            start_analyse();
            start_auswertung();
        }

        private void suche_start() {
            suche.suche(this.suchwort);
        }

        private void start_analyse() {
            for (int i = 0; i < suche.get_sucheintraege().Length; i++) {
                suche.get_sucheintraege()[i].analyse();
            } 
        }

        private void start_auswertung() {
            int gut = 0;
            int schlecht = 0;
            int keineaussage = 0;
            for (int i = 0; i < suche.get_sucheintraege().Length; i++){
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Titel: "+suche.get_sucheintraege()[i].get_titel());
                Console.WriteLine("Text: " + suche.get_sucheintraege()[i].get_text());
                if (suche.get_sucheintraege()[i].get_bewertung() == 0) {
                    Console.WriteLine("Gut");
                    gut++;
                }
                if (suche.get_sucheintraege()[i].get_bewertung() == 1)
                {
                    Console.WriteLine("Schlecht");
                    schlecht++;
                }
                if (suche.get_sucheintraege()[i].get_bewertung() == 2)
                {
                    Console.WriteLine("Keine Aussage möglich!");
                    keineaussage++;
                }
                Console.WriteLine("-------------------------------\n\n");
            }
            Console.WriteLine("--Statistik--");
            Console.WriteLine("Gut: "+gut);
            Console.WriteLine("Schlecht: "+schlecht);
            Console.WriteLine("Keine Aussage: "+keineaussage);
        }



    }
}
