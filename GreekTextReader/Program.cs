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

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Which Secntence Would You Like To Read");
            var sentenceNumber = Console.ReadLine();

            var file = @"C:\Users\IWANOS\source\repos\Console-Greek-Text-Reader\GreekTextReader\texts\stoa0033a.tlg028.1st1K-grc1.xml";

            var sentence = ReadSentence(file, sentenceNumber);

            foreach (var word in sentence)
            {
                Console.Write($"{word.item} ");                
            }
            Console.WriteLine("\n =======Type Word Number To Get Parsing Info======");
            var wordNumber = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"\nReadable Code: {ParseInterpreter(sentence[wordNumber].parseInfo)}");
            Console.WriteLine($"Word is: {sentence[wordNumber].item}");
            Console.Read();
        }

        static string ParseInterpreter(string parseInfo)
        {
            parseInfo.ToArray();

            string interpretedCode = "";

            for (int i = 0; i < parseInfo.Count(); i++)
            {
                if (i == 0)
                switch (parseInfo[i])
                {
                    case 'n':
                            interpretedCode = "noun ";
                            break;
                    case 'v':
                            interpretedCode = "verb ";
                            break;
                    case 'a':
                            interpretedCode = "adjective ";
                            break;
                    case 'd':
                            interpretedCode = "adverb ";
                            break;
                    case 'l':
                            interpretedCode = "article ";
                            break;
                    case 'g':
                            interpretedCode = "particle ";
                            break;
                    case 'c':
                            interpretedCode = "conjuction ";
                            break;
                    case 'r':
                            interpretedCode = "preposition ";
                            break;
                    case 'p':
                            interpretedCode = "pronoun ";
                            break;
                    case 'm':
                            interpretedCode = "numeral ";
                            break;
                    case 'i':
                            interpretedCode = "interjection ";
                            break;
                    case 'u':
                            interpretedCode = "punctuation ";
                            break;
                }
                if(i == 1)
                switch (parseInfo[i])
                {
                    case '1':
                            interpretedCode += "first person ";
                            break;
                    case '2':
                            interpretedCode += "second person ";
                            break;
                    case '3':
                            interpretedCode += "third person ";
                            break;
                }
                if(i == 2)
                switch (parseInfo[i])
                {
                    case 's':
                            interpretedCode += "singular ";
                            break;
                    case 'p':
                            interpretedCode += "plural ";
                            break;
                    case 'd':
                            interpretedCode += "dual ";
                            break;
                }
                if(i == 3)
                switch (parseInfo[i])
                {
                    case 'p':
                            interpretedCode += "present ";
                            break;
                    case 'i':
                            interpretedCode += "imperfect ";
                            break;
                    case 'r':
                            interpretedCode += "perfect ";
                            break;
                    case 'l':
                            interpretedCode += "pluperfect ";
                            break;
                    case 't':
                            interpretedCode += "future perfect ";
                            break;
                    case 'f':
                            interpretedCode += "future ";
                            break;
                    case 'a':
                            interpretedCode += "aorist ";
                            break;
                }
                if (i == 4)
                switch (parseInfo[i])
                {
                    case 'i':
                            interpretedCode += "indicative ";
                            break;
                    case 's':
                            interpretedCode += "subjunctive ";
                            break;
                    case 'o':
                            interpretedCode += "operative ";
                            break;
                    case 'n':
                            interpretedCode += "infinitive ";
                            break;
                    case 'm':
                            interpretedCode += "imperative ";
                            break;
                    case 'p':
                            interpretedCode += "participle ";
                            break;
                }
                if (i == 5)
                switch (parseInfo[i])
                {
                    case 'a':
                            interpretedCode += "active ";
                            break;
                    case 'p':
                            interpretedCode += "passive ";
                            break;
                    case 'm':
                            interpretedCode += "middle ";
                            break;
                    case 'e':
                            interpretedCode += "medio-passive ";
                            break;
                }
                if (i == 6)
                switch (parseInfo[i])
                {
                    case 'm':
                            interpretedCode += "masculine ";
                            break;
                    case 'f':
                            interpretedCode += "feminine ";
                            break;
                    case 'n':
                            interpretedCode += "neuter ";
                            break;
                }
                if (i == 7)
                switch (parseInfo[i])
                {
                    case 'n':
                            interpretedCode += "nominitive ";
                            break;
                    case 'g':
                            interpretedCode += "genitive ";
                            break;
                    case 'd':
                            interpretedCode += "dative ";
                            break;
                    case 'a':
                            interpretedCode += "accusative ";
                            break;
                    case 'v':
                            interpretedCode += "vocative ";
                            break;
                    case 'l':
                            interpretedCode += "locative ";
                            break;
                }
                if (i ==8)
                switch (parseInfo[i])
                {
                    case 'c':
                            interpretedCode += "comparative ";
                            break;
                    case 's':
                            interpretedCode += "superlative ";
                            break;
                }

            }
            return interpretedCode;
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

                            sentenceItem.item = WordReader(reader.ReadSubtree());

                            fullSentence.Add(sentenceItem);

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

//for (int i = 0; i<parseMatrixOne.Count(); i++)
//            {
//                if (parseMatrixOne[i] == part)
//                {
//                    Console.WriteLine()
//                }
//            }

//            for (int i = 0; i<parseMatrixTwo.Count(); i++)
//            {
//                if (parseMatrixTwo[i] == part)
//                {

//                }
//            }
//            for (int i = 0; i<parseMatrixThree.Count(); i++)
//            {
//                if (parseMatrixThree[i] == part)
//                {

//                }
//            }

//            for (int i = 0; i<parseMatrixFour.Count(); i++)
//            {
//                if (parseMatrixFour[i] == part)
//                {

//                }
//            }
//            for (int i = 0; i<parseMatrixFive.Count(); i++)
//            {
//                if (parseMatrixFive[i] == part)
//                {

//                }
//            }
//            for (int i = 0; i<parseMatrixSix.Count(); i++)
//            {
//                if (parseMatrixSix[i] == part)
//                {

//                }
//            }
//            for (int i = 0; i<parseMatrixSeven.Count(); i++)
//            {
//                if (parseMatrixSeven[i] == part)
//                {

//                }
//            }
//            for (int i = 0; i<parseMatrixEight.Count(); i++)
//            {
//                if (parseMatrixEight[i] == part)
//                {

//                }
//            }
//            for (int i = 0; i<parseMatrixNine.Count(); i++)
//            {
//                if (parseMatrixNine[i] == part)
//                {

//                }
//            }
//char[] parseMatrixOne = new char[12] {'n', 'v', 'a', 'd', 'l', 'g', 'c', 'r', 'p', 'm', 'i', 'u' };
//char[] parseMatrixThree = new char[3] { 's', 'p', 'd' };
//char[] parseMatrixTwo = new char[3] { '1', '2', '3' };
//char[] parseMatrixFour = new char[7] { 'p', 'i', 'r', 'l', 't', 'f', 'a' };
//char[] parseMatrixFive = new char[6] { 'i', 's', 'o', 'n', 'm', 'p' };
//char[] parseMatrixSix = new char[4] { 'a', 'p', 'm', 'e' };
//char[] parseMatrixSeven = new char[3] { 'm', 'f', 'n' };
//char[] parseMatrixEight = new char[6] { 'n', 'g', 'd', 'a', 'v', 'l' };
//char[] parseMatrixNine = new char[2] { 'c', 's' };