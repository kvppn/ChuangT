using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class workOneSlot : MonoBehaviour, IPointerClickHandler
{
    
    public Item slotItem;//格子中的物品
    public Image slotImage;//格子的图片
    public Text slotNum;//格子物品的数量
                        //public CraftingSystem craftingSystem;
    public CraftingSystem craftingSystem;
    public bool isClick = true;
    public void Update()
    {
        craftingSystem = FindObjectOfType<CraftingSystem>();
       
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        // 点击左键
        if (eventData.button == PointerEventData.InputButton.Left && craftingSystem.CraftingExit.transform.childCount==0)
        {
            // 调用 CraftingSystem 的 DescreaseItem 方法并传入对应的物品
            craftingSystem.DescreaseItem(slotItem);
        }
    }
}
