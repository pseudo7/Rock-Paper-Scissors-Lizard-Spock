using RPSLS.Miscellaneous;

namespace RPSLS.Entities
{
    public abstract class PlayableHandBase
    {
        internal static PlayableHandBase FromPlayableType(GameEnums.PlayableHandType handType) =>
            handType switch
            {
                GameEnums.PlayableHandType.Rock => new RockHand(),
                GameEnums.PlayableHandType.Paper => new PaperHand(),
                GameEnums.PlayableHandType.Scissors => new ScissorsHand(),
                GameEnums.PlayableHandType.Lizard => new LizardHand(),
                GameEnums.PlayableHandType.Spock => new SpockHand(),
                _ => throw new System.ArgumentOutOfRangeException(nameof(handType), handType, null)
            };

        protected internal abstract GameEnums.PlayableHandType HandType { get; }
        protected internal abstract bool CheckWinAgainstOtherHand(PlayableHandBase otherHand, out string message);
    }
}