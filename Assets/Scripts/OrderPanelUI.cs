using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class OrderPanelUI : MonoBehaviour
{
    public List<PaintCanData> paintCans;
    private TMP_Dropdown colorDropdown;
    [SerializeField] private Image paintCanImage;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button buyButton;
    [SerializeField] private MoneyController moneyController;
    public event Action<GameObject> OnPaintCanBought;

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
        buyButton.onClick.AddListener(BuyPaintCan);
    }

    void FillDropdown()
    {
        colorDropdown.ClearOptions();
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
        buyButton.onClick.RemoveListener(BuyPaintCan);
    }
    // Inspector'da butonun üzerinde OnValueChanged ile index'i veriyorum.
    public void ShowPaintCan(int index)
    {
        paintCanImage.sprite = paintCans[index].paintCanImage;
    }
    void BuyPaintCan()
    {
        if (moneyController.SpendMoney())
        {
            int index = colorDropdown.value;
            GameObject paintCanPB = paintCans[index].paintCanPB;
            OnPaintCanBought?.Invoke(paintCanPB);
        }
        else
        {
            NotificationUI.Instance.UpdateText("Bütçen yetersiz !");
        }
    }
}
