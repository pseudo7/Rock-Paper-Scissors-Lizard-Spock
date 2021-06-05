using System.Collections;
using RPSLS.GameData;
using RPSLS.Services;
using RPSLS.StateMachine.States;
using RPSLS.UI.Base;
using TMPro;
using UnityEngine;

namespace RPSLS.UI.Screens
{
    public class MainMenuScreen : ScreenBase
    {
        [SerializeField] private TextMeshProUGUI titleTextTmp;
        [SerializeField] private TextMeshProUGUI highScoreTextTmp;

        private Coroutine _titleCoroutine;

        private static readonly string[] TitleStrings =
        {
            "<size=\"250\">R</size>.P.S.L.S",
            "R.<size=\"250\">P</size>.S.L.S",
            "R.P.<size=\"250\">S</size>.L.S",
            "R.P.S.<size=\"250\">L</size>.S",
            "R.P.S.L.<size=\"250\">S</size>",
        };

        protected internal override void EnableScreen()
        {
            base.EnableScreen();
            _titleCoroutine = StartCoroutine(TitleAnimRoutine());
            UpdateHighScore();
        }

        protected internal override void DisableScreen()
        {
            base.DisableScreen();
            if (_titleCoroutine != null) StopCoroutine(_titleCoroutine);
        }

        public void PlayGame() =>
            Bootstrap.GetService<StateMachineService>().CurrentFsm.SetState(new PlayState());

        public void ExitGame() =>
            Bootstrap.GetService<StateMachineService>().CurrentFsm.SetState(new FinalState());

        public override void OnBackKeyPressed() =>
            PreviousScreen(false);

        private void UpdateHighScore() =>
            highScoreTextTmp.text = $"High Score    '{PlayerPrefsManager.HighScore}'";

        private IEnumerator TitleAnimRoutine()
        {
            var wait = new WaitForSeconds(.65F);
            var index = 0;
            var count = TitleStrings.Length;
            while (IsScreenEnabled)
            {
                while (index < count)
                {
                    titleTextTmp.text = TitleStrings[index++];
                    yield return wait;
                }

                while (index > 0)
                {
                    titleTextTmp.text = TitleStrings[--index];
                    yield return wait;
                }
            }
        }
    }
}