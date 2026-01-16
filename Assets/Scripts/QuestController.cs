using UnityEngine;
using System;

public class QuestController : MonoBehaviour {
    public static QuestController Instance; 

    public bool hasQuestActivated;
    public Color currentQuestColor;
    private string _currentQuestName;
    private Color[] _questColors = {Color.red, Color.blue, Color.green, Color.black, Color.purple, Color.yellow, Color.white, Color.gray, Color.pink};
    private string[] _questColorsName = { "Kırmızı", "Mavi", "Yeşil", "Siyah", "Mor", "Sarı", "Beyaz", "Gri", "Pembe" };
    void Awake() {
        Instance = this;
        Debug.Log("Quest Controller Awake");
    } 
    
    public event Action<string> OnNewQuest;
    public void GenerateQuest() {
        if (hasQuestActivated == false) {
            var rangeNo = UnityEngine.Random.Range(0, _questColors.Length);
            currentQuestColor = _questColors[rangeNo];
            _currentQuestName = _questColorsName[rangeNo];
            hasQuestActivated = true;
           OnNewQuest?.Invoke(_currentQuestName);
        }
    }

    public void CompleteQuest() {
        hasQuestActivated = false;
        Debug.Log("Quest Complete");
    }
    
}
