using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;//�����ĸ���Ʒ
    public bag Mybag;//�����ĸ�����
    public bag USE_Bag;
    public bag WorkOneBag;
    public bool playerInRange = false;//�����Ƿ���npc����ײ��Χ��
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
        if (Input.GetMouseButtonDown(1)) // �������Ҽ����
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int layerMask = 1 << LayerMask.NameToLayer("Default");
            
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, layerMask);

            Debug.Log("�����ֲ��" + hit.collider.gameObject.name);
            if (hit.collider != null && hit.collider ==gameObject.GetComponent<Collider2D>() && playerInRange == true)
            {
                Debug.Log("���ֲ�������");
                AddNewItem();
                Destroy(gameObject);
            }
           
        }
    }
    public void AddNewItem()
    {
        if (!Mybag.itemList.Contains(thisItem))
        {
            Mybag.itemList.Add(thisItem);//�����Ʒ��ӵ����������
            USE_Bag.itemList.Add(thisItem);//�����Ʒ��ӵ����������
            WorkOneBag.itemList.Add(thisItem);//�����Ʒ��ӵ����������
        }
        else
        {
            thisItem.itemHeld += 1;
        }
        BagManager.RefreshItem();
        BagManager.RefreshUSEItem();
        BagManager.RefreshWorkOneItem();
    }
}
