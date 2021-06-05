using RPSLS.Miscellaneous;
using UnityEngine;

namespace RPSLS.GameData
{
    public static class PlayerPrefsManager
    {
        private const string HighScoreKey = nameof(HighScoreKey);

        internal static int HighScore
        {
            get
            {
                if (!PlayerPrefs.HasKey(HighScoreKey))
                    HighScore = 0;
                return PlayerPrefs.GetInt(HighScoreKey);
            }
            set
            {
                PlayerPrefs.SetInt(HighScoreKey, value);
                Debug.Log($"New HighScore Set: {value}".ToColoredString(Color.white));
                PlayerPrefs.Save();
            }
        }
    }
}