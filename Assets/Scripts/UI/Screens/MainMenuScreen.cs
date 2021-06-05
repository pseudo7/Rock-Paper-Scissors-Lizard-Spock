using System.Collections;
using RPSLS.Services;
using RPSLS.StateMachine.States;
using RPSLS.UI.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPSLS.UI.Screens
{
    public class MainMenuScreen : ScreenBase
    {
        [SerializeField] private Image backgroundImg;
        [SerializeField] private Gradient backgroundColors;
        [SerializeField] private TextMeshProUGUI titleTextTmp;

        private const float LerpFactor = .1F;
        private Coroutine _interpolationCoroutine;
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
            _interpolationCoroutine = StartCoroutine(BackgroundInterpolationRoutine());
            _titleCoroutine = StartCoroutine(TitleAnimRoutine());
        }

        protected internal override void DisableScreen()
        {
            base.DisableScreen();
            if (_interpolationCoroutine != null) StopCoroutine(_interpolationCoroutine);
            if (_titleCoroutine != null) StopCoroutine(_titleCoroutine);
        }

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


        private IEnumerator BackgroundInterpolationRoutine()
        {
            var eof = new WaitForEndOfFrame();

            while (IsScreenEnabled)
            {
                backgroundImg.color = backgroundColors.Evaluate(Mathf.Abs(Mathf.Sin(Time.time * LerpFactor)));
                yield return eof;
            }
        }

        public void PlayGame() =>
            Bootstrap.GetService<StateMachineService>().CurrentFsm.SetState(new PlayState());

        public override void OnBackKeyPressed() =>
            PreviousScreen(false);
    }
}