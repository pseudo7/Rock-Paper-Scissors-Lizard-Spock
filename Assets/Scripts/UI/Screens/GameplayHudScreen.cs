using RPSLS.UI.Base;

namespace RPSLS.UI.Screens
{
    public class GameplayHudScreen : ScreenBase
    {
        public override void OnBackKeyPressed() =>
            PreviousScreen(true);
    }
}