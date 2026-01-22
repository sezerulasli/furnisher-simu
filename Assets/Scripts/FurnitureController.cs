using UnityEngine;
using System;

public class FurnitureController : MonoBehaviour, IInteractable, IPaintable
{
    private Color color;
    public Color furnitureColor;
    private MeshRenderer furniturePart;
    public bool isPainted;
    public event Action OnPainted;
    void Start()
    {
        furniturePart = gameObject.GetComponent<MeshRenderer>();

    }

    public void Interact()
    {

    }

    public void BePainted(Color color)
    {
        furnitureColor = color;
        PaintFurniture(furnitureColor);
    }

    public void PaintFurniture(Color colorDye)
    {
        furniturePart.material.color = colorDye;
        isPainted = true;
        OnPainted?.Invoke();

    }

}
