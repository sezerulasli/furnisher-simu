using UnityEngine;
using System;
using System.Collections.Generic;

public class QuestController : MonoBehaviour
{
    public static QuestController Instance;
    [SerializeField] private FurnitureManager furnitureManager;
    [SerializeField] private List<QuestColorPair> questColors = new List<QuestColorPair>();
    public bool hasQuestActivated;
    public Color currentQuestColor;
    private string _currentQuestName;
    void Awake()
    {
        Instance = this;
    }

    void OnEnable()
    {
        furnitureManager.OnFinalColorPainted += CheckPaintQuest;
    }
    public static event Action<string> OnNewQuest;
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
        if (colorPainted == currentQuestColor)
        {
            CompleteQuest();
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
    }
}

[Serializable]
public class QuestColorPair
{
    public Color Color;
    public string ColorName;
}