using RPSLS.Miscellaneous;
using UnityEngine;

namespace RPSLS.Entities
{
    public class SpockHand : PlayableHandBase
    {
        protected internal override GameEnums.PlayableHandType HandType => GameEnums.PlayableHandType.Spock;

        protected internal override bool CheckWinAgainstOtherHand(PlayableHandBase otherHand, out string message)
        {
            switch (otherHand.HandType)
            {
                case GameEnums.PlayableHandType.Rock:
                    Debug.Log(message = "You Vaporised Rock");
                    return true;
                case GameEnums.PlayableHandType.Scissors:
                    Debug.Log(message = "You Smashed Scissors");
                    return true;
                case GameEnums.PlayableHandType.Paper:
                    Debug.Log(message = "Paper Disapproved You");
                    return false;
                case GameEnums.PlayableHandType.Lizard:
                    Debug.Log(message = "Lizard Poisoned You");
                    return false;
                case GameEnums.PlayableHandType.Spock:
                    Debug.Log(message = "Boom Same");
                    return true;
                default:
                    message = null;
                    return true;
            }
        }
    }
}