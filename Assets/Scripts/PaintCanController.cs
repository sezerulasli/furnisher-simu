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
    public event Action<Color> OnChosenColor;
    public event Action<string> OnCanDrained;
    public void Interact()
    {

    }

    public Color GetColor()
    {
        return chosenColor;
    }

    public void CanDrain()
    {
        if (paintChooseCount == paintCanCapacity)
        {
            Destroy(gameObject.transform.parent.gameObject);  // ben kovaların dışında controlcüyü tuttuğum için tüm can için parent'i komple yok ediyorum.
            Debug.Log(chColorName + " boya tükendi.");
            OnCanDrained?.Invoke(chColorName);
        }
        remainCanCap = paintCanCapacity - paintChooseCount;
        OnChosenColor?.Invoke(chosenColor);
        paintChooseCount++;
        Debug.Log(paintChooseCount);
    }

}
