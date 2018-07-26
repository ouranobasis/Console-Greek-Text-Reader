using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreekTextReader
{
    class Program
    {
        public static int wordNumber = 0;
        public static XmlNodeList word;

        static void Main(string[] args)
        {
            //C: \Users\jpruitt\Desktop\Code Projects\LemmatizedAncientGreekXML\ConsoleApp1\ConsoleApp1\texts\stoa0033a.tlg028.1st1K - grc1.xml

            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("What text to read?");

            var file = Console.ReadLine();
            word = ReadXML(file, 0);

            printXML(word);
        }

        static void printXML(XmlNodeList word)
        {
            ConsoleKey nextWord = Console.ReadKey().Key;

            while(true)
            {
                while (word[wordNumber].InnerText != ".")
                {
                    if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                    {

                        Console.Write(word[wordNumber].InnerText);
                        wordNumber = wordNumber + 1;
                    }
                }
                Console.WriteLine("\n next sentence? Y/N");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    wordNumber = wordNumber + 1;
                    Console.Write(word[wordNumber].InnerText);
                }
            }
        }

        static XmlNodeList ReadXML(string file, int next)
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(file);

            XmlNodeList word = xmlDoc.GetElementsByTagName("f");
            return word;
        }
    }
}
