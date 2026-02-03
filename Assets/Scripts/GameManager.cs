using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] QuestController questController;
    [SerializeField] MoneyController moneyController;
    [SerializeField] ComputerInteractUI computerInteractUI;

    void OnEnable()
    {
        questController.OnQuestDone += moneyController.PayMoney;
        computerInteractUI.OnQuestBtnClicked += questController.GenerateQuest;

    }
    void OnDisable()
    {
        questController.OnQuestDone -= moneyController.PayMoney;
        computerInteractUI.OnQuestBtnClicked -= questController.GenerateQuest;
    }
}
