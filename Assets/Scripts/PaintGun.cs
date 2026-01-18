using UnityEngine;

public class PaintGun : MonoBehaviour, ITool
{
    public string ToolName { get; set; }
    public Color color;
    public int gunDyeCap = 2;
    public int gunDyeSituation;
    public bool isDrained;
    void Start()
    {
        ToolName = "PaintGun";
        gunDyeSituation = gunDyeCap;

    }

    void OnEnable()
    {
        FurnitureController.OnFurniturePainted += DyeDrain;
    }
    public void DyeDrain(bool isFurniturePainted)
    {
        if (isFurniturePainted)
        {
            Debug.Log(gunDyeSituation);
            if (gunDyeSituation == 0)
            {
                isDrained = true;
            }
            gunDyeSituation--;
        }
        return;
    }

    void OnDisable()
    {
        FurnitureController.OnFurniturePainted -= DyeDrain;
    }



}
