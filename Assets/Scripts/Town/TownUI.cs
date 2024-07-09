using TMPro;
using UnityEngine;

public class TownUI : MonoBehaviour
{
    public TextMeshProUGUI MoneyUI;
    private TownMain main;

    private void Init(TownMain _town)
    {
        _town.TownUI = this;
        main = _town;
        _town.OnMoneyChange += AddMoneyUI;
    }

    private void AddMoneyUI(int _money)
    {
        MoneyUI.text = "Money : " + main.Money;
    }
}
