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
        // ��PlayerPrefs���ؽ�Ǯ��ֵ�����û����Ĭ��Ϊ0
        money = PlayerPrefs.GetInt("moneY", 0);
        Money.text = money.ToString();
    }

    // Update is called once per frame
    // �������ǽ�Ǯ��ֵ�仯�ķ�����������һ�û����ѽ�Ǯ��
    public void  ChangeMoney(int amount)
    {
        money -= amount;
        PlayerPrefs.SetInt("moneY", money); // ����PlayerPrefs�е�ֵ
        Money.text = money.ToString(); // ����UI��ʾ
    }
    public void IncreaseMoney(int amount)
    {
        money += amount;
        PlayerPrefs.SetInt("moneY", money); // ����PlayerPrefs�е�ֵ
        Money.text = money.ToString(); // ����UI��ʾ
    }
}
