using RPSLS.StateMachine.States.Base;
using UnityEngine;

namespace RPSLS.StateMachine.Base
{
    public abstract class StateMachineBase
    {
        protected StateBase CurrentState;
        private readonly MonoBehaviour _referencedBehaviour;

        protected StateMachineBase(MonoBehaviour referencedBehaviour) =>
            _referencedBehaviour = referencedBehaviour;

        internal void SetState(StateBase newState)
        {
            CurrentState = newState;
            _referencedBehaviour.StartCoroutine(CurrentState.Initialise());
        }
    }
}