using UnityEngine;
using System;
using System.Collections.Generic;

public class QuestController : MonoBehaviour
{

    [SerializeField] private FurnitureManager furnitureManager;
    [SerializeField] private List<QuestColorPair> questColors = new List<QuestColorPair>();
    [SerializeField] private ComputerController computerController;
    public bool hasQuestActivated;
    public Color currentQuestColor;
    private string _currentQuestName;
    public event Action OnQuestDone;
    void OnEnable()
    {
        furnitureManager.OnFinalColorPainted += CheckPaintQuest;
        computerController.OnScreenInteract += GenerateQuest;
    }
    public event Action<string> OnNewQuest;
    public void GenerateQuest()
    {
        if (hasQuestActivated == false)
        {
            var rangeNo = UnityEngine.Random.Range(0, questColors.Count);
            currentQuestColor = questColors[rangeNo].Color;
            _currentQuestName = questColors[rangeNo].ColorName;
            hasQuestActivated = true;
            OnNewQuest?.Invoke(_currentQuestName);
        }
    }
    public void CheckPaintQuest(Color colorPainted)
    {
        if (colorPainted == currentQuestColor && hasQuestActivated)
        {
            CompleteQuest();
            OnQuestDone?.Invoke();
        }
    }
    public void CompleteQuest()
    {
        hasQuestActivated = false;
        Debug.Log("Quest Complete");
    }
    void OnDisable()
    {
        furnitureManager.OnFinalColorPainted -= CheckPaintQuest;
        computerController.OnScreenInteract -= GenerateQuest;
    }
}

[Serializable]
public class QuestColorPair
{
    public Color Color;
    public string ColorName;
}