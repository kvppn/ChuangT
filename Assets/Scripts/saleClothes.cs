using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saleClothes : MonoBehaviour
{
    public static int Money;
    public MoneyController moneyy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moneyy = GameObject.FindGameObjectWithTag("money").GetComponent<MoneyController>();
    }
    public static void GetMoneyNum(int money)
    {
        Money = money;
    }
    public void Onclick()
    {
        moneyy.IncreaseMoney(Money);
    }
}
