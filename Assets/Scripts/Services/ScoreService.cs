using RPSLS.GameData;
using RPSLS.Services.Base;

namespace RPSLS.Services
{
    public class ScoreService : ServiceBase
    {
        private int _currentScore;

        internal void ResetCurrentScore() =>
            _currentScore = 0;

        internal void IncrementCurrentScore(int scoreStep) =>
            _currentScore += scoreStep;

        internal void UpdateHighScore()
        {
            if (_currentScore > PlayerPrefsManager.HighScore)
                PlayerPrefsManager.HighScore = _currentScore;
        }

        protected override void RegisterService() =>
            Bootstrap.RegisterService(this);
    }
}