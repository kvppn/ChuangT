using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Item",menuName ="Bag/New Item")]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        None,
        FabricMaterial,//作物-布材料
       ThreadMaterial,//作物-线材料
        DyeMaterial,//作物-染料材料
        Fabric,//布
        Thread,//线
        Dye,//染料
        Decorate,//装饰
        Cloth//衣服
    }
    public enum ItemSpeciality
    {
        None,
        Dexterity,//灵巧
        Shine,//发光
        Ice,//冰
        Fire,//火焰
    }
    public enum ItemColor
    {
        None,
        Red,
        Bule,
        Yellow,
        Black,
        Colors
    }
    public string itemName;//物品名字
    public ItemType itemType;//物品类型
    public GameObject prefab;//种子的预制体
    public GameObject growing;//半成长的预制体
    public GameObject growed;//成熟的预制体
    public Sprite itemImage;//图片
    public int itemHeld;//物品的数量
    [TextArea]
    public string itemInfo;//一些信息，后续再写
    public int money;
    public bool equip;//是否可以装备
    public bool grow;//是否可以装备


    public int quality;//品质
    public ItemSpeciality itemSpeciality;//物品特性
    public int specialityCount;//特性数值
    public ItemColor itemColor;//物品颜色
    public int fashion;//时尚数值
}