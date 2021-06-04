using RPSLS.Miscellaneous;
using UnityEngine;
using UnityEngine.UI;

namespace RPSLS.UI.Items
{
    public class PlayableItemUI : MonoBehaviour
    {
        [SerializeField] private Image iconImg;

        private GameEnums.PlayableOptionType _optionType;

        internal void SetValues(Sprite iconSprite, GameEnums.PlayableOptionType optionType) =>
            (iconImg.sprite, _optionType) = (iconSprite, optionType);

        public void OnOptionClicked()
        {
            Debug.Log(_optionType);
        }
    }
}