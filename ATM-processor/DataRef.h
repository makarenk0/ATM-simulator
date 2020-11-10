#pragma once
#include "StateMachine.h"

struct MainData {
	StateMachine* machine;
	CardsInfoWorker _cardsInfoWorker;
};

typedef std::shared_ptr<MainData> DataRef;