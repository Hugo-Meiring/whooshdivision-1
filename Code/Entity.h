#pragma once
#include <string>

class Entity
{
public:
	Entity();
	~Entity();

	virtual std::string GetName();

private:
	std::string Name;

};

