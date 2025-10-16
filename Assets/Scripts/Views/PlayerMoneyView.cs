using Managers;
using TMPro;
using UnityEngine;

namespace Views
{
    public class PlayerMoneyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyAmountText;

        private void OnEnable()
        {
            DataManager.Instance.OnDataChanged += UpdateMoneyAmountText;
            
            UpdateMoneyAmountText();
        }

        private void OnDisable()
        {
            if (DataManager.Instance != null)
            {
                DataManager.Instance.OnDataChanged -= UpdateMoneyAmountText;
            }
        }

        private void UpdateMoneyAmountText()
        {
            var moneyAmount = DataManager.Instance.MoneyAmount;

            _moneyAmountText.text = $"{moneyAmount}";
        }
    }
}
