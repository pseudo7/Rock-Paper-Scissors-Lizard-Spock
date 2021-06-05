using System.Collections;
using RPSLS.Entities;
using RPSLS.Miscellaneous;
using RPSLS.Services;
using RPSLS.StateMachine.States.Base;
using RPSLS.UI.Screens;
using UnityEngine;

namespace RPSLS.StateMachine.States
{
    public class ValidateMoveState : StateBase
    {
        internal override IEnumerator Initialise()
        {
            var interfaceService = Bootstrap.GetService<UserInterfaceService>();
            interfaceService.ToggleInteractions(false);

            var fsmService = Bootstrap.GetService<StateMachineService>();
            var result = CalculateResults(Bootstrap.GetService<GameManagementService>().CurrentPlayerSelection);

            interfaceService.CurrentInterface.GetScreen<GameplayHudScreen>().ShowVignette(result);

            if (result.HasValue && !result.Value)
                Handheld.Vibrate();

            yield return fsmService.StartCoroutine(Perform());

            if (!result.HasValue)
            {
                fsmService.CurrentFsm.SetState(new PlayState());
                Bootstrap.GetService<ScoreService>().IncrementCurrentScore(0);
            }
            else if (result.Value)
            {
                fsmService.CurrentFsm.SetState(new PlayState());
                Bootstrap.GetService<ScoreService>().IncrementCurrentScore(1);
            }
            else
            {
                fsmService.CurrentFsm.SetState(new InitialState());
                Bootstrap.GetService<ScoreService>().UpdateHighScore();
                Bootstrap.GetService<ScoreService>().ResetCurrentScore();
            }

            Bootstrap.GetService<GameManagementService>().ResetValues();
            interfaceService.ToggleInteractions(true);
        }

        internal override IEnumerator Perform()
        {
            yield return new WaitForSeconds(3F);
        }

        private bool? CalculateResults(GameEnums.PlayableHandType playerSelectedType)
        {
            var hudScreen = Bootstrap.GetService<UserInterfaceService>()
                .CurrentInterface
                .GetScreen<GameplayHudScreen>();
            if (playerSelectedType == GameEnums.PlayableHandType.None)
            {
                hudScreen.ShowOutcomeMessage("You didn't played your hand!");
                return false;
            }

            var cpuSelectedOption = (GameEnums.PlayableHandType) Random.Range(1, 6);
            var playerHand = PlayableHandBase.FromPlayableType(playerSelectedType);
            var cpuHand = PlayableHandBase.FromPlayableType(cpuSelectedOption);
            var result = playerHand.CheckWinAgainstOtherHand(cpuHand, out var message);

            hudScreen.UpdateCPUTurnSprite(cpuSelectedOption);
            hudScreen.ShowOutcomeMessage(message);
            return result;
        }
    }
}