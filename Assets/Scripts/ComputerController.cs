using UnityEngine;

public class ComputerController : MonoBehaviour, IInteractable
{
    
    void Start() {
        
    }

    void Update()
    {
        
    }

    public void Interact() {
        QuestController questController = QuestController.Instance;
        if (questController.hasQuestActivated == false) {
            questController.GenerateQuest();
        }
        else {
            Debug.Log("You have an already ongoing quest !");
        }
        Debug.Log("Computer Opened");
    }
}
