using System;
using UnityEngine;

namespace Managers
{
    public class DataManager : MonoBehaviour
    {
        public static DataManager Instance { get; private set; }
        
        public int MoneyAmount { get; set; }
        public int BuildingLevel { get; private set; }
        
        public int MoneyToNextUpgrade { get; private set; }

        public event Action OnDataChanged;

        private void Awake()
        {
            Instance = this;

            BuildingLevel = 1;
            MoneyAmount = 0;
            MoneyToNextUpgrade = 10;
        }

        public bool CanUpgrade()
        {
            return MoneyAmount >= MoneyToNextUpgrade;
        }

        public void AddMoney(int amount)
        {
            MoneyAmount += amount;

            OnDataChanged?.Invoke();
        }

        public void SpendMoney()
        {
            MoneyAmount -= MoneyToNextUpgrade;
            MoneyToNextUpgrade += 10;
            BuildingLevel += 1;
            
            OnDataChanged?.Invoke();
        }
    }
}
