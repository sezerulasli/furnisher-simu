using UnityEngine;
using UnityEngine.Rendering.UI;
using System;

public class PaintCanController : MonoBehaviour, IInteractable
{
    [SerializeField] private Color chosenColor;
    [SerializeField] private string chColorName;
    [SerializeField] private int paintCanCapacity = 5;
    private int paintChooseCount = 0;
    private int remainCanCap = 0;
    public static event Action<string> OnChosenColor, OnCanDrained;
    public void Interact()
    {
        ITool currentTool = PlayerController.Instance.CurrentTool;
        PaintGun paintGun = currentTool as PaintGun;
        if (paintGun != null)
        {
            remainCanCap = paintCanCapacity - paintChooseCount;
            OnChosenColor?.Invoke(chColorName + " seçildi. Kalan boya: " + (remainCanCap - 1));
            ChoosePaint(paintGun);
            paintChooseCount++;
            Debug.Log(paintChooseCount);
            if (paintChooseCount == paintCanCapacity)
            {
                Destroy(gameObject.transform.parent.gameObject);  // ben kovaların dışında controlcüyü tuttuğum için tüm can için parent'i komple yok ediyorum.
                Debug.Log(chColorName + " boya tükendi.");
                OnCanDrained?.Invoke(chColorName + " boya tükendi.");
            }
        }
        else
        {
            Debug.Log("damn nigga.");
        }
    }

    private void ChoosePaint(PaintGun paintGun)
    {
        paintGun.color = chosenColor;
    }
}
