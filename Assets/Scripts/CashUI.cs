using UnityEngine;
using System;
using TMPro;
public class CashUI : MonoBehaviour
{
    [SerializeField] private MoneyController moneyController;
    [SerializeField] private TextMeshProUGUI cashText;

    void OnEnable()
    {
        moneyController.OnMoneyChanged += UpdateText;
    }
    void OnDisable()
    {
        moneyController.OnMoneyChanged -= UpdateText;
    }

    void UpdateText(int currentMoney)
    {
        cashText.text = "Cash: " + currentMoney + "$";
    }
}
