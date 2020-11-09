#include "pch.h"

#include "ATM-processor.h"

void ATMprocessor::Processor::turnOnMachine()
{
	//_machine = new ::StateMachine();
}

void ATMprocessor::Processor::turnOffMachine()
{
	delete _machine;
}

bool ATMprocessor::Processor::handleInput(String^ input)
{
	std::string unmanagedInput = msclr::interop::marshal_as<std::string>(input);
	return _machine->GetCurrentState().get()->HandleInput(unmanagedInput);
}
