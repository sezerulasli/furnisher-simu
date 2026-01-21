using UnityEngine;
using System;
using TMPro;
public class CashUI : MonoBehaviour
{
    [SerializeField] private QuestController questController;
    [SerializeField] private TextMeshProUGUI cashText;
    private int moneyCash;
    void OnEnable()
    {
        questController.OnQuestDone += UpdateText;
    }
    void OnDisable()
    {
        questController.OnQuestDone -= UpdateText;
    }

    void UpdateText()
    {
        moneyCash += 100;
        cashText.text = "Cash: " + moneyCash + "$";
    }
}
