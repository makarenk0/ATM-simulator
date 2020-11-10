#pragma once
#include "State.h"
#include "DataRef.h"


class CardAccessState : public State
{
public:
	CardAccessState(DataRef data, const std::string& card, int pinCode, int balance);

	void Init();
	std::string HandleInput(std::string key);
	void Update();

	void Pause();
	void Resume();
private:
	std::string _cardNumber;
	int _pinCode;
	int _balance;
	DataRef _data;
};

