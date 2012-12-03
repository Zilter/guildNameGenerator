//This is a name generator written by Christian Stokkebekk in Des. 2012.

#include <stdlib.h>
#include <time.h>

#include <vector>
#include <fstream>
#include <iostream>
#include <string>


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
}