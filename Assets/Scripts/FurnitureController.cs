using UnityEngine;
using System;

public class FurnitureController : MonoBehaviour, IInteractable, IPaintable
{
    private Color color;
    public Color furnitureColor;
    public Color originalColor;
    private MeshRenderer furniturePart;
    public bool isPainted;
    public event Action OnPainted;
    void Start()
    {
        furniturePart = gameObject.GetComponent<MeshRenderer>();
        originalColor = furniturePart.material.color;

    }

    public void Interact()
    {

    }

    public void BePainted(Color color)
    {
        furnitureColor = color;
        PaintFurniture(furnitureColor);
    }

    public void RemovePaint()
    {
        Debug.Log("çalıştım daoyğlu");
        furniturePart.material.color = originalColor;
        isPainted = false;
    }
    public void PaintFurniture(Color colorDye)
    {
        furniturePart.material.color = colorDye;
        isPainted = true;
        OnPainted?.Invoke();

    }

}
