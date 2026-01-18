using UnityEngine;
using System;

public class FurnitureController : MonoBehaviour, IInteractable
{
    private Color color;
    private Color furnitureColor;
    private Color colorQuest;
    private MeshRenderer furniturePart;
    private FurnitureManager furnitureManager;
    public bool isFinished;
    public bool hasQuestActivated;
    public static event Action<string> OnHandChecked, OnGunCapChecked;
    public static event Action<bool> OnFurniturePainted;
    void Start()
    {
        furniturePart = gameObject.GetComponent<MeshRenderer>();
        furnitureManager = gameObject.GetComponentInParent<FurnitureManager>();

    }

    public void Interact()
    {
        ITool currentTool = PlayerController.Instance.CurrentTool;
        QuestController questController = QuestController.Instance;
        hasQuestActivated = questController.hasQuestActivated;
        PaintGun paintGun = currentTool as PaintGun; // Oyuncunun elindeki tabanca PaintGun mı değil mi?
        if (paintGun != null && paintGun.isDrained == false && hasQuestActivated)
        {
            furnitureColor = paintGun.color;
            PaintFurniture(furnitureColor);
            OnFurniturePainted?.Invoke(true);

        }
        else if (paintGun != null && paintGun.isDrained == true)
        {
            OnGunCapChecked?.Invoke("Tabancada boya kalmadı.");
        }
        else
        {
            OnHandChecked?.Invoke("Yeni bir görev almalısın.");
        }
    }
    public void PaintFurniture(Color colorDye)
    {
        furniturePart.material.color = colorDye;
        QuestController questController = QuestController.Instance;
        colorQuest = questController.currentQuestColor;

        if (colorDye != colorQuest)
        {
            isFinished = false;
            Debug.Log("Color is wrong!");
        }
        else
        {
            isFinished = true;
            furnitureManager.OnPiecePainted();
            Debug.Log("Painted true color.");

        }
    }
}
