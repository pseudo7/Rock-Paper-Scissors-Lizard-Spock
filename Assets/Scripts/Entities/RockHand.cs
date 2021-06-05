using RPSLS.Miscellaneous;
using UnityEngine;

namespace RPSLS.Entities
{
    public class RockHand : PlayableHandBase
    {
        protected internal override GameEnums.PlayableHandType HandType => GameEnums.PlayableHandType.Rock;

        protected internal override bool? CheckWinAgainstOtherHand(PlayableHandBase otherHand, out string message)
        {
            switch (otherHand.HandType)
            {
                case GameEnums.PlayableHandType.Rock:
                    Debug.Log(message = "Boom Same");
                    return null;
                case GameEnums.PlayableHandType.Scissors:
                    Debug.Log(message = "You Crushed Scissors");
                    return true;
                case GameEnums.PlayableHandType.Paper:
                    Debug.Log(message = "Paper Covered You");
                    return false;
                case GameEnums.PlayableHandType.Lizard:
                    Debug.Log(message = "You Crushed Lizard");
                    return true;
                case GameEnums.PlayableHandType.Spock:
                    Debug.Log(message = "Spock Vapourised You");
                    return false;
                default:
                    message = null;
                    return true;
            }
        }
    }
}