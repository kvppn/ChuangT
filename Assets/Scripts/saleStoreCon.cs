using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class saleStoreCon : MonoBehaviour
{
    public MoneyController moneyController;
    public Text Money_1;
    public Text Money_2;
    public Text Money_3;
    public Text Money_4;
    public Text Money_5;
    public Text Money_6;
    public Text Money_7;
    public Text Money_8;
    public Text Money_9;
    public Text Money_10;
    public Text Money_11;
    public Text Money_12;
    public Text Money_13;
    public Text Money_14;
    public Text Money_15;
    public Text Money_16;
    public Text Money_17;
    public Text Money_18;
    public Text Money_19;
    public Text Money_20;
    public Text Money_21;
    public Text Money_22;
    public Text Money_23;

    public Text money;
    private Text MoneyTotal;
    public Item thisItem1;//�����ĸ���Ʒ
    public Item thisItem2;//�����ĸ���Ʒ
    public Item thisItem3;//�����ĸ���Ʒ
    public Item thisItem4;//�����ĸ���Ʒ
    public Item thisItem5;//�����ĸ���Ʒ
    public Item thisItem6;//�����ĸ���Ʒ
    public Item thisItem7;//�����ĸ���Ʒ
    public Item thisItem8;//�����ĸ���Ʒ
    public Item thisItem9;//�����ĸ���Ʒ
    public Item thisItem10;//�����ĸ���Ʒ
    public Item thisItem11;//�����ĸ���Ʒ
    public Item thisItem12;//�����ĸ���Ʒ
    public Item thisItem13;//�����ĸ���Ʒ
    public Item thisItem14;//�����ĸ���Ʒ
    public Item thisItem15;//�����ĸ���Ʒ
    public Item thisItem16;//�����ĸ���Ʒ
    public Item thisItem17;//�����ĸ���Ʒ
    public Item thisItem18;//�����ĸ���Ʒ
    public Item thisItem19;//�����ĸ���Ʒ
    public Item thisItem20;//�����ĸ���Ʒ
    public Item thisItem21;//�����ĸ���Ʒ
    public Item thisItem22;//�����ĸ���Ʒ
    public Item thisItem23;//�����ĸ���Ʒ


    public bag Mybag;//�����ĸ�����
    public bag USE_Bag;//������
    public bag WorkOneBag;
    public bag WorkTwoBag;

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
  
    public void Button_1()
    {
        moneyController.ChangeMoney(int.Parse(Money_1.text));
        //MoneyTotal.text = (int.Parse(MoneyTotal.text) - int.Parse(Money_1.text)).ToString();
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
    public void Button_2()
    {
        moneyController.ChangeMoney(int.Parse(Money_2.text));
        //MoneyTotal.text = (int.Parse(MoneyTotal.text) - int.Parse(Money_2.text)).ToString();
        if (!Mybag.itemList.Contains(thisItem2))
        {
            Mybag.itemList.Add(thisItem2);//�����Ʒ��ӵ����������
            USE_Bag.itemList.Add(thisItem2);//�����Ʒ��ӵ����������
            WorkOneBag.itemList.Add(thisItem2);//�����Ʒ��ӵ����������
            //BagManager.CreateNewItem(thisItem);
        }
        else
        {
            thisItem2.itemHeld += 1;
        }
        BagManager.RefreshItem();
        BagManager.RefreshUSEItem();
        BagManager.RefreshWorkOneItem();
    }
    public void Button_3()
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
    public void Button_4()
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
    public void Button_5()
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
    public void Button_6()
    {
        moneyController.ChangeMoney(int.Parse(Money_6.text));
        if (!Mybag.itemList.Contains(thisItem6))
        {
            Mybag.itemList.Add(thisItem6);//�����Ʒ��ӵ����������
            USE_Bag.itemList.Add(thisItem6);//�����Ʒ��ӵ����������
            WorkOneBag.itemList.Add(thisItem6);//�����Ʒ��ӵ����������
        }
        else
        {
            thisItem6.itemHeld += 1;
        }
        BagManager.RefreshItem();
        BagManager.RefreshUSEItem();
        BagManager.RefreshWorkOneItem();
    }
    public void Button_7()
    {
        moneyController.ChangeMoney(int.Parse(Money_7.text));
        if (!Mybag.itemList.Contains(thisItem7))
        {
            Mybag.itemList.Add(thisItem7);//�����Ʒ��ӵ����������
            USE_Bag.itemList.Add(thisItem7);//�����Ʒ��ӵ����������
            WorkOneBag.itemList.Add(thisItem7);//�����Ʒ��ӵ����������
        }
        else
        {
            thisItem7.itemHeld += 1;
        }
        BagManager.RefreshItem();
        BagManager.RefreshUSEItem();
        BagManager.RefreshWorkOneItem();
    }
    public void Button_8()
    {
        moneyController.ChangeMoney(int.Parse(Money_8.text));
        if (!Mybag.itemList.Contains(thisItem8))
        {
            Mybag.itemList.Add(thisItem8);//�����Ʒ��ӵ����������
            USE_Bag.itemList.Add(thisItem8);//�����Ʒ��ӵ����������
            WorkOneBag.itemList.Add(thisItem8);//�����Ʒ��ӵ����������
        }
        else
        {
            thisItem8.itemHeld += 1;
        }
        BagManager.RefreshItem();
        BagManager.RefreshUSEItem();
        BagManager.RefreshWorkOneItem();
    }
    public void Button_9()
    {
        moneyController.ChangeMoney(int.Parse(Money_9.text));
        if (!Mybag.itemList.Contains(thisItem9))
        {
            Mybag.itemList.Add(thisItem9);//�����Ʒ��ӵ����������
            USE_Bag.itemList.Add(thisItem9);//�����Ʒ��ӵ����������
            WorkOneBag.itemList.Add(thisItem9);//�����Ʒ��ӵ����������
        }
        else
        {
            thisItem9.itemHeld += 1;
        }
        BagManager.RefreshItem();
        BagManager.RefreshUSEItem();
        BagManager.RefreshWorkOneItem();
    }
    public void Button_10()
    {
        moneyController.ChangeMoney(int.Parse(Money_10.text));
        if (!Mybag.itemList.Contains(thisItem10))
        {
            Mybag.itemList.Add(thisItem10);//�����Ʒ��ӵ����������
            USE_Bag.itemList.Add(thisItem10);//�����Ʒ��ӵ����������
            WorkOneBag.itemList.Add(thisItem10);//�����Ʒ��ӵ����������
        }
        else
        {
            thisItem10.itemHeld += 1;
        }
        BagManager.RefreshItem();
        BagManager.RefreshUSEItem();
        BagManager.RefreshWorkOneItem();
    }
    public void Button_11()
    {
        moneyController.ChangeMoney(int.Parse(Money_11.text));
        if (!Mybag.itemList.Contains(thisItem11))
        {
            Mybag.itemList.Add(thisItem11);//�����Ʒ��ӵ����������
            USE_Bag.itemList.Add(thisItem11);//�����Ʒ��ӵ����������
            WorkOneBag.itemList.Add(thisItem11);//�����Ʒ��ӵ����������
        }
        else
        {
            thisItem11.itemHeld += 1;
        }
        BagManager.RefreshItem();
        BagManager.RefreshUSEItem();
        BagManager.RefreshWorkOneItem();
    }
    public void Button_12()
    {
        moneyController.ChangeMoney(int.Parse(Money_12.text));
        if (!Mybag.itemList.Contains(thisItem12))
        {
            Mybag.itemList.Add(thisItem12);//�����Ʒ��ӵ����������
            USE_Bag.itemList.Add(thisItem12);//�����Ʒ��ӵ����������
            WorkOneBag.itemList.Add(thisItem12);//�����Ʒ��ӵ����������
        }
        else
        {
            thisItem12.itemHeld += 1;
        }
        BagManager.RefreshItem();
        BagManager.RefreshUSEItem();
        BagManager.RefreshWorkOneItem();
    }
    public void Button_13()
    {
        moneyController.ChangeMoney(int.Parse(Money_13.text));
        if (!Mybag.itemList.Contains(thisItem13))
        {
            Mybag.itemList.Add(thisItem13);//�����Ʒ��ӵ����������
            USE_Bag.itemList.Add(thisItem13);//�����Ʒ��ӵ����������
            WorkOneBag.itemList.Add(thisItem13);//�����Ʒ��ӵ����������
        }
        else
        {
            thisItem13.itemHeld += 1;
        }
        BagManager.RefreshItem();
        BagManager.RefreshUSEItem();
        BagManager.RefreshWorkOneItem();
    }
    public void Button_14()
    {
        moneyController.ChangeMoney(int.Parse(Money_14.text));
        if (!Mybag.itemList.Contains(thisItem14))
        {
            Mybag.itemList.Add(thisItem14);//�����Ʒ��ӵ����������
            USE_Bag.itemList.Add(thisItem14);//�����Ʒ��ӵ����������
            WorkOneBag.itemList.Add(thisItem14);//�����Ʒ��ӵ����������
        }
        else
        {
            thisItem14.itemHeld += 1;
        }
        BagManager.RefreshItem();
        BagManager.RefreshUSEItem();
        BagManager.RefreshWorkOneItem();
    }
    public void Button_15()
    {
        moneyController.ChangeMoney(int.Parse(Money_15.text));
        if (!Mybag.itemList.Contains(thisItem15))
        {
            Mybag.itemList.Add(thisItem15);//�����Ʒ��ӵ����������
            USE_Bag.itemList.Add(thisItem15);//�����Ʒ��ӵ����������
            WorkOneBag.itemList.Add(thisItem15);//�����Ʒ��ӵ����������
        }
        else
        {
            thisItem15.itemHeld += 1;
        }
        BagManager.RefreshItem();
        BagManager.RefreshUSEItem();
        BagManager.RefreshWorkOneItem();
    }
    public void Button_16()
    {
        moneyController.ChangeMoney(int.Parse(Money_16.text));
        if (!Mybag.itemList.Contains(thisItem16))
        {
            Mybag.itemList.Add(thisItem16);//�����Ʒ��ӵ����������
            USE_Bag.itemList.Add(thisItem16);//�����Ʒ��ӵ����������
            WorkOneBag.itemList.Add(thisItem16);//�����Ʒ��ӵ����������
        }
        else
        {
            thisItem16.itemHeld += 1;
        }
        BagManager.RefreshItem();
        BagManager.RefreshUSEItem();
        BagManager.RefreshWorkOneItem();
    }
    public void Button_17()
    {
        moneyController.ChangeMoney(int.Parse(Money_17.text));
        if (!Mybag.itemList.Contains(thisItem17))
        {
            Mybag.itemList.Add(thisItem17);//�����Ʒ��ӵ����������
            USE_Bag.itemList.Add(thisItem17);//�����Ʒ��ӵ����������
            WorkOneBag.itemList.Add(thisItem17);//�����Ʒ��ӵ����������
        }
        else
        {
            thisItem17.itemHeld += 1;
        }
        BagManager.RefreshItem();
        BagManager.RefreshUSEItem();
        BagManager.RefreshWorkOneItem();
    }
    public void Button_18()
    {
        moneyController.ChangeMoney(int.Parse(Money_18.text));
        if (!Mybag.itemList.Contains(thisItem18))
        {
            Mybag.itemList.Add(thisItem18);//�����Ʒ��ӵ����������
            USE_Bag.itemList.Add(thisItem18);//�����Ʒ��ӵ����������
            WorkOneBag.itemList.Add(thisItem18);//�����Ʒ��ӵ����������
        }
        else
        {
            thisItem18.itemHeld += 1;
        }
        BagManager.RefreshItem();
        BagManager.RefreshUSEItem();
        BagManager.RefreshWorkOneItem();
    }
    public void Button_19()
    {
        moneyController.ChangeMoney(int.Parse(Money_19.text));
        if (!Mybag.itemList.Contains(thisItem19))
        {
            Mybag.itemList.Add(thisItem19);//�����Ʒ��ӵ����������
            USE_Bag.itemList.Add(thisItem19);//�����Ʒ��ӵ����������
            WorkOneBag.itemList.Add(thisItem19);//�����Ʒ��ӵ����������
        }
        else
        {
            thisItem19.itemHeld += 1;
        }
        BagManager.RefreshItem();
        BagManager.RefreshUSEItem();
        BagManager.RefreshWorkOneItem();
    }
    public void Button_20()
    {
        moneyController.ChangeMoney(int.Parse(Money_20.text));
        if (!Mybag.itemList.Contains(thisItem20))
        {
            Mybag.itemList.Add(thisItem20);//�����Ʒ��ӵ����������
            USE_Bag.itemList.Add(thisItem20);//�����Ʒ��ӵ����������
            WorkOneBag.itemList.Add(thisItem20);//�����Ʒ��ӵ����������
        }
        else
        {
            thisItem20.itemHeld += 1;
        }
        BagManager.RefreshItem();
        BagManager.RefreshUSEItem();
        BagManager.RefreshWorkOneItem();
    }
    public void Button_21()
    {
        moneyController.ChangeMoney(int.Parse(Money_21.text));
        if (!Mybag.itemList.Contains(thisItem21))
        {
            Mybag.itemList.Add(thisItem21);//�����Ʒ��ӵ����������
            USE_Bag.itemList.Add(thisItem21);//�����Ʒ��ӵ����������
            WorkOneBag.itemList.Add(thisItem21);//�����Ʒ��ӵ����������
        }
        else
        {
            thisItem21.itemHeld += 1;
        }
        BagManager.RefreshItem();
        BagManager.RefreshUSEItem();
        BagManager.RefreshWorkOneItem();
    }
    public void Button_22()
    {
        moneyController.ChangeMoney(int.Parse(Money_22.text));
        if (!Mybag.itemList.Contains(thisItem22))
        {
            Mybag.itemList.Add(thisItem22);//�����Ʒ��ӵ����������
            USE_Bag.itemList.Add(thisItem22);//�����Ʒ��ӵ����������
            WorkOneBag.itemList.Add(thisItem22);//�����Ʒ��ӵ����������
        }
        else
        {
            thisItem22.itemHeld += 1;
        }
        BagManager.RefreshItem();
        BagManager.RefreshUSEItem();
        BagManager.RefreshWorkOneItem();
    }
    public void Button_23()
    {
        moneyController.ChangeMoney(int.Parse(Money_23.text));
        if (!Mybag.itemList.Contains(thisItem23))
        {
            Mybag.itemList.Add(thisItem23);//�����Ʒ��ӵ����������
            USE_Bag.itemList.Add(thisItem23);//�����Ʒ��ӵ����������
            WorkOneBag.itemList.Add(thisItem23);//�����Ʒ��ӵ����������
        }
        else
        {
            thisItem23.itemHeld += 1;
        }
        BagManager.RefreshItem();
        BagManager.RefreshUSEItem();
        BagManager.RefreshWorkOneItem();
    }
}
