using Managers;
using UnityEngine;
using UnityEngine.UI;
using Views;

namespace Controllers
{
    public class UpgradeButtonController : MonoBehaviour
    {
        [SerializeField] private UpgradeButtonView _upgradeButtonView;

        [SerializeField] private Button _upgradeButton;

        private void OnEnable()
        {
            _upgradeButton.onClick.AddListener(PopupManager.Instance.ShowUpgradePopup);
            
            DataManager.Instance.OnDataChanged += UpdateData;
            
            UpdateData();
        }

        private void OnDisable()
        {
            if (PopupManager.Instance != null)
            {
                _upgradeButton.onClick.RemoveListener(PopupManager.Instance.ShowUpgradePopup);    
            }

            if (DataManager.Instance != null)
            {
                DataManager.Instance.OnDataChanged -= UpdateData;    
            }
        }

        private void UpdateData()
        {
            var isUpgradeAvailable = DataManager.Instance.CanUpgrade();

            if (isUpgradeAvailable)
            {
                _upgradeButtonView.ShowButton();
            }
            else
            {
                _upgradeButtonView.HideButton();
            }
        }
    }
}
