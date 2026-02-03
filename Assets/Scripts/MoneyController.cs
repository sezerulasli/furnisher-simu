using System;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    private int currentMoney;
    public event Action<int> OnMoneyChanged;


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
