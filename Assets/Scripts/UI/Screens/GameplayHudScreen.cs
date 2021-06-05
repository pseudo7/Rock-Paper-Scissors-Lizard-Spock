using System;
using System.Collections;
using System.Collections.Generic;
using RPSLS.Miscellaneous;
using RPSLS.Services;
using RPSLS.UI.Base;
using RPSLS.UI.Items;
using TMPro;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.UI;

namespace RPSLS.UI.Screens
{
    // TODO: Finish up state logic 
    public class GameplayHudScreen : ScreenBase
    {
        [SerializeField] private Transform optionsParent;
        [SerializeField] private List<Sprite> iconSprites;
        [SerializeField] private CustomSlider timeBar;
        [SerializeField] private HorizontalLayoutGroup optionsLayoutGroup;
        [SerializeField] private TextMeshProUGUI countdownTmp;
        [SerializeField] private Image cpuHandImg;

        private const string OptionsItemKey = "PlayableItem";
        private const int OptionsCount = 5;

        private List<PlayableItemUI> _playableOptions;

        protected override void InitializeScreen()
        {
            base.InitializeScreen();
            _playableOptions = new List<PlayableItemUI> {null, null, null, null, null};
            PopulatePlayerOptions();
        }

        protected internal override void EnableScreen()
        {
            base.EnableScreen();
            UpdateCPUTurnSprite(GameEnums.PlayableHandType.None);
            timeBar.Value = 1F;
        }

        protected internal override void DisableScreen()
        {
            base.DisableScreen();
            _playableOptions.ForEach(item =>
            {
                if (item) item.ToggleScale(false);
            });
        }

        public override void OnBackKeyPressed() =>
            PreviousScreen(true);

        private void OnApplicationQuit() =>
            DePopulatePlayerOptions();

        private void PopulatePlayerOptions()
        {
            // I could have done this in synchronous fashion, but thought of doing it asynchronously
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
            optionsLayoutGroup.enabled = true;
            yield return null;
            var count = OptionsCount;
            PlayableItemUI playableItemUI;
            GameEnums.PlayableHandType currentHandType;
            while (count-- > 0)
            {
                currentHandType = (GameEnums.PlayableHandType) (count + 1);
                playableItemUI = optionsParent.GetChild(count).GetComponent<PlayableItemUI>();
                playableItemUI.SetValues(GetIconSprite(currentHandType), currentHandType);
                _playableOptions[count] = playableItemUI;
            }

            optionsLayoutGroup.enabled = false;
        }

        private void DePopulatePlayerOptions()
        {
            var count = _playableOptions.Count;
            while (count-- > 0)
                Destroy(_playableOptions[count]?.gameObject);
        }

        internal Coroutine ShowCountdown() =>
            StartCoroutine(CountdownRoutine());

        internal void UpdateTimeBar(float val) =>
            timeBar.Value = val;

        internal void SetPlayerOptionType(GameEnums.PlayableHandType handType) =>
            _playableOptions.ForEach(item => item.ToggleScale(item.HandType == handType));

        internal void ShowOutcomeMessage(string message)
        {
            // TODO
            Debug.LogError(message);
        }

        internal void UpdateCPUTurnSprite(GameEnums.PlayableHandType handType) =>
            cpuHandImg.sprite = handType == GameEnums.PlayableHandType.None
                ? iconSprites[5]
                : GetIconSprite(handType);

        private IEnumerator CountdownRoutine()
        {
            var wait = new WaitForSeconds(.75F);
            var countdown = 3;
            while (countdown > 0)
            {
                countdownTmp.text = $"{countdown--}";
                yield return wait;
            }

            countdownTmp.text = string.Empty;
        }


        private Sprite GetIconSprite(GameEnums.PlayableHandType handType) =>
            handType switch
            {
                GameEnums.PlayableHandType.Rock => iconSprites[0],
                GameEnums.PlayableHandType.Paper => iconSprites[1],
                GameEnums.PlayableHandType.Scissors => iconSprites[2],
                GameEnums.PlayableHandType.Lizard => iconSprites[3],
                GameEnums.PlayableHandType.Spock => iconSprites[4],
                _ => null
            };
    }
}