using UnityEngine;

public class EnnemyMain : MonoBehaviour
{
    public EnnemyStat Stat;
    private void Awake()
    {
        SendMessage("Init", this);
        Stat = new EnnemyStat();
        Stat.Init();
    }
}
