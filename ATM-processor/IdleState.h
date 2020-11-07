#pragma once
#include "State.h"


class IdleState : public State
{
public:
	IdleState();

	void Init();
	void HandleInput(std::string key);
	void Update();

	void Pause();
	void Resume();
private:
};

