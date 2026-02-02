using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private QuestController questController;
    [SerializeField] private GameObject furnitureForSpawn;
    [SerializeField] private GameObject envParent;
    [SerializeField] private Transform furnitureSpawnPoint;

    private GameObject newFurniture;

    void Start()
    {
        //furnitureLocation = new Vector3(-4.15f, 1.7f, 0.6f);
    }

    void OnEnable()
    {
        questController.OnQuestDone += DestroyFurniture;
        questController.OnNewQuest += SpawnFurniture;
    }

    void SpawnFurniture()
    {
        newFurniture = Instantiate(furnitureForSpawn, furnitureSpawnPoint.position, Quaternion.identity, envParent.transform);
        questController.RegisterFurniture(newFurniture.GetComponent<FurnitureManager>());
    }

    void DestroyFurniture()
    {
        Destroy(newFurniture);
    }

    void OnDisable()
    {
        questController.OnQuestDone -= DestroyFurniture;
        questController.OnNewQuest -= SpawnFurniture;
    }

}
