using System.Collections.Generic;
using UnityEngine;

public class FurnitureManager : MonoBehaviour
{
    private FurnitureController[] furnitureController;
    public bool isPaid;

    void Awake() {
        furnitureController = gameObject.GetComponentsInChildren<FurnitureController>();
    }
    void Start() {
        
    }

    public bool CheckIfFinished() {
        int checkCount = 0;
        for (int i=0; i<furnitureController.Length; i++) {
            if (furnitureController[i].isFinished) {
                checkCount += 1;
            }
            Debug.Log(checkCount);
        }
        if (checkCount == furnitureController.Length) {
            return true;
        }
        return false;
    }

    public void Pay() { 
        GameManager.Instance.AddMoney(100); 
        Debug.Log("Current Money: " + GameManager.Instance.bankAccount);
    }

    public void OnPiecePainted() {
        QuestController questController = QuestController.Instance;
        if (CheckIfFinished() && isPaid == false) {
            isPaid = true;
            Pay();
            questController.CompleteQuest();
            NewQuestPrep();
        }
    }

    public void NewQuestPrep() {
        for (int i = 0; i < furnitureController.Length; i++) {
            furnitureController[i].isFinished = false;
        }
        isPaid = false;
    }
}
