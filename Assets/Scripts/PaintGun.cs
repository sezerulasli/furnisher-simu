using UnityEngine;

public class PaintGun : MonoBehaviour, ITool
{
    public string ToolName { get; set; }
    public Color color;
    void Start() {
        ToolName = "PaintGun";
        
    }
    
    
}
