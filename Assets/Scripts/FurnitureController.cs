using UnityEngine;

public class FurnitureController : MonoBehaviour, IInteractable {
    [SerializeField] private Color color = Color.red;
    private Color furnitureColor;
    private MeshRenderer furniturePart;
    private FurnitureManager furnitureManager;
    public bool isFinished;
    void Start() {
        furniturePart = gameObject.GetComponent<MeshRenderer>();
        furnitureManager = gameObject.GetComponentInParent<FurnitureManager>();
    }
    
    public void Interact() {
        ITool currentTool = PlayerController.Instance.CurrentTool;
        PaintGun paintGun = currentTool as PaintGun; // Oyuncunun elindeki tabanca PaintGun mı değil mi?
        if (paintGun != null) {
            furnitureColor = paintGun.color;
            PaintFurniture(furnitureColor);
        }
        else {
            Debug.Log("You must to hold a Paint Gun");
        }
    }
    public void PaintFurniture(Color colorDye) {
        furniturePart.material.color = colorDye;
        if (colorDye != color) {
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
