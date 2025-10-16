using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class PopupController : MonoBehaviour
    {
        [Header("Text items")]
        [SerializeField] private TextMeshProUGUI _fromLevelText;
        [SerializeField] private TextMeshProUGUI _toLevelText;
        [SerializeField] private TextMeshProUGUI _moneyToUpgradeText;

        [Header("Buttons")]
        [SerializeField] private Button _confirmUpgradeButton;
        [SerializeField] private Button _closePopupButton;

        private void OnEnable()
        {
            _confirmUpgradeButton.onClick.AddListener(UpgradeBuilding);
            _closePopupButton.onClick.AddListener(PopupManager.Instance.HideUpgradePopup);    
            
            DataManager.Instance.OnDataChanged += UpdateVisuals;    
        }

        private void OnDisable()
        {
            _confirmUpgradeButton.onClick.RemoveListener(UpgradeBuilding);

            if (PopupManager.Instance != null)
            {
                _closePopupButton.onClick.RemoveListener(PopupManager.Instance.HideUpgradePopup);
            }

            if (DataManager.Instance != null)
            {
                DataManager.Instance.OnDataChanged -= UpdateVisuals;
            }
        }

        public void UpdateVisuals()
        {
            var buildingLevel = DataManager.Instance.BuildingLevel;
            var moneyToNextUpgrade = DataManager.Instance.MoneyToNextUpgrade;

            _fromLevelText.text = $"LVL{buildingLevel}";
            _toLevelText.text = $"LVL{buildingLevel + 1}";
            _moneyToUpgradeText.text = $"{moneyToNextUpgrade}";
        }

        private void UpgradeBuilding()
        {
            if (!DataManager.Instance.CanUpgrade()) return;
            
            DataManager.Instance.SpendMoney();
        }
    }
}
