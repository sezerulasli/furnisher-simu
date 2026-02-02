using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ComputerInteractUI : MonoBehaviour
{
    [SerializeField] Button questButton;
    public event Action OnQuestBtnClicked;

    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        questButton.onClick.AddListener(QuestGenerateViaBtn);
    }

    void QuestGenerateViaBtn()
    {
        OnQuestBtnClicked?.Invoke();
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        questButton.onClick.RemoveListener(QuestGenerateViaBtn);
    }

}
