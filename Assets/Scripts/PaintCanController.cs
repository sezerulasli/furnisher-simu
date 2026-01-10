using UnityEngine;
using UnityEngine.Rendering.UI;

public class PaintCanController : MonoBehaviour, IInteractable {
    [SerializeField] private Color chosenColor;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void Interact() {
        ITool currentTool = PlayerController.Instance.CurrentTool;
        PaintGun paintGun = currentTool as PaintGun;
        if (paintGun != null) {
            Debug.Log("birseyler calisiyor mu");
            ChoosePaint(paintGun);
        }
        else {
            Debug.Log("You must to hold a Paint Gun");
        }
    }

    private void ChoosePaint(PaintGun paintGun) {
        paintGun.color = chosenColor;
    }
}
