using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] QuestController questController;
    [SerializeField] MoneyController moneyController;
    [SerializeField] ComputerController computerController;
    void OnEnable()
    {
        questController.OnQuestDone += moneyController.PayMoney;
        computerController.OnScreenInteract += questController.GenerateQuest;
    }
    void OnDisable()
    {
        questController.OnQuestDone -= moneyController.PayMoney;
        computerController.OnScreenInteract -= questController.GenerateQuest;
    }
}
