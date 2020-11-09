#pragma once
#include "State.h"
#include "CardsInfoWorker.h"
#include "StateMachine.h"
#include "PinInputState.h"



struct MainData {
	StateMachine* machine;
	CardsInfoWorker _cardsInfoWorker;
};

typedef std::shared_ptr<MainData> DataRef;

class IdleState : public State
{
public:
	IdleState(StateMachine* machine);

	void Init();
	bool HandleInput(std::string key);
	void Update();

	void Pause();
	void Resume();
private:
	DataRef _data = std::make_shared<MainData>();
};

