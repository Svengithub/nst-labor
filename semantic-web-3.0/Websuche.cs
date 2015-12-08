using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Services.Client;


namespace semantic_web_3._0
{
    class Websuche
    {
        private Beschreibung[] such_beschreibung;

        
        public Websuche()
        {
            such_beschreibung = new Beschreibung[50];
        }

        public Beschreibung[] get_sucheintraege() {
            return such_beschreibung;
        }

        public void suche(String suchwort)
        {

            string rootUri = "https://api.datamarket.azure.com/Bing/Search";
            var bingContainer = new Bing.BingSearchContainer(new Uri(rootUri));
            var accountKey = "/M/QCMxMmQNP//ZiC34P6He+k/Vq/nYm7rkcpDpQC+E";
            bingContainer.Credentials = new NetworkCredential(accountKey, accountKey);
            var searchQuery = bingContainer.Web(suchwort, null, null, "de-DE", null, null, null, null);
            var TextResults = searchQuery.Execute();
            foreach (var result in TextResults)
            {
                add_beschriebung(result.Title, result.Description);
            }            
        }

        private void add_beschriebung(String titel, String text) {
            for (int i = 0; i < such_beschreibung.Length; i++) {
                if (such_beschreibung[i] == null) {
                    such_beschreibung[i] = new Beschreibung(titel, text);
                    break;
                }
            }
        }

        
    }
}
