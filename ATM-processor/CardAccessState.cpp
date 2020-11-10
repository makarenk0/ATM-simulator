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
	return "adfdf";
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
