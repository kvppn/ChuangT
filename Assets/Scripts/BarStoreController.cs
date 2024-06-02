using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarStoreController : MonoBehaviour
{
    public MoneyController moneyController;
    public Text Money_1;
    public Text Money_2;
    public Text Money_3;
    public Text Money_4;
    public Text Money_5;

    public Text money;
    private Text MoneyTotal;
    public Item thisItem1;//�����ĸ���Ʒ
    public Item thisItem2;//�����ĸ���Ʒ
    public Item thisItem3;//�����ĸ���Ʒ
    public Item thisItem4;//�����ĸ���Ʒ
    public Item thisItem5;//�����ĸ���Ʒ

    public bag Mybag;//�����ĸ�����
    public bag USE_Bag;//������
    public bag WorkOneBag;

    public GameObject NpcBar;//�����Ļ���


    public static int firstExit = 1;//�ж��Ƿ��ǵ�һ���˳�����һ���˳��ᴥ���Ի�
    void Start()
    {
        GameObject MoneyObject = GameObject.FindGameObjectWithTag("money");
        if (MoneyObject != null)
        {
            MoneyTotal = MoneyObject.GetComponent<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        money.text = MoneyTotal.text;
    }
    public void Exit()
    {
        GameObject.FindGameObjectWithTag("player").GetComponent<playerWalk>().enabled = true;
        if (firstExit == 1)
        {
            NpcBar.SetActive(false);
            NPC_Bar.flag2 = 2;
            firstExit = 2;
        }
        if (firstExit == 2)
        {
            NpcBar.SetActive(false);
        }
    }
    public void Button_1()
    {
        if (moneyController.money - int.Parse(Money_1.text) >= 0)
        {
            moneyController.ChangeMoney(int.Parse(Money_1.text));

            if (!Mybag.itemList.Contains(thisItem1))
            {
                Mybag.itemList.Add(thisItem1);//�����Ʒ��ӵ����������
                USE_Bag.itemList.Add(thisItem1);//�����Ʒ��ӵ����������
                WorkOneBag.itemList.Add(thisItem1);//�����Ʒ��ӵ����������
            }
            else
            {
                thisItem1.itemHeld += 1;
            }
            BagManager.RefreshItem();
            BagManager.RefreshUSEItem();
            BagManager.RefreshWorkOneItem();
        }
        else
        {
            Debug.Log("û���㹻�Ľ�Ǯ");
        }
    }
    public void Button_2()
    {
        if (moneyController.money - int.Parse(Money_2.text) >= 0)
        {
            moneyController.ChangeMoney(int.Parse(Money_2.text));

            if (!Mybag.itemList.Contains(thisItem2))
            {
                Mybag.itemList.Add(thisItem2);//�����Ʒ��ӵ����������
                USE_Bag.itemList.Add(thisItem2);//�����Ʒ��ӵ����������
                WorkOneBag.itemList.Add(thisItem2);//�����Ʒ��ӵ����������

            }
            else
            {
                thisItem2.itemHeld += 1;
            }
            BagManager.RefreshItem();
            BagManager.RefreshUSEItem();
            BagManager.RefreshWorkOneItem();
        }
        else
        {
            Debug.Log("û���㹻�Ľ�Ǯ");
        }
    }
    public void Button_3()
    {
        if (moneyController.money - int.Parse(Money_3.text) >= 0)
        {
            moneyController.ChangeMoney(int.Parse(Money_3.text));
            if (!Mybag.itemList.Contains(thisItem3))
            {
                Mybag.itemList.Add(thisItem3);//�����Ʒ��ӵ����������
                USE_Bag.itemList.Add(thisItem3);//�����Ʒ��ӵ����������
                WorkOneBag.itemList.Add(thisItem3);//�����Ʒ��ӵ����������
            }
            else
            {
                thisItem3.itemHeld += 1;
            }
            BagManager.RefreshItem();
            BagManager.RefreshUSEItem();
            BagManager.RefreshWorkOneItem();
        }
        else
        {
            Debug.Log("û���㹻�Ľ�Ǯ");
        }
    }
    public void Button_4()
    {
        if (moneyController.money - int.Parse(Money_4.text) >= 0)
        {
            moneyController.ChangeMoney(int.Parse(Money_4.text));
            if (!Mybag.itemList.Contains(thisItem4))
            {
                Mybag.itemList.Add(thisItem4);//�����Ʒ��ӵ����������
                USE_Bag.itemList.Add(thisItem4);//�����Ʒ��ӵ����������
                WorkOneBag.itemList.Add(thisItem4);//�����Ʒ��ӵ����������
            }
            else
            {
                thisItem4.itemHeld += 1;
            }
            BagManager.RefreshItem();
            BagManager.RefreshUSEItem();
            BagManager.RefreshWorkOneItem();
        }
        else
        {
            Debug.Log("û���㹻�Ľ�Ǯ");
        }
    }
    public void Button_5()
    {
        if (moneyController.money - int.Parse(Money_5.text) >= 0)
        {
            moneyController.ChangeMoney(int.Parse(Money_5.text));
            if (!Mybag.itemList.Contains(thisItem5))
            {
                Mybag.itemList.Add(thisItem5);//�����Ʒ��ӵ����������
                USE_Bag.itemList.Add(thisItem5);//�����Ʒ��ӵ����������
                WorkOneBag.itemList.Add(thisItem5);//�����Ʒ��ӵ����������
            }
            else
            {
                thisItem5.itemHeld += 1;
            }
            BagManager.RefreshItem();
            BagManager.RefreshUSEItem();
            BagManager.RefreshWorkOneItem();
        }
        else
        {
            Debug.Log("û���㹻�Ľ�Ǯ");
        }
    }
}
