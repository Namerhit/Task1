using System;
using UnityEngine;
using DG.Tweening;

namespace Views
{
    public class UpgradeButtonView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        
        [SerializeField] private float _animationDuration;

        [Header("Eases")] 
        [SerializeField] private Ease _showEase;
        [SerializeField] private Ease _hideEase;

        private void Awake()
        {
            transform.localScale = Vector3.zero;
            _canvasGroup.alpha = 0.0f;
            _canvasGroup.interactable = false;
        }

        public void ShowButton()
        {
            transform.DOKill();

            _canvasGroup.DOFade(1f, _animationDuration);
            transform.DOScale(1.0f, _animationDuration).SetEase(_showEase).OnComplete(StartPulsing);

            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }

        public void HideButton()
        {
            transform.DOKill();

            _canvasGroup.DOFade(0f, _animationDuration);
            transform.DOScale(0.0f, _animationDuration).SetEase(_hideEase);
            
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }

        private void StartPulsing()
        {
            transform.DOScale(1.1f, 0.5f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
