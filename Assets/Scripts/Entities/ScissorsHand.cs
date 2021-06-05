using RPSLS.Miscellaneous;
using UnityEngine;

namespace RPSLS.Entities
{
    public class ScissorsHand : PlayableHandBase
    {
        protected internal override GameEnums.PlayableHandType HandType => GameEnums.PlayableHandType.Scissors;

        protected internal override bool CheckWinAgainstOtherHand(PlayableHandBase otherHand, out string message)
        {
            switch (otherHand.HandType)
            {
                case GameEnums.PlayableHandType.Rock:
                    Debug.Log(message = "Rock Crushed You");
                    return false;
                case GameEnums.PlayableHandType.Scissors:
                    Debug.Log(message = "Boom Same");
                    return true;
                case GameEnums.PlayableHandType.Paper:
                    Debug.Log(message = "You Cut Paper");
                    return true;
                case GameEnums.PlayableHandType.Lizard:
                    Debug.Log(message = "You Decapitated Lizard");
                    return true;
                case GameEnums.PlayableHandType.Spock:
                    Debug.Log(message = "Spock Smashed You");
                    return false;
                default:
                    message = null;
                    return true;
            }
        }
    }
}