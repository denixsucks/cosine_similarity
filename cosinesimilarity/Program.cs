using System;
using System.Linq;
using System.Net.Http.Headers;

namespace cosinesimilarity
{
    class Program
    {
        static void Main(string[] args)
        {
            //Kullanıcıdan veri alma ve kelimeleri teker teker diziye aktarma
            Console.WriteLine("İlk Dökümanı giriniz:");
            string doc1 = Console.ReadLine();
            string[] dokuman1 = doc1.Split(" "); 
            Console.WriteLine("İkinci Dökümanı giriniz:");
            string doc2 = Console.ReadLine();
            string[] dokuman2 = doc2.Split(" ");

            //kelimelerin bir diziye tekrar etmeden aktarılması

            var kelimeler = dokuman1.Union(dokuman2).ToArray();


            //kelimelerin ne kadar tekrar edildiğinin bulunması

            int[] tekrar1 = new int[kelimeler.Length];
            int[] tekrar2 = new int[kelimeler.Length];

            for (int i = 0; i < kelimeler.Length; i++)
            {
                for (int k = 0; k < dokuman1.Length; k++)
                {
                    var esit = string.Compare(kelimeler[i],dokuman1[k]);
                    if (esit == 0) 
                    {
                        tekrar1[i] += 1;
                    }
                }
            }

            for (int l = 0; l < kelimeler.Length; l++)
            {
                for (int m = 0; m < dokuman2.Length; m++)
                {
                    var esit = String.Compare(kelimeler[l], dokuman2[m]);
                    if (esit == 0)
                    {
                        tekrar2[l] += 1;
                    }
                }
            }




            //matematik

            //dot(d1,d2)
           
            int[] dot = new int[kelimeler.Length];
            for (int a = 0; a < kelimeler.Length; a++)
            {
                dot[a] = tekrar1[a] * tekrar2[a];
            }
            for (int b = 1; b < kelimeler.Length; b++)
            {
                dot[0] += dot[b];
            }

            // ||d1||  ||d2||

            double d1 = 0;
            double d2 = 0;

            for (int c = 0; c < kelimeler.Length; c++)
            {
                d1 += tekrar1[c] * tekrar1[c];
                d2 += tekrar2[c] * tekrar2[c];
            }

            d1 = Math.Sqrt(d1);
            d2 = Math.Sqrt(d2);


            double cos = dot[0] / (d1 * d2);
          

            Console.WriteLine("Kosinüs Benzerliğiniz :");
            Console.WriteLine(cos);
        }
    }
}
