using UnityEngine;
using UnityEngine.Rendering.UI;
using System;
using System.Data;

public class PaintCanController : MonoBehaviour, IInteractable, IColorSource
{
    [SerializeField] private Color chosenColor;
    [SerializeField] private string chColorName;
    [SerializeField] private int paintCanCapacity = 5;
    private int paintChooseCount = 0;
    private int remainCanCap = 0;
    public void Interact()
    {

    }

    public Color TakeColor()
    {
        CanDrain();
        return chosenColor;
    }

    public void CanDrain()
    {
        if (paintChooseCount == paintCanCapacity)
        {
            Destroy(gameObject.transform.parent.gameObject);  // ben kovaların dışında controlcüyü tuttuğum için tüm can için parent'i komple yok ediyorum.
            NotificationUI.Instance.UpdateText(chColorName + " tükendi.");
        }
        remainCanCap = paintCanCapacity - paintChooseCount;
        NotificationUI.Instance.UpdateText(chColorName + " seçildi. Kalan boya: " + (remainCanCap));
        paintChooseCount++;
    }

}
