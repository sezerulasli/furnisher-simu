using Mono.Cecil.Cil;
using UnityEngine;

public class PaintGun : MonoBehaviour, ITool
{
    public string ToolName { get; set; }
    public Color color;
    public int gunDyeCap = 3;
    public int gunDyeSituation;
    public bool isDrained;
    void Start()
    {
        ToolName = "PaintGun";
        gunDyeSituation = gunDyeCap;

    }
    public void DyeDrain()
    {
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
            return true;
        }
        if (targetObject.TryGetComponent<IColorSource>(out var colorSourceObject))
        {
            ChooseColor(colorSourceObject);
            return true;
        }
        return false;
    }
    private void Paint(IPaintable paintableObject)
    {
        if (gunDyeSituation > 0)
        {
            paintableObject.BePainted(color);
            DyeDrain();
        }

    }

    private void ChooseColor(IColorSource colorSourceObject)
    {
        color = colorSourceObject.TakeColor();
        RefillDye();
    }

    private void RefillDye()
    {
        gunDyeSituation = gunDyeCap;
    }

}
