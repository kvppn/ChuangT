using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//物品触碰添加的时候可以调用此代码在UI界面上生成slot
public class BagManager : MonoBehaviour
{
    public  static BagManager instance;
    public bag Mybag;
    public bag USE_Bag;
    public bag WorkOneBag;//合成布合成线合成染料工作台
    public bag WorkTwoBag;//合成衣服工作台
    public bag CraftingBag;
    public bag SaleBag;
    public GameObject slotGrid;
    public GameObject USEGrid;
    public GameObject WorkOneGrid;
    public GameObject WorkTwoGrid;
    public GameObject CraftingGrid;
    public GameObject CraftingGrid2;
    public GameObject saleGrid;
    public Slot slotPrefab;
    public useSlot USEslotPrefab;
    public workOneSlot workOneslotPrefab;
    public CraftingSlot CraftingslotPrefab;
    public SaleSlot saleSlotPrefab;

    public Dictionary<string, Item> WorkOneBagItems = new Dictionary<string, Item>();//储存工作台a的物品数据
    public Dictionary<string, Item> WorkTwoBagItems = new Dictionary<string, Item>();//储存工作台b的物品数据
    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }
    private void OnEnable()
    {
        RefreshItem();
        RefreshUSEItem();
        RefreshWorkOneItem();
        RefreshSaleItem();
        Debug.Log("onenbke");
    }
    private void Start()
    {
        InitBagItemsXY(instance.WorkOneBag, instance.WorkOneBagItems);
        InitBagItemsXY(instance.WorkTwoBag, instance.WorkTwoBagItems);
    }
    /// <summary>
    /// 初始化背包
    /// </summary>
    /// <param name="bag"></param>
    private void InitBagItemsXY(bag bag, Dictionary<string, Item> bagItems)
    {
        for (int i = 0; i < bag.itemList.Count; i++)
        {
            if (bagItems.ContainsKey(bag.itemList[i].itemName))
            {
                bagItems[bag.itemList[i].itemName].itemHeld += bag.itemList[i].itemHeld;
            }
            else
            {
                bagItems.Add(bag.itemList[i].itemName,bag.itemList[i]);
            }
            if (bagItems[bag.itemList[i].itemName].itemHeld <= 0)
                bagItems.Remove(bag.itemList[i].itemName);
        }


    }

    public static void CreateNewItem(Item item)
    {
        
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);

      /*  useSlot newItemUSE = Instantiate(instance.USEslotPrefab, instance.USEGrid.transform.position, Quaternion.identity);
        newItemUSE.gameObject.transform.SetParent(instance.USEGrid.transform);*/

        newItem.slotImage.sprite = item.itemImage;
        newItem.slotItem = item;
        newItem.slotNum.text = item.itemHeld.ToString();

       /* newItemUSE.slotImage.sprite = item.itemImage;
        newItemUSE.slotItem = item;
        newItemUSE.slotNum.text = item.itemHeld.ToString();*/
    }
    public static void CreateNewUSEItem(Item item)
    {
        useSlot newItemUSE = Instantiate(instance.USEslotPrefab, instance.USEGrid.transform.position, Quaternion.identity);
        newItemUSE.gameObject.transform.SetParent(instance.USEGrid.transform);
        newItemUSE.slotImage.sprite = item.itemImage;
        newItemUSE.slotItem = item;
        newItemUSE.slotNum.text = item.itemHeld.ToString();
    }
    public static void CreateNewWorkOneItem(Item item)
    {
        workOneSlot newItemworkOne = Instantiate(instance.workOneslotPrefab, instance.WorkOneGrid.transform.position, Quaternion.identity);
        newItemworkOne.gameObject.transform.SetParent(instance.WorkOneGrid.transform);
        newItemworkOne.slotImage.sprite = item.itemImage;
        newItemworkOne.slotItem = item;
        newItemworkOne.slotNum.text = item.itemHeld.ToString();
    }
    public static void CreateNewWorkTwoItem(Item item)
    {
        workOneSlot newItemworkOne = Instantiate(instance.workOneslotPrefab, instance.WorkTwoGrid.transform.position, Quaternion.identity);
        newItemworkOne.gameObject.transform.SetParent(instance.WorkTwoGrid.transform);
        newItemworkOne.slotImage.sprite = item.itemImage;
        newItemworkOne.slotItem = item;
        newItemworkOne.slotNum.text = item.itemHeld.ToString();
    }
    public static void CreateNewCraftingItem(Item item, Dictionary<string, Item> bagItems)
    {
        CraftingSlot newItem;
        if (bagItems == instance.WorkOneBagItems)
        {
             newItem = Instantiate(instance.CraftingslotPrefab, instance.CraftingGrid.transform.position, Quaternion.identity);
            newItem.gameObject.transform.SetParent(instance.CraftingGrid.transform);
        }
        else
        {
             newItem = Instantiate(instance.CraftingslotPrefab, instance.CraftingGrid2.transform.position, Quaternion.identity);
            newItem.gameObject.transform.SetParent(instance.CraftingGrid2.transform);
        }
      
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotItem = item;
        newItem.slotNum.text = item.itemHeld.ToString();

        newItem.gameObject.AddComponent<Button>().onClick.AddListener(() => {
            if (bagItems.ContainsKey(item.itemName))
            {
                bagItems[item.itemName].itemHeld += 1;
            }
            else
            {
                bagItems.Add(item.itemName, item);
            }
           instance.CraftingBag.itemList.Remove(item);
            RefreshCraftingItem(bagItems);
            BagManager.RefreshItem();
            BagManager.RefreshUSEItem();
           CraftingSystem craftingSystem= FindObjectOfType<CraftingSystem>();
            if (craftingSystem.isWorkOne)
            BagManager.RefreshWorkOneItemXY();
            else
            BagManager.RefreshWorkTwoItemXY();
           
        });
    }
    public static void CreateNewSaleItem(Item item)
    {
        SaleSlot newItem = Instantiate(instance.saleSlotPrefab, instance.saleGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.saleGrid.transform);
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotItem = item;
        newItem.slotNum.text = item.itemHeld.ToString();
    }
    public static void RefreshItem()
    {
        Debug.Log("refreshItem");
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < instance.Mybag.itemList.Count; i++)
        {
            CreateNewItem(instance.Mybag.itemList[i]);
        }
    }
    public static void RefreshUSEItem()
    {
        Debug.Log("refreshUse");
        for (int i = 0; i < instance.USEGrid.transform.childCount; i++)
        {
            if (instance.USEGrid.transform.childCount == 0)
                break;
            Destroy(instance.USEGrid.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < instance.USE_Bag.itemList.Count; i++)
        {
            CreateNewUSEItem(instance.USE_Bag.itemList[i]);
        }
    }
    public static void RefreshWorkOneItem()
    {
        //Debug.Log("refreshWorkOne");
        //for (int i = 0; i < instance.WorkOneGrid.transform.childCount; i++)
        //{
        //    if (instance.WorkOneGrid.transform.childCount == 0)
        //        break;
        //    Destroy(instance.WorkOneGrid.transform.GetChild(i).gameObject);
        //}
        //for (int i = 0; i < instance.WorkOneBag.itemList.Count; i++)
        //{
        //    CreateNewWorkOneItem(instance.WorkOneBag.itemList[i]);
        //}
    }
    public static void RefreshWorkOneItemXY()
    {
        for (int i = 0; i < instance.WorkOneGrid.transform.childCount; i++)
        {
            Destroy(instance.WorkOneGrid.transform.GetChild(i).gameObject);
        }
        foreach (Item item in instance.WorkOneBagItems.Values)
        {
            CreateNewWorkOneItem(item);
        }

    }
    public static void RefreshWorkTwoItemXY()
    {
        for (int i = 0; i < instance.WorkTwoGrid.transform.childCount; i++)
        {
            Destroy(instance.WorkTwoGrid.transform.GetChild(i).gameObject);
        }
        foreach (Item item in instance.WorkTwoBagItems.Values)
        {
            CreateNewWorkTwoItem(item);
        }
    }
    public static void RefreshCraftingItem(Dictionary<string, Item> bagItems)
    {
        if (bagItems == instance.WorkOneBagItems)
        {
            for (int i = 0; i < instance.CraftingGrid.transform.childCount; i++)
            {
                if (instance.CraftingGrid.transform.childCount == 0)
                    break;
                Destroy(instance.CraftingGrid.transform.GetChild(i).gameObject);
            }
        }
        else
        {
            for (int i = 0; i < instance.CraftingGrid2.transform.childCount; i++)
            {
                if (instance.CraftingGrid2.transform.childCount == 0)
                    break;
                Destroy(instance.CraftingGrid2.transform.GetChild(i).gameObject);
            }
        }
           
        for (int i = 0; i < instance.CraftingBag.itemList.Count; i++)
        {
            CreateNewCraftingItem(instance.CraftingBag.itemList[i], bagItems);
        }
    }
    public static void RefreshSaleItem()
    {
        Debug.Log("refreshaleitem");
        for (int i = 0; i < instance.saleGrid.transform.childCount; i++)
        {
            if (instance.saleGrid.transform.childCount == 0)
                break;
            Destroy(instance.saleGrid.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < instance.SaleBag.itemList.Count; i++)
        {
            CreateNewSaleItem(instance.SaleBag.itemList[i]);
        }
    }


}
