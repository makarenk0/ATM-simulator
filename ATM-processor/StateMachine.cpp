#include "pch.h"
#include "StateMachine.h"
#include "IdleState.h"  // for adding default idle state

StateMachine::StateMachine()
{
	_isRunning = true;
	this->AddState(StateRef(new IdleState(this)), true);
	_updateThread = std::thread(&StateMachine::Updater, this);
}

StateMachine::~StateMachine()
{
	_isRunning = false;
	_updateThread.join();

}

void StateMachine::AddState(StateRef newState, bool isReplacing) {
	this->_isAdding = true;
	this->_isReplacing = isReplacing;
	this->_newState = std::move(newState);
}
void StateMachine::RemoveState() {
	this->_isRemoving = true;
}
void StateMachine::ProcessStateChanges() {
	if (this->_isRemoving && !this->_states.empty()) {
		this->_states.pop();
		if (!this->_states.empty()) {
			this->_states.top()->Resume();
		}

		this->_isRemoving = false;
	}
	if (this->_isAdding) {
		if (!this->_states.empty()) {
			if (this->_isReplacing) {
				this->_states.pop();
			}
			else {
				this->_states.top()->Pause();
			}
		}
		this->_states.push(std::move(this->_newState));
		this->_states.top()->Init();
		this->_isAdding = false;
	}
}

StateRef& StateMachine::GetCurrentState() {
	return this->_states.top();
}

void StateMachine::Updater()
{
	while (_isRunning) {
		GetCurrentState().get()->Update();
		ProcessStateChanges();
		std::this_thread::sleep_for(std::chrono::seconds(1));
	}
}
