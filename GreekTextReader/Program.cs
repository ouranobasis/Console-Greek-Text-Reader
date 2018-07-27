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
            var sentenceOutput = streaming(file);




            for (int i = 0; i < sentenceOutput.Count; i++)
            {
                Console.Write($" {sentenceOutput[2].sentenceWord}");
            }

            for (int i = 0; i < sentenceOutput.Count; i++)
            {
                Console.Write(sentenceOutput[i].parseInfo);
            }

            Console.Read();
        }


        static List<Sentence> streaming(string file)
        {
            List<Sentence> fullSentence = new List<Sentence>();

            using (XmlReader reader = XmlReader.Create(file))
            {
                while (reader.Read() && reader.Value.Trim() != ".")
                {
                    Sentence currentSentence = new Sentence();
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "s":
                                currentSentence.sentenceNumber = Int32.Parse(reader["n"]);
                                break;
                            case "t":
                                string parseInfo = reader["o"];

                                if (parseInfo != null)
                                {
                                    Console.WriteLine("Parse Info: " + parseInfo);
                                    currentSentence.parseInfo = reader["o"];
                                }
                                break;
                            case "f":
                                if (reader.Read())
                                {
                                    Console.WriteLine("  Text node: " + reader.Value.Trim());
                                    currentSentence.sentenceWord = reader.Value.Trim();
                                }
                                break;
                        }
                    }
                    fullSentence.Add(currentSentence);
                }
            }
            return fullSentence;
        }
    }
}
