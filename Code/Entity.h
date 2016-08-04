#pragma once
#include <string>

class Entity
{
public:
	Entity();
	~Entity();

	virtual void GetLink();

private:
	std::string EntityLink;

};

