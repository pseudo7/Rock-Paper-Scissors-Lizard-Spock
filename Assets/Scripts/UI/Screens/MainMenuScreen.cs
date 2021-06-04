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

        protected override void InitializeScreen()
        {
            base.InitializeScreen();
            StartCoroutine(BackgroundInterpolationRoutine());
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