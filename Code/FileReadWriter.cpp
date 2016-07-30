#include "FileReadWriter.h"

using namespace std;

FileReadWriter::FileReadWriter(string FileName, int Mode)
{
	this->OpenFile(FileName, Mode);
}


FileReadWriter::~FileReadWriter()
{
	FileObject.close();
}

void FileReadWriter::OpenFile(string FileName, int Mode)
{
	FileObject.open(FileName, Mode);
}

vector<string> FileReadWriter::GetLine()
{
	string CurrentLine;
	vector<string> ToBeReturned;
	getline(FileObject, CurrentLine);

	unsigned int i = 0;
	string CurrentToken = "";
	while (i < CurrentLine.length()) 
	{
		if (CurrentLine[i] != ' ' && CurrentLine[i] != ',' && CurrentLine[i] != '\n' && CurrentLine[i] != NULL)
		{
			CurrentToken += CurrentLine[i];
		}
		else
		{
			ToBeReturned.push_back(CurrentToken);
		}
		++i;
	}

	return ToBeReturned;
}

void FileReadWriter::WriteLine(std::string Input)
{
	FileObject.write(Input.c_str(), Input.size());
}
