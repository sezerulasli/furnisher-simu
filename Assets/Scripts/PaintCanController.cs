using UnityEngine;
using UnityEngine.Rendering.UI;
using System;

public class PaintCanController : MonoBehaviour, IInteractable
{
    [SerializeField] private Color chosenColor;
    [SerializeField] private string chColorName;
    [SerializeField] private int paintCanCapacity = 5;
    private int paintChooseCount = 0;
    public static event Action<string> OnChosenColor;
    public static event Action<string> OnCanDrained;
    public void Interact()
    {
        ITool currentTool = PlayerController.Instance.CurrentTool;
        PaintGun paintGun = currentTool as PaintGun;
        if (paintGun != null)
        {
            OnChosenColor?.Invoke(chColorName + " seçildi.");
            ChoosePaint(paintGun);
            paintChooseCount++;
            Debug.Log(paintChooseCount);
            if (paintChooseCount == paintCanCapacity)
            {
                Debug.Log(chColorName + " boya tükendi.");
                OnCanDrained?.Invoke(chColorName + " boya tükendi.");
            }
        }
        else
        {
            Debug.Log("Boya silahı tutmalısın");
        }
    }

    private void ChoosePaint(PaintGun paintGun)
    {
        paintGun.color = chosenColor;
    }
}
