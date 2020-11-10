#pragma once
#include "StateMachine.h"
#include <msclr\marshal_cppstd.h>

using namespace System;

namespace ATMprocessor {
	public ref class Processor
	{
	private:
		::StateMachine* _machine;
	public:
		void turnOnMachine();
		void turnOffMachine();
		String^ handleInput(String^ path);
		void updateMachine();
		void popState();
	};
}
