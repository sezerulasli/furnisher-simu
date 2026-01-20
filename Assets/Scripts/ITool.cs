using UnityEngine;

public interface ITool
{
    string ToolName { get; set; }
    public void Use(GameObject targetObject) { }
}
