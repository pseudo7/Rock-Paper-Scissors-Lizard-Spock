using System.Collections;
using System.Collections.Generic;
using RPSLS.Miscellaneous;
using RPSLS.Services;
using RPSLS.UI.Base;
using RPSLS.UI.Items;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace RPSLS.UI.Screens
{
    // TODO: Finish up state logic 
    // TODO: Add Countdown for first initial play
    public class GameplayHudScreen : ScreenBase
    {
        [SerializeField] private Transform optionsParent;
        [SerializeField] private List<Sprite> iconSprites;

        private const string OptionsItemKey = "PlayableItem";
        private const int OptionsCount = 5;

        protected internal override void EnableScreen()
        {
            base.EnableScreen();
            PopulatePlayerOptions();
        }

        protected internal override void DisableScreen()
        {
            base.DisableScreen();
            DePopulatePlayerOptions();
        }

        private void PopulatePlayerOptions()
        {
            // I could have done it in synchronous fashion, but thought of doing it asynchronously
            var prm = new InstantiationParameters(Vector3.zero, Quaternion.identity, optionsParent);
            var count = OptionsCount;
            while (count-- > 0)
                if (!Bootstrap.GetService<AssetService>().LoadAndInstantiate(OptionsItemKey, prm))
                    Debug.LogError("Asset was not found");
            StartCoroutine(UpdateOptionValuesRoutine());
        }

        private IEnumerator UpdateOptionValuesRoutine()
        {
            yield return new WaitUntil(() => optionsParent.childCount == OptionsCount);
            var count = OptionsCount;
            PlayableItemUI playableItemUI;
            GameEnums.PlayableOptionType currentOptionType;
            while (count-- > 0)
            {
                currentOptionType = (GameEnums.PlayableOptionType) (count + 1);
                playableItemUI = optionsParent.GetChild(count).GetComponent<PlayableItemUI>();
                playableItemUI.SetValues(GetIconSprite(currentOptionType), currentOptionType);
            }
        }

        private void DePopulatePlayerOptions()
        {
            var count = optionsParent.childCount;
            while (count-- > 0)
                Destroy(optionsParent.GetChild(count).gameObject);
        }

        private Sprite GetIconSprite(GameEnums.PlayableOptionType optionType) =>
            optionType switch
            {
                GameEnums.PlayableOptionType.Rock => iconSprites[0],
                GameEnums.PlayableOptionType.Paper => iconSprites[1],
                GameEnums.PlayableOptionType.Scissor => iconSprites[2],
                GameEnums.PlayableOptionType.Lizard => iconSprites[3],
                GameEnums.PlayableOptionType.Spock => iconSprites[4],
                _ => null
            };

        public override void OnBackKeyPressed() =>
            PreviousScreen(true);
    }
}