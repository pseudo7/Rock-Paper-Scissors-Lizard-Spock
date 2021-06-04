using System.Collections;
using RPSLS.Services;
using RPSLS.StateMachine.States;
using RPSLS.UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace RPSLS.UI.Screens
{
    public class MainMenuScreen : ScreenBase
    {
        [SerializeField] private Image backgroundImg;
        [SerializeField] private Gradient backgroundColors;

        private const float LerpFactor = .1F;
        private Coroutine _interpolationCoroutine;

        protected internal override void EnableScreen()
        {
            base.EnableScreen();
            _interpolationCoroutine = StartCoroutine(BackgroundInterpolationRoutine());
        }

        protected internal override void DisableScreen()
        {
            base.DisableScreen();
            if (_interpolationCoroutine != null) StopCoroutine(_interpolationCoroutine);
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