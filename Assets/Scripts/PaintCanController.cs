using UnityEngine;
using UnityEngine.Rendering.UI;
using System;

public class PaintCanController : MonoBehaviour, IInteractable {
    [SerializeField] private Color chosenColor;
    [SerializeField] private string chColorName;
    // public static PaintCanController Instance;
    
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public static event Action<string> OnChosenColor;
    public void Interact() {
        ITool currentTool = PlayerController.Instance.CurrentTool;
        PaintGun paintGun = currentTool as PaintGun;
        if (paintGun != null) {
            OnChosenColor?.Invoke(chColorName);
            ChoosePaint(paintGun);
        }
        else {
            Debug.Log("Boya silahı tutmalısın");
        }
    }

    private void ChoosePaint(PaintGun paintGun) {
        paintGun.color = chosenColor;
    }
}
