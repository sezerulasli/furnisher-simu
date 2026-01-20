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
    public void Use(GameObject targetObject)
    {
        if (targetObject.TryGetComponent<IPaintable>(out var paintableObject))
        {
            // Debug.Log("Obje görüldü");
            Paint(paintableObject);
        }
    }
    private void Paint(IPaintable paintableObject)
    {
        if (gunDyeSituation > 0)
        {
            paintableObject.Paint(color);
            DyeDrain();
        }

    }




}
