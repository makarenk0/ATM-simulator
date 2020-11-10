#include "pch.h"

#include "ATM-processor.h"

void ATMprocessor::Processor::turnOnMachine()
{
	_machine = new ::StateMachine();
}

void ATMprocessor::Processor::turnOffMachine()
{
	delete _machine;
}

String^ ATMprocessor::Processor::handleInput(String^ input)
{
	std::string unmanagedInput = msclr::interop::marshal_as<std::string>(input);
	String^ respond = msclr::interop::marshal_as<String^>(_machine->GetCurrentState().get()->HandleInput(unmanagedInput));
	_machine->ProcessStateChanges();
	return respond;
}

void ATMprocessor::Processor::updateMachine()
{
	_machine->Updater();
}

void ATMprocessor::Processor::popState()
{
	_machine->RemoveState();
}
