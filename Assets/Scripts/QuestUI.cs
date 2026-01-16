using TMPro;
using UnityEngine;
using System;
public class QuestUI : MonoBehaviour {
    
    private TextMeshProUGUI questNameText;
    private QuestController _questController;
    void Start()
    {
        questNameText = gameObject.GetComponent<TextMeshProUGUI>();
    }
    
    void UpdateText(string text) {
        questNameText.text = "Boya: " + text;
    }
    void OnEnable() {
        _questController = QuestController.Instance;
        if (_questController == null) {
            Debug.LogError("QuestController.Instance NULL");
            return; 
        } 
        _questController.OnNewQuest += UpdateText;
        
    }

    void OnDisable() {
        _questController.OnNewQuest -= UpdateText;
    }
}
