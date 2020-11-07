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
