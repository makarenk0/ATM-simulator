#include "pch.h"
#include "IdleState.h"


IdleState::IdleState(StateMachine* machine)
{
	_data->machine = machine;
	_data->_cardsInfoWorker = CardsInfoWorker("cards.txt");
}

void IdleState::Init()
{
}

bool IdleState::HandleInput(std::string key)
{
	if (_data->_cardsInfoWorker._cardData.find(key) != _data->_cardsInfoWorker._cardData.end()) {
		_data->machine->AddState(StateRef(new PinInputState(key)), false);
		return true;
	}
	else {
		return false;
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
