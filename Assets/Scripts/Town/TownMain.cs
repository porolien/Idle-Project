using System.Collections.Generic;
using UnityEngine;
using System;

public class TownMain : MonoBehaviour
{
    public event Action<int> OnMoneyChange;
    public TownUI TownUI;
    private int money;
    public int Money { get { return money; } }
    public List<Building> Buildings;
    /*
    A ajouter :
    -> Un nom
    -> De la réputation
    -> le nombre d'habitants
    -> Une liste de bâtiments
    -> Une monaie premium
    */

    private void Awake()
    {
        OnMoneyChange += AddMoney;
        SendMessage("Init", this);
    }
    public void GetMoney(int _moneyGain)
    {
        OnMoneyChange.Invoke(_moneyGain);
    }

    private void AddMoney(int _moneyGain)
    {
        money += _moneyGain;
    }
}
