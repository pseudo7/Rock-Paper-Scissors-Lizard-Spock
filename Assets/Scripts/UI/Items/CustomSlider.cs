using UnityEngine;

namespace RPSLS.UI.Items
{
    public class CustomSlider : MonoBehaviour
    {
        [SerializeField] private RectTransform fillRect;
        [SerializeField] private RectTransform maskRect;

        [Range(0F, 1F)] [SerializeField] private float sliderValue;


        private float _fillDistance;
        private float _value;
        private Vector2 _fillPosition;
        private Vector2 _maskPosition;

        private void Awake() =>
            _fillDistance = fillRect.rect.width;

        private void OnValidate() =>
            Value = sliderValue;

        internal float Value
        {
            get => _value;

            set
            {
                _value = Mathf.Clamp01(value);
                _fillPosition.x = _value * -_fillDistance + _fillDistance;
                _maskPosition.x = -_fillDistance + _value * _fillDistance;
                fillRect.anchoredPosition = _fillPosition;
                maskRect.anchoredPosition = _maskPosition;
            }
        }
    }
}