using TMPro;
using UnityEngine;

public class ComputerController : MonoBehaviour, IInteractable {
    [SerializeField] private GameObject QuestUI;
    void Start() {
        
    }

    void Update()
    {
        
    }

    public void Interact() {
        QuestController questController = QuestController.Instance;
        if (questController.hasQuestActivated == false) {
            QuestUI.SetActive(true);
            questController.GenerateQuest();
        }
        else {
            Debug.Log("You have an already ongoing quest !");
        }
        Debug.Log("Computer Opened");
    }
}
