using Mono.Cecil.Cil;
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
    public void DyeDrain()
    {
        Debug.Log(gunDyeSituation);
        gunDyeSituation--;
        if (gunDyeSituation == 0)
        {
            isDrained = true;
        }

    }
    public bool Use(GameObject targetObject)
    {
        if (targetObject.TryGetComponent<IPaintable>(out var paintableObject))
        {
            Paint(paintableObject);
            Debug.Log("MOBİLYA BOYADIM");
            return true;
        }
        if (targetObject.TryGetComponent<IColorSource>(out var colorSourceObject))
        {
            ChooseColor(colorSourceObject);
            Debug.Log("KOVADAN BOYA ALDIM");
            return true;
        }
        return false;
    }
    private void Paint(IPaintable paintableObject)
    {
        if (gunDyeSituation > 0)
        {
            paintableObject.BePainted(color);
            Debug.Log("MOBİLYA BOYADIM 2");
            DyeDrain();
        }

    }

    private void ChooseColor(IColorSource colorSourceObject)
    {
        color = colorSourceObject.GetColor();
    }


}
