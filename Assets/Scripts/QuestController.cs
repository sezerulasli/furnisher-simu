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
    private string _currentQuestColorName;
    public event Action OnQuestDone;
    void OnEnable()
    {
        computerController.OnScreenInteract += GenerateQuest;
    }
    public event Action<string> OnNewQuestColor;
    public event Action OnNewQuest;
    public void GenerateQuest()
    {
        if (hasQuestActivated == false)
        {
            var rangeNo = UnityEngine.Random.Range(0, questColors.Count);
            currentQuestColor = questColors[rangeNo].Color;
            _currentQuestColorName = questColors[rangeNo].ColorName;
            hasQuestActivated = true;
            OnNewQuestColor?.Invoke(_currentQuestColorName);
            OnNewQuest?.Invoke();
            Debug.Log("Görev generate edildi.");
        }
    }
    public void CheckPaintQuest(Color colorPainted)
    {
        if (colorPainted == currentQuestColor && hasQuestActivated)
        {
            Debug.Log("Görev tamamlandı");
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

    public void RegisterFurniture(FurnitureManager furnitureManager)
    {
        this.furnitureManager = furnitureManager;
        furnitureManager.OnFinalColorPainted += CheckPaintQuest;
    }
}

[Serializable]
public class QuestColorPair
{
    public Color Color;
    public string ColorName;
}