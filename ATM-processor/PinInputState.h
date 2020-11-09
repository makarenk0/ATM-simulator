#pragma once
#include "State.h"


class PinInputState : public State
{
public:
	PinInputState(const std::string&);

	void Init();
	bool HandleInput(std::string key);
	void Update();

	void Pause();
	void Resume();
private:
	std::string _cardNumber;
	int _pinCode;
};

