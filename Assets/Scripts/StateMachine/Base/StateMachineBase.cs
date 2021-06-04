using RPSLS.StateMachine.States.Base;
using UnityEngine;

namespace RPSLS.StateMachine.Base
{
    public abstract class StateMachineBase : MonoBehaviour
    {
        protected StateBase CurrentState;

        internal void SetState(StateBase newState)
        {
            CurrentState = newState;
            StartCoroutine(CurrentState.Initialise());
        }
    }
}