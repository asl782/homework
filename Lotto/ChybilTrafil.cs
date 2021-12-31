using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    class ChybilTrafil
    {
        const int ileLiczb = 6;
        const int zakresLosowaniaMin = 1;
        const int zakresLosowaniaMax = 49;
                
        public static List<int>[] GenerujKupon(int ileZakladow)
        {
            var numery = new List<int>[ileZakladow];
            var random = new Random();
            
            for (int i = 0; i < ileZakladow; i++)
            {
                var lista = new List<int>();
              
                while (lista.Count < ileLiczb)
                {
                    int liczba = (random.Next(zakresLosowaniaMin, zakresLosowaniaMax + 1));
                    
                    if (!lista.Contains(liczba))
                    {
                        lista.Add(liczba);
                    }
                }

                lista.Sort();
                numery[i] = lista;
            }

            return numery;
        }
    }
}
