using TMPro;
using UnityEngine;

public class PaintGunUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI paintGunColorText;
    [SerializeField] private TextMeshProUGUI paintGunRemainText;
    [SerializeField] private PaintGun paintGun;

    void OnEnable()
    {
        paintGun.OnColorSelected += UpdateColorText;
        paintGun.OnPaintShooted += UpdateRemainText;
    }

    void UpdateColorText(string colorName)
    {
        paintGunColorText.text = "Renk: " + colorName;
    }

    void UpdateRemainText(int shoots)
    {
        paintGunRemainText.text = "Kalan: " + shoots;
    }

    void OnDisable()
    {
        paintGun.OnColorSelected -= UpdateColorText;
        paintGun.OnPaintShooted -= UpdateRemainText;
    }
}
