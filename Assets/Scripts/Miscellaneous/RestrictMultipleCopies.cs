using UnityEngine;

namespace RPSLS.Miscellaneous
{
    public class RestrictMultipleCopies : MonoBehaviour
    {
        private static RestrictMultipleCopies _firstCopy;

        private void Awake()
        {
            if (!_firstCopy)
            {
                _firstCopy = this;
                DontDestroyOnLoad(gameObject);
            }
            else Destroy(gameObject);
        }
    }
}