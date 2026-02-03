using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrderPanelUI : MonoBehaviour
{
    public List<PaintCanData> paintCans;
    private TMP_Dropdown colorDropdown;
    [SerializeField] private Image paintCanImage;
    [SerializeField] private Button exitButton;
    void Start()
    {
        colorDropdown = GetComponentInChildren<TMP_Dropdown>();
        FillDropdown();
    }
    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        exitButton.onClick.AddListener(ExitMode);
    }

    void FillDropdown()
    {
        List<TMP_Dropdown.OptionData> newOptions = new List<TMP_Dropdown.OptionData>();
        foreach (var item in paintCans)
        {
            var paintCanPacket = new TMP_Dropdown.OptionData();
            paintCanPacket.text = item.paintCanName;
            paintCanPacket.image = item.paintCanImage;
            newOptions.Add(paintCanPacket);
        }
        colorDropdown.AddOptions(newOptions);

        ShowPaintCan(0);
    }

    void ExitMode()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        exitButton.onClick.RemoveListener(ExitMode);
    }

    public void ShowPaintCan(int index)
    {
        paintCanImage.sprite = paintCans[index].paintCanImage;
    }
}
