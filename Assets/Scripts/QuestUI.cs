using TMPro;
using UnityEngine;
using System;
public class QuestUI : MonoBehaviour {
    
    [SerializeField] private TextMeshProUGUI questNameText;
    
    void UpdateText(string text) {
        questNameText.text = "Görev: " + text + " rengine boya.";
    }
    void OnEnable() {
        QuestController.OnNewQuest += UpdateText;
    }

    void OnDisable() {
        QuestController.OnNewQuest -= UpdateText;
    }
}
