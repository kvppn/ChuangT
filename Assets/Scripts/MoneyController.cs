using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyController : MonoBehaviour
{
    public int money;
    public Text Money;

    // Start is called before the first frame update
    void Start()
    {
        // 从PlayerPrefs加载金钱数值，如果没有则默认为0
        money = PlayerPrefs.GetInt("moneY", 0);
        Money.text = money.ToString();
    }

    // Update is called once per frame
    // 假设这是金钱数值变化的方法（例如玩家获得或消费金钱）
    public void  ChangeMoney(int amount)
    {
        money -= amount;
        PlayerPrefs.SetInt("moneY", money); // 更新PlayerPrefs中的值
        Money.text = money.ToString(); // 更新UI显示
    }
    public void IncreaseMoney(int amount)
    {
        money += amount;
        PlayerPrefs.SetInt("moneY", money); // 更新PlayerPrefs中的值
        Money.text = money.ToString(); // 更新UI显示
    }
}
