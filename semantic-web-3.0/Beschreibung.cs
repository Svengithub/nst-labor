using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semantic_web_3._0
{
    class Beschreibung
    {
        private String text;
        private String titel;
        private Woerter gut;
        private Woerter schlecht;
        private Woerter neutral;
        private int[] bewertung = { 0, 0};

        public Beschreibung(String titel, String text) {
            this.text = text;
            this.titel = titel.Trim();
            schlecht = new Woerter("C:\\Users\\Joshua\\Desktop\\schlecht.txt");
            gut = new Woerter("C:\\Users\\Joshua\\Desktop\\gut.txt");
            neutral = new Woerter("C:\\Users\\Joshua\\Desktop\\neutral.txt");
        }

        public String get_titel() {
            return this.titel;
        }

        public String get_text() {
            return this.text;
        }

        public int get_bewertung() {
            if ((bewertung[0] - bewertung[1]) > 0)
            {
                return 0;
            }
            else if ((bewertung[0] - bewertung[1]) < 0)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }


        private String[] cutter() {
            return text.Split(new Char[] {'.', '?', '!'});
        }

        private String[] replacer(String[] saetze) {
            String[] sonderzeichen = { ".", "!", "?", "&", "|", "//", "#", "*", "+", ",", "(", ")", "-", "+", "\"", "..", ";", "<", "«", "»"};
            for (int k = 0; k < saetze.Length; k++) {
                for (int i = 0; i < sonderzeichen.Length; i++)
                {
                    saetze[k] = saetze[k].Replace(sonderzeichen[i], "").Trim();
                }
            }
            return saetze;
        }

        private void check_satz(String[] satz) {
            for (int i = 0; i < satz.Length; i++) {
                //Console.WriteLine(satz[i]);
                if (gut.pruefe_wort(satz[i]) == true){
                    bewertung[0]++;
                    /*if (check_neutral(satz) == false) { 
                        bewertung[0]++;
                        break;
                    }else {
                        bewertung[1]++;
                       // for (int x = 0; x < satz.Length; x++) { Console.WriteLine(satz[x]);}
                        break;
                    }*/
                }else if (schlecht.pruefe_wort(satz[i]) == true){
                    /*if (check_neutral(satz) == false){
                        bewertung[1]++;
                        break;
                    }
                    else{
                        bewertung[0]++;
                        // for (int x = 0; x < satz.Length; x++) { Console.WriteLine(satz[x]); }
                        break;
                    }*/
                    bewertung[1]++;
                }
            }
        }

        private Boolean check_neutral(String[] satz) {
            for (int i = 0; i < satz.Length; i++) {
                if (neutral.pruefe_wort(satz[i]) == true) {
                    return true;
                }
            }
            return false;
        }

        private void check_me() {
            for (int i = 0; i < replacer(cutter()).Length; i++) {
                check_satz(replacer(cutter())[i].Split(' '));
            }
        }


        public void analyse()
        {
            check_me();
        }


    }
}
