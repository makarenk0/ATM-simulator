#include "pch.h"
#include "PinInputState.h"

PinInputState::PinInputState(DataRef data, const std::string& cardNumber, int pinCode, int balance) : _data(data), _cardNumber(cardNumber), _pinCode(pinCode), _balance(balance)
{
}

void PinInputState::Init()
{
}

std::string PinInputState::HandleInput(std::string key)
{
	if (key == "BLOCK_CARD") {
		_data->_cardsInfoWorker.blockCard(_cardNumber);
		return "blocked";
	}


	if (_pinCode == std::stoi(key)) {
		_data->machine->AddState(StateRef(new CardAccessState(_data, _cardNumber, _pinCode, _balance)), true);
		return "true";
	}
	else {
		return "false";
	}
}

void PinInputState::Update()
{
}

void PinInputState::Pause()
{
}

void PinInputState::Resume()
{
}
