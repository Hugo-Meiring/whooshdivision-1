#pragma once

#ifndef FILEREADWRITER_H
#define FILEREADWRITER_H

#include <string>
#include <string.h>
#include <stdio.h>
#include <fstream>
#include <vector>



class FileReadWriter
{
	public:
		FileReadWriter(std::string FileName, int Mode);
		~FileReadWriter();

		void OpenFile(std::string FileName, int Mode);

		//std::vector<std::string> GetLine();

		void WriteLine(std::string Input);

		std::vector<std::string> GetLines(std::string FileName);

	private:
		std::fstream FileObject;
};

#endif