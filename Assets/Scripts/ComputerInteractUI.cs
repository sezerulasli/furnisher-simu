using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ComputerInteractUI : MonoBehaviour
{
    [SerializeField] Button questButton;
    [SerializeField] Button orderButton;
    [SerializeField] OrderPanelUI orderPanelUI;
    public event Action OnQuestBtnClicked;

    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        questButton.onClick.AddListener(QuestGenerateViaBtn);
        orderButton.onClick.AddListener(EnableOrderPanel);
    }

    void QuestGenerateViaBtn()
    {
        OnQuestBtnClicked?.Invoke();
        gameObject.SetActive(false);
    }

    void EnableOrderPanel()
    {
        gameObject.SetActive(false);
        orderPanelUI.gameObject.SetActive(true);
    }

    void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        questButton.onClick.RemoveListener(QuestGenerateViaBtn);
        orderButton.onClick.RemoveListener(EnableOrderPanel);
    }

}
