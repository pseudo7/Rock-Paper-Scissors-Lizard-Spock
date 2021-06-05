using RPSLS.Audio;
using RPSLS.Miscellaneous;
using RPSLS.Services;
using RPSLS.UI.Screens;
using UnityEngine;
using UnityEngine.UI;

namespace RPSLS.UI.Items
{
    public class PlayableItemUI : MonoBehaviour
    {
        [SerializeField] private Image iconImg;

        internal GameEnums.PlayableHandType HandType { get; private set; }

        internal void SetValues(Sprite iconSprite, GameEnums.PlayableHandType handType) =>
            (iconImg.sprite, HandType) = (iconSprite, handType);

        public void OnOptionClicked()
        {
            var hudScreen = Bootstrap.GetService<UserInterfaceService>()
                .CurrentInterface
                .GetScreen<GameplayHudScreen>();
            hudScreen.SetPlayerOptionType(HandType);
            Bootstrap.GetService<GameManagementService>().CurrentPlayerSelection = HandType;
            transform.SetAsLastSibling();
            Bootstrap.GetService<AudioService>().PlayAudio(AudioTags.HAND_TAP);
            Debug.Log(HandType);
        }

        internal void ToggleScale(bool selected) =>
            transform.localScale = selected ? GameConstants.SelectedScale : GameConstants.NormalScale;
    }
}