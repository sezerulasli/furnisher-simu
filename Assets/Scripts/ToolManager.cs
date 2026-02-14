using UnityEngine;
using System;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ToolManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> allTools;
    public ITool CurrentTool;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public ITool SelectTool(int index)
    {
        for (int i = 0; i < allTools.Count; i++)
        {
            if (index == i)
            {
                allTools[i].SetActive(true);
                CurrentTool = allTools[index].GetComponent<ITool>();
            }
            else
            {
                allTools[i].SetActive(false);
            }
        }
        return CurrentTool;
    }

}
