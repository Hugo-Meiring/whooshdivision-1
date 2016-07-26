#include "FileReadWriter.h"
#include <fstream>

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
	char* CurrentToken = strtok((char*)CurrentLine.c_str(), " ,");
	vector<string>::iterator it = ToBeReturned.begin();
	while (CurrentToken != NULL)
	{
		ToBeReturned.insert(it, CurrentToken);
		CurrentToken = strtok(NULL, " ,");
	}
	return ToBeReturned;
}

void FileReadWriter::WriteLine(std::string Input)
{
	FileObject.write(Input.c_str(), Input.size());
}
