#pragma once
#include <string>

class State {
public:
	virtual void Init() = 0;
	virtual void HandleInput(std::string key) = 0;
	virtual void Update() = 0;

	virtual void Pause() {};
	virtual void Resume() {};
};