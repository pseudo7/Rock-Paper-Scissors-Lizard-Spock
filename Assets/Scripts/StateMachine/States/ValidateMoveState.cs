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
            var fsmService = Bootstrap.GetService<StateMachineService>();
            var result = CheckForWin(Bootstrap.GetService<GameManagementService>().CurrentPlayerSelection);

            yield return fsmService.StartCoroutine(Perform());

            if (result)
            {
                fsmService.CurrentFsm.SetState(new PlayState());
                Bootstrap.GetService<ScoreService>().IncrementCurrentScore(1);
                // TODO: Confirm this once if same hand is considered as a win
            }
            else
            {
                fsmService.CurrentFsm.SetState(new InitialState());
                Bootstrap.GetService<ScoreService>().UpdateHighScore();
                Bootstrap.GetService<ScoreService>().ResetCurrentScore();
            }

            Bootstrap.GetService<GameManagementService>().CurrentPlayerSelection = GameEnums.PlayableHandType.None;
        }

        internal override IEnumerator Perform()
        {
            yield return new WaitForSeconds(2F);
            yield break;
        }

        private bool CheckForWin(GameEnums.PlayableHandType playerSelectedType)
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