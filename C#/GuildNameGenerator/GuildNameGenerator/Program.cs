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

/*
//This is a name generator written by Christian Stokkebekk in Des. 2012.
std::vector<std::string> readFile (std::string filename);

int main() 
{
	srand(time(NULL));
	int numberOfNames = 24; //As many as fits my default window size
	int prefixChance = 40;
	int adjectiveChance = 60;
	int suffixChance = 30;

	std::vector<std::string> prefix = readFile("prefix.txt");
	std::vector<std::string> adjective = readFile("adjective.txt");
	std::vector<std::string> noun = readFile("noun.txt");
	std::vector<std::string> suffix = readFile("suffix.txt");

	for (int i = 0; i < numberOfNames; i++) 
	{
		if (rand() % 100 < prefixChance)
		{
			std::cout << prefix[rand() % prefix.size()] << " ";
		}

		if (rand() % 100 < adjectiveChance) {
			std::cout << adjective[rand() % adjective.size()] << " ";
		}

		std::cout << noun[rand() % noun.size()];
		
		if (rand() % 100 < suffixChance) {
			std::cout << " " << suffix[rand() % suffix.size()];
		}
		
		std::cout << "\n";
	}
		
	system("pause");
	return 0;
}


std::vector<std::string> readFile (std::string filename) 
{
	std::vector<std::string> readText;
	std::ifstream in(filename);
	std::string word;

	if(!in) 
	{
		std::cout << "Error opening " << filename << std::endl;
		system("pause");
	}

	while(std::getline(in, word)) 
	{
		readText.push_back(word);
	}
	
	return readText;
}*/