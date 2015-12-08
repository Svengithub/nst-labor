using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace semantic_web_3._0
{
    class Woerter
    {
        private String[] inhalt;
        private String pfad;
       
        
        public Woerter(String pfad) {

            setpfad(pfad);
            oeffne_datei();

            /* pruefe_wort test
            if (pruefe_wort("abc") == true)
                Console.WriteLine("true");
            else Console.WriteLine("false");
            */
        }
       


        private void oeffne_datei()
        {
           string text = System.IO.File.ReadAllText(getpfad());

           char komma = ',';
          
          // Console.WriteLine(text);
          
           inhalt = text.Split(komma);

           for (int i = 0; i < inhalt.Length; i++)
           {

              
               inhalt[i] = inhalt[i].Replace("\r\n", "");
            

           }

         
                             
        }

        public Boolean pruefe_wort(String wort){

            for (int k = 0; k < inhalt.Length; k++) {
               
                if (wort.ToLower().Equals(inhalt[k].ToLower()))
                {
                    return true;
                    

                }
                            
            }
            return false;
            
        }

        private void setpfad(string pfad) {
            this.pfad = pfad;
        }

       private string getpfad() {
            return this.pfad;
        }

    
         /* Check ob Textdatei eingelesen und gesplittet wird (muss in Main eingefügt werden)
          * Woerter check = new Woerter("C:\\Users\\Sven\\Desktop\\test.txt");
            for (int i = 0; i < check.inhalt.Length; i ++)
            {
                System.Console.WriteLine(check.inhalt[i]);
            }
        */

      public void listenerweiterung (String wort){

          var app = new Word.Application();
          string word = wort;
          var synInfo = app.SynonymInfo[wort, Word.WdLanguageID.wdGerman];

          string[] therasus = getAllMeanings(app, word);

          string[] new_words = new String[therasus.Length];

          int t=0;

          for (int i = 0; i < therasus.Length; i++)
          {
              therasus[i] = therasus[i] + ',';
          }
          for (int i = 0; i < inhalt.Length; i++)
          {
              inhalt[i] = inhalt[i] + ',';
          }


          
              for (int i = 0; i < therasus.Length; i++)
              {
                  
                  
                  int j;
                  for ( j= 0; j < inhalt.Length; j++)
                  {

                      if (inhalt[j] == therasus[i])
                      {
                          break;
                      }
                      
                      
                  }
                  if (j == inhalt.Length)
                  {
                      new_words[t] = therasus[i];
                      t++;
                  }


              }
          


     

         /* for (int k = 0; k < new_words.Length; k++)
          {
              new_words[k] = new_words[k] + ',';
          }
          */

         System.IO.File.AppendAllLines(@"C:\\Users\\Sven\\Desktop\\test.txt", new_words);


    }

       private static string[] getAllMeanings(Word.Application wordApp, string word, int maxSize = 12, bool addOriginal = false)
       {
           List<string> stringArr = new List<string>();
           if (addOriginal) stringArr.Add(word);
           var theSynonyms = wordApp.SynonymInfo[word];

           foreach (var Meaning in theSynonyms.MeaningList as Array)
           {
               if (stringArr.Contains(Meaning) == false) stringArr.Add((string)Meaning);
           }
           for (int ii = 0; ii < stringArr.Count; ii++)
           {
               theSynonyms = wordApp.SynonymInfo[stringArr[ii]];
               foreach (string Meaning in theSynonyms.MeaningList as Array)
               {
                   if (stringArr.Contains(Meaning)) continue;
                   stringArr.Add(Meaning);
               }
               if (stringArr.Count >= maxSize) return stringArr.ToArray();
           }
           return stringArr.ToArray();
       }



    }
}
