using RPSLS.GameData;
using RPSLS.Services.Base;
using RPSLS.UI.Screens;

namespace RPSLS.Services
{
    public class ScoreService : ServiceBase
    {
        private int _currentScore;
        private GameplayHudScreen _hudScreen;

        internal void ResetCurrentScore() =>
            _currentScore = 0;

        internal void IncrementCurrentScore(int scoreStep)
        {
            if (!_hudScreen)
                _hudScreen = Bootstrap.GetService<UserInterfaceService>()
                    .CurrentInterface.GetScreen<GameplayHudScreen>();
            _currentScore += scoreStep;
            _hudScreen.UpdateCurrentScore(_currentScore);
        }

        internal void UpdateHighScore()
        {
            if (_currentScore > PlayerPrefsManager.HighScore)
                PlayerPrefsManager.HighScore = _currentScore;
        }

        protected override void RegisterService() =>
            Bootstrap.RegisterService(this);
    }
}