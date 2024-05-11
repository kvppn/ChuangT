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
    public Item thisItem1;//属于哪个物品
    public Item thisItem2;//属于哪个物品
    public Item thisItem3;//属于哪个物品
    public Item thisItem4;//属于哪个物品
    public Item thisItem5;//属于哪个物品
    public Item thisItem6;//属于哪个物品
    public Item thisItem7;//属于哪个物品
    public Item thisItem8;//属于哪个物品
    public Item thisItem9;//属于哪个物品
    public Item thisItem10;//属于哪个物品
    public Item thisItem11;//属于哪个物品
    public Item thisItem12;//属于哪个物品
    public Item thisItem13;//属于哪个物品
    public Item thisItem14;//属于哪个物品
    public Item thisItem15;//属于哪个物品
    public Item thisItem16;//属于哪个物品
    public Item thisItem17;//属于哪个物品
    public Item thisItem18;//属于哪个物品
    public Item thisItem19;//属于哪个物品
    public Item thisItem20;//属于哪个物品
    public Item thisItem21;//属于哪个物品
    public Item thisItem22;//属于哪个物品
    public Item thisItem23;//属于哪个物品


    public bag Mybag;//属于哪个背包
    public bag USE_Bag;//工具栏
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
            Mybag.itemList.Add(thisItem1);//这个物品添加到这个包里面
            USE_Bag.itemList.Add(thisItem1);//这个物品添加到这个包里面
            WorkOneBag.itemList.Add(thisItem1);//这个物品添加到这个包里面
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
            Mybag.itemList.Add(thisItem2);//这个物品添加到这个包里面
            USE_Bag.itemList.Add(thisItem2);//这个物品添加到这个包里面
            WorkOneBag.itemList.Add(thisItem2);//这个物品添加到这个包里面
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
            Mybag.itemList.Add(thisItem3);//这个物品添加到这个包里面
            USE_Bag.itemList.Add(thisItem3);//这个物品添加到这个包里面
            WorkOneBag.itemList.Add(thisItem3);//这个物品添加到这个包里面
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
            Mybag.itemList.Add(thisItem4);//这个物品添加到这个包里面
            USE_Bag.itemList.Add(thisItem4);//这个物品添加到这个包里面
            WorkOneBag.itemList.Add(thisItem4);//这个物品添加到这个包里面
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
            Mybag.itemList.Add(thisItem5);//这个物品添加到这个包里面
            USE_Bag.itemList.Add(thisItem5);//这个物品添加到这个包里面
            WorkOneBag.itemList.Add(thisItem5);//这个物品添加到这个包里面
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
            Mybag.itemList.Add(thisItem6);//这个物品添加到这个包里面
            USE_Bag.itemList.Add(thisItem6);//这个物品添加到这个包里面
            WorkOneBag.itemList.Add(thisItem6);//这个物品添加到这个包里面
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
            Mybag.itemList.Add(thisItem7);//这个物品添加到这个包里面
            USE_Bag.itemList.Add(thisItem7);//这个物品添加到这个包里面
            WorkOneBag.itemList.Add(thisItem7);//这个物品添加到这个包里面
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
            Mybag.itemList.Add(thisItem8);//这个物品添加到这个包里面
            USE_Bag.itemList.Add(thisItem8);//这个物品添加到这个包里面
            WorkOneBag.itemList.Add(thisItem8);//这个物品添加到这个包里面
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
            Mybag.itemList.Add(thisItem9);//这个物品添加到这个包里面
            USE_Bag.itemList.Add(thisItem9);//这个物品添加到这个包里面
            WorkOneBag.itemList.Add(thisItem9);//这个物品添加到这个包里面
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
            Mybag.itemList.Add(thisItem10);//这个物品添加到这个包里面
            USE_Bag.itemList.Add(thisItem10);//这个物品添加到这个包里面
            WorkOneBag.itemList.Add(thisItem10);//这个物品添加到这个包里面
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
            Mybag.itemList.Add(thisItem11);//这个物品添加到这个包里面
            USE_Bag.itemList.Add(thisItem11);//这个物品添加到这个包里面
            WorkOneBag.itemList.Add(thisItem11);//这个物品添加到这个包里面
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
            Mybag.itemList.Add(thisItem12);//这个物品添加到这个包里面
            USE_Bag.itemList.Add(thisItem12);//这个物品添加到这个包里面
            WorkOneBag.itemList.Add(thisItem12);//这个物品添加到这个包里面
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
            Mybag.itemList.Add(thisItem13);//这个物品添加到这个包里面
            USE_Bag.itemList.Add(thisItem13);//这个物品添加到这个包里面
            WorkOneBag.itemList.Add(thisItem13);//这个物品添加到这个包里面
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
            Mybag.itemList.Add(thisItem14);//这个物品添加到这个包里面
            USE_Bag.itemList.Add(thisItem14);//这个物品添加到这个包里面
            WorkOneBag.itemList.Add(thisItem14);//这个物品添加到这个包里面
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
            Mybag.itemList.Add(thisItem15);//这个物品添加到这个包里面
            USE_Bag.itemList.Add(thisItem15);//这个物品添加到这个包里面
            WorkOneBag.itemList.Add(thisItem15);//这个物品添加到这个包里面
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
            Mybag.itemList.Add(thisItem16);//这个物品添加到这个包里面
            USE_Bag.itemList.Add(thisItem16);//这个物品添加到这个包里面
            WorkOneBag.itemList.Add(thisItem16);//这个物品添加到这个包里面
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
            Mybag.itemList.Add(thisItem17);//这个物品添加到这个包里面
            USE_Bag.itemList.Add(thisItem17);//这个物品添加到这个包里面
            WorkOneBag.itemList.Add(thisItem17);//这个物品添加到这个包里面
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
            Mybag.itemList.Add(thisItem18);//这个物品添加到这个包里面
            USE_Bag.itemList.Add(thisItem18);//这个物品添加到这个包里面
            WorkOneBag.itemList.Add(thisItem18);//这个物品添加到这个包里面
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
            Mybag.itemList.Add(thisItem19);//这个物品添加到这个包里面
            USE_Bag.itemList.Add(thisItem19);//这个物品添加到这个包里面
            WorkOneBag.itemList.Add(thisItem19);//这个物品添加到这个包里面
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
            Mybag.itemList.Add(thisItem20);//这个物品添加到这个包里面
            USE_Bag.itemList.Add(thisItem20);//这个物品添加到这个包里面
            WorkOneBag.itemList.Add(thisItem20);//这个物品添加到这个包里面
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
            Mybag.itemList.Add(thisItem21);//这个物品添加到这个包里面
            USE_Bag.itemList.Add(thisItem21);//这个物品添加到这个包里面
            WorkOneBag.itemList.Add(thisItem21);//这个物品添加到这个包里面
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
            Mybag.itemList.Add(thisItem22);//这个物品添加到这个包里面
            USE_Bag.itemList.Add(thisItem22);//这个物品添加到这个包里面
            WorkOneBag.itemList.Add(thisItem22);//这个物品添加到这个包里面
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
            Mybag.itemList.Add(thisItem23);//这个物品添加到这个包里面
            USE_Bag.itemList.Add(thisItem23);//这个物品添加到这个包里面
            WorkOneBag.itemList.Add(thisItem23);//这个物品添加到这个包里面
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
