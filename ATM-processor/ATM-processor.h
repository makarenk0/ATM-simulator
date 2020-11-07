#pragma once
#include "StateMachine.h"

using namespace System;

namespace ATMprocessor {
	public ref class Processor
	{
	private:
		::StateMachine* _machine;
	public:
		void turnOnMachine();
		void turnOffMachine();

	};
}
