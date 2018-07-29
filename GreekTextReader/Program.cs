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
            Console.OutputEncoding = Encoding.UTF8;
            var file = @"C:\Users\IWANOS\source\repos\Console-Greek-Text-Reader\GreekTextReader\texts\stoa0033a.tlg028.1st1K-grc1.xml";

            var sentence = ReadSentence(file, "1");

            Console.Read();
        }

        static List<SentenceItem> ReadSentence(string file, string sentenceNumber)
        {
            List<SentenceItem> fullSentence = new List<SentenceItem>();

            using (XmlReader reader = XmlReader.Create(file))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement() && reader.Name == "s" && reader.GetAttribute("n") == sentenceNumber)
                    {
                        Console.WriteLine($"element name: {reader.Name}");
                        Console.WriteLine($"Sentence Number is: {reader.GetAttribute("n")}");
                        //Console.WriteLine(reader["n"]);

                        reader.ReadToDescendant("t");                       

                        do
                        {
                            Console.WriteLine($"element name: {reader.Name}");
                            SentenceItem sentenceItem = new SentenceItem();
                            sentenceItem.parseInfo = reader.GetAttribute("o");
                            Console.WriteLine($"Attribute is: {reader.GetAttribute("o")}");

                            WordReader(reader.ReadSubtree());

                            //fullSentence.Add(sentenceItem);

                        } while (reader.ReadToNextSibling("t"));

                    }
                }
            }
            return fullSentence;
        }

        static string WordReader(XmlReader wordReader)
        {
            string word = "";
            while (wordReader.Read())
            {
                if (wordReader.IsStartElement() && wordReader.Name == "f")
                {
                    wordReader.Read();
                    Console.WriteLine($"Word: {wordReader.Value.Trim()}");
                    word = wordReader.Value.Trim();
                }
            }
            return word;
        }
    }
}

        
