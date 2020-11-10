#include "pch.h"
#include "CardAccessState.h"

CardAccessState::CardAccessState(const std::string& cardNumber, int pinCode, int balance) : _cardNumber(cardNumber), _pinCode(pinCode), _balance(balance)
{
}

void CardAccessState::Init()
{
}

std::string CardAccessState::HandleInput(std::string key)
{
	return "false";
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
