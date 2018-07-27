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




            //for (int i = 0; i < sentenceOutput.Count; i++)
            //{
            //    Console.WriteLine($"Word: {sentenceOutput[i].sentenceWord}");
            //    Console.WriteLine($"Parsing: {sentenceOutput[i].parseInfo}");
            //    Console.WriteLine($" Sentence: { sentenceOutput[i].sentenceNumber}");
            //}

            //for (int i = 0; i < sentenceOutput.Count; i++)
            //{
            //}

            Console.Read();
        }

        static void streaming(string file) { }
    }
}

        
