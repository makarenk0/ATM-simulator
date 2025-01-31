#include "pch.h"
#include "ServiceState.h"

ServiceState::ServiceState(DataRef data) : _data(data)
{
}

void ServiceState::Init()
{
}

std::string ServiceState::HandleInput(std::string key)
{
	if (key == "TAKE_BLOCKED_CARDS") {
		_data->_cardsInfoWorker.unblockAll();
		return "true";
	}
	else if (key == "BLOCKED_AMOUNT") {
		return std::to_string(_data->_cardsInfoWorker._blockedCards.size());
	}
	else if (key == "ATM_CASH") {
		return std::to_string(_data->_cardsInfoWorker._atmCash);
	}
	else {
		int amount = std::stoi(key);
		_data->_cardsInfoWorker.rechargeATMCash(amount);
		return "true";
	}
}

void ServiceState::Update()
{
}

void ServiceState::Pause()
{
}

void ServiceState::Resume()
{
}