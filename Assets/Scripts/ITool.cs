using UnityEngine;

public interface ITool
{
    string ToolName { get; set; }
    public bool Use(GameObject targetObject);
}
