using TMPro;
using UnityEngine;
using System;

public class ComputerController : MonoBehaviour, IInteractable {

    public static event Action<string> OnQuestWarning;

    public void Interact() {
        QuestController questController = QuestController.Instance;
        if (questController.hasQuestActivated == false) {
            questController.GenerateQuest();
        }
        else {
            OnQuestWarning?.Invoke("Tamamlanmamış bir görevin var!");
            Debug.Log("Zaten bir görevin var !");
        }
        Debug.Log("Computer Opened");
    }
}
