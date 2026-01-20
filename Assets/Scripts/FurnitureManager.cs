using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class FurnitureManager : MonoBehaviour
{
    private FurnitureController[] furnitureController;
    public bool isPaid;
    private Color firstPieceColor;
    void Awake()
    {
        furnitureController = gameObject.GetComponentsInChildren<FurnitureController>();
        foreach (var part in furnitureController)
        {
            part.OnPainted += OnPainted;
        }
    }
    void Start()
    {

    }
    void OnEnable()
    {

    }
    public bool CheckIfFinished()
    {
        int checkCount = 0;
        for (int i = 0; i < furnitureController.Length; i++)
        {
            if (furnitureController[i].isPainted)
            {
                checkCount += 1;
            }
        }
        if (checkCount == furnitureController.Length)
        {
            return true;
        }
        return false;
    }

    public bool CheckColor()
    {
        int finalColor = 0;

        for (int i = 0; i < furnitureController.Length; i++)
        {
            if (furnitureController[i].furnitureColor == firstPieceColor)
            {
                finalColor += 1;
            }
        }
        if (finalColor == furnitureController.Length)
        {
            return true;
        }
        return false;

    }
    public void OnPainted()
    {
        firstPieceColor = furnitureController[0].furnitureColor;
        if (CheckIfFinished() && CheckColor())
        {
            Debug.Log("tamamı boyandı renk:" + firstPieceColor);
            // OnFinalColorChecked?.Invoke();
        }


    }

    void OnDisable()
    {
        foreach (var part in furnitureController)
        {
            part.OnPainted -= OnPainted;
        }
    }

}
