using Controllers;
using UnityEngine;
using Views;

namespace Managers
{
    public class PopupManager : MonoBehaviour
    {
        public static PopupManager Instance { get; private set; }
   

        [Header("Popup setup")]
        [SerializeField] private PopupView _popupView;
        [SerializeField] private PopupController _popupController;

        private void Awake()
        {
            Instance = this;
        }

        public void ShowUpgradePopup()
        {
            _popupController.UpdateVisuals();
            _popupView.Show();   
        }

        public void HideUpgradePopup()
        {
            _popupView.Hide();
        }
    }
}
