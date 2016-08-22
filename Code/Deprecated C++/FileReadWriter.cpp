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

//vector<string> FileReadWriter::GetLine()
//{
//	string CurrentLine;
//	vector<string> ToBeReturned;
//	//getline(FileObject, CurrentLine);
//
//	unsigned int i = 0;
//	string CurrentToken = "";
//	for(unsigned int i = 0; i < CurrentLine.length(); ++i)
//	{
//		if (CurrentLine[i] != ' ' && CurrentLine[i] != ',' && CurrentLine[i] != '\n' && CurrentLine[i] != NULL)
//		{
//			CurrentToken += CurrentLine[i];
//		}
//		else
//		{
//			if(CurrentToken != "") ToBeReturned.push_back(CurrentToken);
//			CurrentToken = "";
//		}
//	}
//
//	return ToBeReturned;
//}

void FileReadWriter::WriteLine(std::string Input)
{
	FileObject.write(Input.c_str(), Input.size());
}

std::vector<string> FileReadWriter::GetLines(string FileName)
{
	vector<string> ToBeReturned;
	string CurrentLine;
	char CurrentChar;

	FileObject.open(FileName);

	while (!FileObject.eof()) 
	{
		//getline(FileObject, CurrentLine);
		FileObject.get(CurrentChar);
		if((CurrentChar == '\n' || CurrentChar == EOF) && (CurrentChar == ' ' || CurrentChar == '\n'))	ToBeReturned.push_back(CurrentLine); //empty line
		else if (CurrentChar == ' ' || CurrentChar == '\n') {}
		else {
			CurrentLine += CurrentChar;
		}
	}

	return ToBeReturned;
}
