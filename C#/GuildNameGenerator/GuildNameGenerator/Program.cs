using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GuildNameGenerator
{
    class Program
    {
        public static List<String> readIn(string fileName)
        {
            List<String> holder = new List<String>();
            using (StreamReader reader = new StreamReader(fileName)) // Have reader read the file, dispose of it when finished
            {
                string line; //Hold current line

                while ((line = reader.ReadLine()) != null) // Read the line, and if not null
                {
                    holder.Add(line); //Add the line to the List
                }

                return holder; //return this so we can set the lists equal to it

            }
        }

        static void Main(string[] args)
        {
            Random rand = new Random();

            List<String> prefix = readIn("prefix.txt");
            List<String> adjective = readIn("adjective.txt");
            List<String> noun = readIn("noun.txt");
            List<String> suffix = readIn("suffix.txt");

            for (int i = 0; i < 25; i++)
            {
                string pre = "", adj = "", nou = "", suf = "";

                if (rand.Next(100) < 40)
                    pre = prefix[rand.Next(prefix.Count)];
                if (rand.Next(100) < 60)
                    adj = adjective[rand.Next(adjective.Count)];

                nou = noun[rand.Next(noun.Count)];

                if (rand.Next() < 30)
                    suf = suffix[rand.Next(suffix.Count)];

                Console.WriteLine(pre + adj + nou + suf);
            }

            Console.ReadKey();
        }
    }
}