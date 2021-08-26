using System;
using System.Linq;

namespace cosinesimilarity
{
    class Program
    {
        public static void CosSimilarityPart1(int[] repeat, string[] strings, string[] document)
        {
            for (int i = 0; i < strings.Length; i++)
            {
                for (int k = 0; k < document.Length; k++)
                {
                    var esit = string.Compare(strings[i], document[k]);
                    if (esit == 0)
                    {
                        repeat[i] += 1;
                    }
                }
            }
        }

        public static void DotProduct(string[] strings, int[] repeat1, int[] repeat2, int[] dot) 
        {
            for  (int a = 0; a < strings.Length; a++)
            {
                dot[a] = repeat1[a] * repeat2[a];
            }
            for (int b = 1; b < strings.Length; b++)
            {
                dot[0] += dot[b];
            }
        }

        static void Main()
        {
            //Getting the input and splitting the strings into chars to an array

            Console.WriteLine("Enter the FIRST Document:");
            string doc1 = Console.ReadLine();        
            string[] document1 = doc1.Split(" "); 
            Console.WriteLine("Enter the SECOND Document:");
            string doc2 = Console.ReadLine();           
            string[] document2 = doc2.Split(" ");

            //Getting the strings into an array without being repeated.

            var strings = document1.Union(document2).ToArray();

            //Getting how often words are being repeated.

            int[] repeat1 = new int[strings.Length];
            int[] repeat2 = new int[strings.Length];

            CosSimilarityPart1(repeat1, strings, document1);
            CosSimilarityPart1(repeat2, strings, document2);
            
            //Some math things goin on, I can't really tell but you can easily check up with your search engine.

            int[] dot = new int[strings.Length];
            DotProduct(strings, repeat1, repeat2, dot);

            double d1 = 0, d2 = 0;

            for (int c = 0; c < strings.Length; c++)
            {
                d1 += repeat1[c] * repeat1[c];
                d2 += repeat2[c] * repeat2[c];
            }

            d1 = Math.Sqrt(d1);
            d2 = Math.Sqrt(d2);

            double cos = dot[0] / (d1 * d2);
          
            Console.WriteLine("Cosinus Similarity : ", cos);
        }
    }
}
