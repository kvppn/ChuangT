using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;//属于哪个物品
    public bag Mybag;//属于哪个背包
    public bag USE_Bag;
    public bag WorkOneBag;
    //public bag SaleBag;
    public bool playerInRange = false;//主角是否在npc的碰撞范围内
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            playerInRange = true;
           
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) // 检测鼠标右键点击
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int layerMask = 1 << LayerMask.NameToLayer("Default");
            
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, layerMask);

            Debug.Log("点击了植物" + hit.collider.gameObject.name);
            if (hit.collider != null && hit.collider ==gameObject.GetComponent<Collider2D>() && playerInRange == true)
            {
                Debug.Log("添加植物进背包");
                AddNewItem();
                Destroy(gameObject);
            }
           
        }
    }
    public void AddNewItem()
    {
        if (!Mybag.itemList.Contains(thisItem))
        {
            Mybag.itemList.Add(thisItem);//这个物品添加到这个包里面
            USE_Bag.itemList.Add(thisItem);//这个物品添加到这个包里面
            WorkOneBag.itemList.Add(thisItem);//这个物品添加到这个包里面
            //SaleBag.itemList.Add(thisItem);
            //BagManager.CreateNewItem(thisItem);
        }
        else
        {
            thisItem.itemHeld += 1;
        }
        BagManager.RefreshItem();
        BagManager.RefreshUSEItem();
        BagManager.RefreshWorkOneItem();
        //BagManager.RefreshSaleItem();
    }
}
