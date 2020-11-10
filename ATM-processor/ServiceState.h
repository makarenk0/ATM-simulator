#pragma once
#include "State.h"
#include "DataRef.h"

class ServiceState : public State
{
public:
	ServiceState(DataRef data);

	void Init();
	std::string HandleInput(std::string key);
	void Update();

	void Pause();
	void Resume();

	
private:
	DataRef _data;
};

