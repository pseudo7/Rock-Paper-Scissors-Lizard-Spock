using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace RPSLS.UI.Items
{
    [RequireComponent(typeof(Image))]
    public class GradientInterpolator : MonoBehaviour
    {
        [SerializeField] private Gradient backgroundColors;

        private const float LerpFactor = .1F;

        private Image _backgroundImg;
        private Coroutine _interpolationCoroutine;

        private void Awake() =>
            _backgroundImg = GetComponent<Image>();

        private void OnEnable() =>
            _interpolationCoroutine = StartCoroutine(BackgroundInterpolationRoutine());

        private void OnDisable()
        {
            if (_interpolationCoroutine != null) StopCoroutine(_interpolationCoroutine);
        }

        private IEnumerator BackgroundInterpolationRoutine()
        {
            var eof = new WaitForEndOfFrame();

            while (gameObject.activeInHierarchy)
            {
                _backgroundImg.color = backgroundColors.Evaluate(Mathf.Abs(Mathf.Sin(Time.time * LerpFactor)));
                yield return eof;
            }
        }
    }
}