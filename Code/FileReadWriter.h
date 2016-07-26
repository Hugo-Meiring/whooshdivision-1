#pragma once

#ifndef FILEREADWRITER_H
#define FILEREADWRITER_H
#endif

#include <string>
#include <fstream>
#include <vector>



class FileReadWriter
{
	public:
		FileReadWriter(std::string FileName, int Mode);
		~FileReadWriter();

		void OpenFile(std::string FileName, int Mode);

		std::vector<std::string> GetLine();

		void WriteLine(std::string Input);

	private:
		std::fstream FileObject;
};

