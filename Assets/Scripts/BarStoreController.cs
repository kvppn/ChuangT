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
    public Item thisItem1;//属于哪个物品
    public Item thisItem2;//属于哪个物品
    public Item thisItem3;//属于哪个物品
    public Item thisItem4;//属于哪个物品
    public Item thisItem5;//属于哪个物品

    public bag Mybag;//属于哪个背包
    public bag USE_Bag;//工具栏
    public bag WorkOneBag;

    public GameObject NpcBar;//背包的画布


    public static int firstExit = 1;//判断是否是第一次退出，第一次退出会触发对话
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
        moneyController.ChangeMoney(int.Parse(Money_1.text));
  
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

        if (!Mybag.itemList.Contains(thisItem2))
        {
            Mybag.itemList.Add(thisItem2);//这个物品添加到这个包里面
            USE_Bag.itemList.Add(thisItem2);//这个物品添加到这个包里面
            WorkOneBag.itemList.Add(thisItem2);//这个物品添加到这个包里面
       
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
}
