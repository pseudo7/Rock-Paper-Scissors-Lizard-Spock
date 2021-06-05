using RPSLS.Miscellaneous;
using UnityEngine;

namespace RPSLS.Entities
{
    public class LizardHand : PlayableHandBase
    {
        protected internal override GameEnums.PlayableHandType HandType => GameEnums.PlayableHandType.Lizard;

        protected internal override bool CheckWinAgainstOtherHand(PlayableHandBase otherHand, out string message)
        {
            switch (otherHand.HandType)
            {
                case GameEnums.PlayableHandType.Rock:
                    Debug.Log(message = "Rock Crushed You");
                    return false;
                case GameEnums.PlayableHandType.Scissors:
                    Debug.Log(message = "Scissor Decapitated You");
                    return false;
                case GameEnums.PlayableHandType.Paper:
                    Debug.Log(message = "You Ate Paper");
                    return true;
                case GameEnums.PlayableHandType.Lizard:
                    Debug.Log(message = "Boom Same");
                    return true;
                case GameEnums.PlayableHandType.Spock:
                    Debug.Log(message = "You Poisoned Spock");
                    return true;
                default:
                    message = null;
                    return true;
            }
        }
    }
}