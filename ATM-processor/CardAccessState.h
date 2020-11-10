#pragma once
#include "State.h"


class CardAccessState : public State
{
public:
	CardAccessState(const std::string&, int pinCode, int balance);

	void Init();
	std::string HandleInput(std::string key);
	void Update();

	void Pause();
	void Resume();
private:
	std::string _cardNumber;
	int _pinCode;
	int _balance;
};

