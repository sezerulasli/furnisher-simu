using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject furnitureForSpawn;
    [SerializeField] private GameObject envParent;
    private Vector3 furnitureLocation;
    [SerializeField] private QuestController questController;
    private GameObject newFurniture;

    void Start()
    {
        furnitureLocation = new Vector3(-4.15f, 1.7f, 0.6f);
    }

    void OnEnable()
    {
        questController.OnQuestDone += DestroyFurniture;
        questController.OnNewQuest += SpawnFurniture;
    }

    void SpawnFurniture()
    {
        newFurniture = Instantiate(furnitureForSpawn, furnitureLocation, Quaternion.identity, envParent.transform);
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
