#pragma once
#include "State.h"
#include "CardsInfoWorker.h"
#include "StateMachine.h"
#include "PinInputState.h"
#include "ServiceState.h"
#include "DataRef.h"

class IdleState : public State
{
public:
	IdleState(StateMachine* machine);

	void Init();
	std::string HandleInput(std::string key);
	void Update();

	void Pause();
	void Resume();
private:
	DataRef _data = std::make_shared<MainData>();
};

