#pragma once
#include <fstream>
#include <string>

class Reader
{
public:
	Reader();
	~Reader();

	void ReadFile(string InputFile);
};

