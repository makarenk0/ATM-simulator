#include "pch.h"
#include "CardAccessState.h"

CardAccessState::CardAccessState(DataRef data, const std::string& cardNumber, int pinCode, int balance) : _data(data), _cardNumber(cardNumber), _pinCode(pinCode), _balance(balance)
{
}

void CardAccessState::Init()
{
}

std::string CardAccessState::HandleInput(std::string key)
{
	if (key == "BALANCE") {
		std::string balance = std::to_string(_data->_cardsInfoWorker.getCardBalance(_cardNumber));
		return balance;
	}
	else if (key.substr(0, 11) == "WITHDRAWSUM") {
		int toWithdraw = std::stoi(key.substr(12));
		if (_data->_cardsInfoWorker.getCardBalance(_cardNumber) >= toWithdraw) {
			_data->_cardsInfoWorker.withdrawSum(_cardNumber, toWithdraw);
			return "true";
		}
		return "false";
	}
	else if (key.substr(0, 12) == "WITHDRAWCASH") {
		int toWithdraw = std::stoi(key.substr(13));
		if (_data->_cardsInfoWorker.getCardBalance(_cardNumber) >= toWithdraw) {
			if (_data->_cardsInfoWorker.withdrawCash(_cardNumber, toWithdraw)) {
				return "true";
			}
			return "false";
		}
		return "card_not_enough";
	}
	else if (key.substr(0, 11) == "TRANSFERSUM") {
		int toTransferSum = std::stoi(key.substr(12, key.find(";") - 12));
		std::string card = std::move(key.substr(key.find(";") + 6));
		if (_data->_cardsInfoWorker.getCardBalance(_cardNumber) >= toTransferSum) {
			if (_data->_cardsInfoWorker.cardExists(card)) {
				_data->_cardsInfoWorker.withdrawSum(_cardNumber ,toTransferSum);
				_data->_cardsInfoWorker.rechargeCardBalance(card, toTransferSum);
				return "true";
			}
			return "cart_not_exist";
		}
		return "card_not_enough";
	}
}

void CardAccessState::Update()
{
}

void CardAccessState::Pause()
{
}

void CardAccessState::Resume()
{
}
