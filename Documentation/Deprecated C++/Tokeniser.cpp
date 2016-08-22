#include "Tokeniser.h"

using namespace std;


Tokeniser::Tokeniser(char separator)
{
	separatorCharacter = separator;
}


Tokeniser::~Tokeniser()
{
}

std::vector<std::string> Tokeniser::Tokenise(std::string Line)
{
	string CurrentToken = "";
	vector<string> ToBeReturned;
	for (unsigned int i = 0; i < Line.length(); ++i)
	{
		if (Line[i] != ' ' && Line[i] != ',' && Line[i] != '\n' && Line[i] != NULL)
		{
			CurrentToken += Line[i];
		}
		else
		{
			if (CurrentToken != "") ToBeReturned.push_back(CurrentToken);
			CurrentToken = "";
		}
	}

	return ToBeReturned;
}
