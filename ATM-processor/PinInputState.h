#pragma once
#include "State.h"
#include "DataRef.h"
#include "CardAccessState.h"


class PinInputState : public State
{
public:
	PinInputState(DataRef data, const std::string&, int pinCode, int balance);

	void Init();
	std::string HandleInput(std::string key);
	void Update();

	void Pause();
	void Resume();
private:
	DataRef _data;

	std::string _cardNumber;
	int _pinCode;
	int _balance;
};

