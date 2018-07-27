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
            var file = @"C:\Users\jpruitt\Desktop\Code Projects\LemmatizedAncientGreekXML\ConsoleApp1\ConsoleApp1\texts\stoa0033a.tlg028.1st1K-grc1.xml";
            //var sentenceOutput = streaming(file);


            var sentence = streaming(file, "1");

            //foreach (var word in sentence)
            //{
            //    Console.Write(word.item);
            //}
            

            Console.Read();
        }

        static List<SentenceItem> streaming(string file, string sentenceNumber)
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
                        Console.WriteLine($"element name: {reader.Name}");

                        do
                        {
                            SentenceItem sentenceItem = new SentenceItem();
                            sentenceItem.parseInfo = reader.GetAttribute("o");
                            Console.WriteLine($"Attribute is: {reader.GetAttribute("o")}");


                            reader.ReadToDescendant("f");
                            reader.Read();
                            sentenceItem.item = reader.Value.Trim();
                            Console.WriteLine($"Word is: {reader.Value}");
                            reader.Read();
                            reader.Read();

                            Console.WriteLine($"element name: {reader.Name}");
                            fullSentence.Add(sentenceItem);

                        } while (reader.ReadToNextSibling("t"));

                    }
                }
            }
            return fullSentence;
        }
    }
}

        
