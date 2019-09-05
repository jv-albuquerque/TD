using UnityEngine;

public class StatusController : MonoBehaviour
{
    [SerializeField] private int hp = 20;
    [SerializeField] private int money = 1000;

    //private Cooldown moneyPerSec;

    private void Start()
    {
        SetHpText.instance.SetText = hp;
        SetMoneyText.instance.SetText = money;

        //moneyPerSec = new Cooldown(1);
        //moneyPerSec.Start();
    }

    private void Update()
    {
        /*
        if (moneyPerSec.IsFinished)
        {
            //Money += 1;
            moneyPerSec.Start();
        }*/
    }

    public int Hp { get => hp; set { hp = value; SetHpText.instance.SetText = hp; } }
    public int Money { get => money; set { money = value; SetMoneyText.instance.SetText = money; } }
}
