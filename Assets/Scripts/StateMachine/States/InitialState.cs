using System.Collections;
using RPSLS.Services;
using RPSLS.StateMachine.States.Base;
using RPSLS.UI.Screens;

namespace RPSLS.StateMachine.States
{
    public class InitialState : StateBase
    {
        internal override IEnumerator Initialise()
        {
            yield return null;
            Bootstrap.GetService<UserInterfaceService>()
                .CurrentInterface
                .ActivateThisScreen<MainMenuScreen>();
            yield break;
        }
    }
}