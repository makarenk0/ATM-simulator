#include "pch.h"
#include "IdleState.h"


IdleState::IdleState(StateMachine* machine)
{
	_data->machine = machine;
	_data->_cardsInfoWorker = CardsInfoWorker("data/cards.txt", "data/blocked_cards.txt", "data/atm_cash.txt");
}

void IdleState::Init()
{
}

std::string IdleState::HandleInput(std::string key)
{
	if (key == "SERVICE_MODE") {
		_data->machine->AddState(StateRef(new ServiceState(_data)), false);
		return "service";
	}
	else if (_data->_cardsInfoWorker.isCardBlocked(key)) {
		return "blocked";
	}
	else if (_data->_cardsInfoWorker.cardExists(key)) {
		std::pair<std::string, int> res = _data->_cardsInfoWorker._cardData[key];
		_data->machine->AddState(StateRef(new PinInputState(_data, key, std::stoi(res.first), res.second)), false);
		return "true";
	}
	else {
		return "false";
	}
}

void IdleState::Update()
{
}

void IdleState::Pause()
{
}

void IdleState::Resume()
{
}
