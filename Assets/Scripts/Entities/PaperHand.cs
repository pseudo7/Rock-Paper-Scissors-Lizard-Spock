using RPSLS.Miscellaneous;
using UnityEngine;

namespace RPSLS.Entities
{
    public class PaperHand : PlayableHandBase
    {
        protected internal override GameEnums.PlayableHandType HandType => GameEnums.PlayableHandType.Paper;

        protected internal override bool CheckWinAgainstOtherHand(PlayableHandBase otherHand, out string message)
        {
            switch (otherHand.HandType)
            {
                case GameEnums.PlayableHandType.Rock:
                    Debug.Log(message = "You Covered Rock");
                    return true;
                case GameEnums.PlayableHandType.Scissors:
                    Debug.Log(message = "Scissor Cut You");
                    return false;
                case GameEnums.PlayableHandType.Paper:
                    Debug.Log(message = "Boom Same");
                    return true;
                case GameEnums.PlayableHandType.Lizard:
                    Debug.Log(message = "Lizard Ate You");
                    return false;
                case GameEnums.PlayableHandType.Spock:
                    Debug.Log(message = "You Disapproved Spock");
                    return true;
                default:
                    message = null;
                    return true;
            }
        }
    }
}