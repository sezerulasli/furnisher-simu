using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private QuestController questController;
    [SerializeField] private OrderPanelUI orderPanelUI;
    [SerializeField] private GameObject furnitureForSpawn;
    [SerializeField] private GameObject envParent;
    [SerializeField] private Transform furnitureSpawnPoint;
    [SerializeField] private List<Transform> paintCanSpawnPoint;

    private GameObject newFurniture;
    public int rangeNo;
    void Start()
    {

    }

    void OnEnable()
    {
        orderPanelUI.OnPaintCanBought += SpawnPaintCan;
        questController.OnQuestDone += DestroyFurniture;
        questController.OnNewQuest += SpawnFurniture;
    }

    void SpawnFurniture()
    {
        newFurniture = Instantiate(furnitureForSpawn, furnitureSpawnPoint.position, Quaternion.identity, envParent.transform);
        questController.RegisterFurniture(newFurniture.GetComponent<FurnitureManager>());
    }

    void SpawnPaintCan(GameObject paintCanSpawned)
    {
        if (rangeNo != paintCanSpawnPoint.Count)
        {
            rangeNo += 1;
            Instantiate(paintCanSpawned, paintCanSpawnPoint[rangeNo].position, Quaternion.identity, envParent.transform);
        }

    }


    void DestroyFurniture()
    {
        Destroy(newFurniture);
    }


    void OnDisable()
    {
        orderPanelUI.OnPaintCanBought -= SpawnPaintCan;
        questController.OnQuestDone -= DestroyFurniture;
        questController.OnNewQuest -= SpawnFurniture;
    }

}
