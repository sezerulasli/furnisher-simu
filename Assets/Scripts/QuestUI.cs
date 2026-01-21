using TMPro;
using UnityEngine;
using System;
public class QuestUI : MonoBehaviour
{
    [SerializeField] private QuestController questController;
    [SerializeField] private TextMeshProUGUI questNameText;

    void UpdateText(string text)
    {
        questNameText.text = "Görev: " + text + " rengine boya.";
    }
    void OnEnable()
    {
        questController.OnNewQuest += UpdateText;
    }

    void OnDisable()
    {
        questController.OnNewQuest -= UpdateText;
    }
}
