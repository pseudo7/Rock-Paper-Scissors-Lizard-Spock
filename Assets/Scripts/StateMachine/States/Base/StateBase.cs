using System.Collections;

namespace RPSLS.StateMachine.States.Base
{
    public abstract class StateBase
    {
        internal virtual IEnumerator Initialise()
        {
            yield break;
        }

        internal virtual IEnumerator Perform()
        {
            yield break;
        }

        internal virtual IEnumerator Finalise()
        {
            yield break;
        }
    }
}