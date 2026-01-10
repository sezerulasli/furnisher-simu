using UnityEngine;

public class FurnitureController : MonoBehaviour, IInteractable {
    [SerializeField] private Color color;
    
    private Color furnitureColor;
    private Color colorQuest;
    private MeshRenderer furniturePart;
    private FurnitureManager furnitureManager;
    public bool isFinished;
    public bool hasQuestActivated;
    void Start() {
        furniturePart = gameObject.GetComponent<MeshRenderer>();
        furnitureManager = gameObject.GetComponentInParent<FurnitureManager>();
        
    }
    
    public void Interact() {
        ITool currentTool = PlayerController.Instance.CurrentTool;
        QuestController questController = QuestController.Instance; 
        hasQuestActivated = questController.hasQuestActivated;
        PaintGun paintGun = currentTool as PaintGun; // Oyuncunun elindeki tabanca PaintGun mı değil mi?
        if (paintGun != null && hasQuestActivated) {
            furnitureColor = paintGun.color;
            PaintFurniture(furnitureColor);
        }
        else {
            Debug.Log("You must to hold a Paint Gun");
        }
    }
    public void PaintFurniture(Color colorDye) {
        furniturePart.material.color = colorDye;
        QuestController questController = QuestController.Instance; 
        colorQuest = questController.currentQuestColor;
        if (colorDye != colorQuest) {
            isFinished = false;
            Debug.Log("Color is wrong!");
        }
        else { 
            isFinished = true;
            furnitureManager.OnPiecePainted();
            Debug.Log("Painted true color."); 

        }
    }
}
