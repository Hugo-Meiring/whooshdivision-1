#include "FileReadWriter.h"

using namespace std;

int main()
{
	string Source = "SceneDescriptor.csv";
	string Destination = "Optimised.csv";
	FileReadWriter SceneDescReader(Source, 0);
	FileReadWriter Writer(Destination, 0x42);

	//scene describer would need to open other files too. Keep the item names in a structure to open and parse the files later.
	vector<string> InputFileNames;
	vector<string> CurrentLine;// = SceneDescReader.GetLine();
	string InputFile;
	string EntityLink;

	while (CurrentLine.size() > 0)
	{
		//tokenise the current line
		if (CurrentLine.size() > 1)	//looking for the file name at position 2
		{
			char Shortened;
			if (CurrentLine[0] == "Object") Shortened = 'o';
			else if (CurrentLine[0] == "Animation") Shortened = 'a';
			else if (CurrentLine[0] == "Position") Shortened = 'p';
			else if (CurrentLine[0] == "Model") Shortened = 'm';
			else if (CurrentLine[0] == "Texture") Shortened = 'a';
			else if (CurrentLine[0] == "Colour") Shortened = 'c';
			else if (CurrentLine[0] == "BumpMap") Shortened = 'b';
			else if (CurrentLine[0] == "Variable") Shortened = 'v';

			//the below block is going to change, as the user will provide the input file
			//bare with me. 
			//assumption: the input file will be in the third column (?)
			if (Shortened == 'o' || Shortened == 'a')
			{
				InputFile = CurrentLine[3];											//Objects and animations have nonleaf children
				EntityLink = CurrentLine[2];
			}
			else
			{
				InputFile = CurrentLine[2];											//the rest don't. This could be easily changed
				EntityLink = CurrentLine[1];
			}
			InputFileNames.push_back(InputFile);									//to only specify the immediate parent, not root

			//if object or anim, replace the shortened with the actual type
			if (Shortened == 'o')
			{
				if (CurrentLine[1] == "Collection") Shortened = 'e';
				else if (CurrentLine[1] == "Light") Shortened = 'l';
				else if (CurrentLine[1] == "Shape") Shortened = 's';
				else if (CurrentLine[1] == "Viewer") Shortened = 'i';
			}
			else if (Shortened == 'a')
			{
				if (CurrentLine[1] == "SequentialAnimation") Shortened = 'q';
				else if (CurrentLine[1] == "ParallelAnimation") Shortened = 'w';
				else if (CurrentLine[1] == "RepeatingAnimation") Shortened = 'r';
			}

			//write to file immediately after reading the input file. Do the cartesian product now
			FileReadWriter *InputFileReader = new FileReadWriter(InputFile + ".csv", 0);
			vector<string> CurrentInputLine;// = InputFileReader->GetLine();
			while (/*still reading from the input file*/ CurrentInputLine.size() > 0)
			{
				//write to optimised
				string OptimisedInputLine = (char*)Shortened;
				OptimisedInputLine += ",";
				OptimisedInputLine += EntityLink + ",";
				for (unsigned int i = 0; i < CurrentInputLine.size(); i++)
				{
					OptimisedInputLine += CurrentInputLine[i];
					if (i != CurrentInputLine.size() - 1) OptimisedInputLine += ",";
				}
				OptimisedInputLine += "\n";
				Writer.WriteLine(OptimisedInputLine);
				CurrentInputLine;// = InputFileReader->GetLine();
			}
		}

		vector<string> CurrentLine;// = SceneDescReader.GetLine();
	}

	//TODO: handle data structure

	return 0;
}