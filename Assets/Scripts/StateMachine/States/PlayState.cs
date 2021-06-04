using System.Collections;
using RPSLS.Services;
using RPSLS.StateMachine.States.Base;
using RPSLS.UI.Screens;

namespace RPSLS.StateMachine.States
{
    public class PlayState : StateBase
    {
        internal override IEnumerator Initialise()
        {
            Bootstrap.GetService<UserInterfaceService>()
                .CurrentInterface.ActivateThisScreen<GameplayHudScreen>();
            yield break;
        }
    }
}