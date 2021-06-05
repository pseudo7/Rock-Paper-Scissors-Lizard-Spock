using System.Collections;
using RPSLS.Services;
using RPSLS.StateMachine.States.Base;
using RPSLS.UI.Screens;
using UnityEngine;

namespace RPSLS.StateMachine.States
{
    public class PlayState : StateBase
    {
        internal override IEnumerator Initialise()
        {
            Bootstrap.GetService<UserInterfaceService>()
                .CurrentInterface.ActivateThisScreen<GameplayHudScreen>();
            yield return Bootstrap.GetService<StateMachineService>().StartCoroutine(Perform());
        }

        internal override IEnumerator Perform()
        {
            // TODO: Move in with the UI
            yield return new WaitForSeconds(.5F);
            yield return Bootstrap.GetService<UserInterfaceService>()
                .CurrentInterface
                .GetScreen<GameplayHudScreen>()
                .ShowCountdown();
            Bootstrap.GetService<StateMachineService>().CurrentFsm.SetState(new MakeYourMoveState());
        }
    }
}