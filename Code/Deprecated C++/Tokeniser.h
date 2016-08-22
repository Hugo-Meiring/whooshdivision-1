#pragma once
#include <vector>
#include <string>
class Tokeniser
{
public:
	Tokeniser(char separator);
	~Tokeniser();
	std::vector<std::string> Tokenise(std::string Line);

private:
	char separatorCharacter;
};

