using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public float bankAccount { get; private set; }
    public static GameManager Instance { get; private set; }
    public TextMeshProUGUI MoneyText;
    void Awake() {
        Instance = this;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void AddMoney(int money) {
        bankAccount += money;
        MoneyText.text = "Cash: " + bankAccount + " $";
    }
}
