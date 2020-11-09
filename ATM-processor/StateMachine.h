#pragma once

#include <memory>
#include <stack>
#include <thread>

#include "State.h"
#include "CardsInfoWorker.h"

typedef std::unique_ptr<State> StateRef;

class StateMachine
{
public:
	StateMachine();
	~StateMachine();
	void AddState(StateRef newState, bool isReplacing);
	void RemoveState();

	void ProcessStateChanges();
	StateRef& GetCurrentState();
	
private:
	std::stack<StateRef> _states;
	StateRef _newState;

	bool _isRemoving;
	bool _isAdding;
	bool _isReplacing;


	void Updater();

	bool _isRunning;
	std::thread _updateThread;
};

