using UnityEngine;

public class PaintRemover : MonoBehaviour, ITool
{
    public string ToolName { get; set; }
    public Color color;

    void Start()
    {
        ToolName = "PaintCleaner";
    }

    public bool Use(GameObject targetObject)
    {
        if (targetObject.TryGetComponent<IPaintable>(out var paintableObject))
        {
            PaintRemove(paintableObject);
            return true;
        }
        return false;
    }

    public void PaintRemove(IPaintable paintableObject)
    {
        paintableObject.RemovePaint();
    }

}
