using System;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    private int currentMoney = 100;
    public event Action<int> OnMoneyChanged;

    void Start()
    {
        OnMoneyChanged?.Invoke(currentMoney);
    }

    public void PayMoney()
    {
        currentMoney += 100;
        OnMoneyChanged?.Invoke(currentMoney);
    }

    public bool SpendMoney()
    {
        if (currentMoney >= 100)
        {
            currentMoney -= 100;
            OnMoneyChanged?.Invoke(currentMoney);
            return true;
        }
        return false;

    }


}
