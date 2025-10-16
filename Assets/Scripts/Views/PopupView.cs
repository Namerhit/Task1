using UnityEngine;
using DG.Tweening;

namespace Views
{
    public class PopupView : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private RectTransform _parentCanvasRectTransform;

        [Header("Eases")] 
        [SerializeField] private Ease _showEase;
        [SerializeField] private Ease _hideEase;
        
        [SerializeField] private float _startPositionY;
        [SerializeField] private float _transitionDuration;

        private void Awake()
        {
            _rectTransform.anchoredPosition = new Vector2(0, _startPositionY);
        }

        public void Show()
        {
            var targetPositionY = _parentCanvasRectTransform.rect.height / 2;
            
            _rectTransform.DOAnchorPos(new Vector2(0, targetPositionY), _transitionDuration).SetEase(_showEase);
        }

        public void Hide()
        {
            _rectTransform.DOAnchorPos(new Vector2(0, _startPositionY), _transitionDuration).SetEase(_hideEase);
        }
    }
}
