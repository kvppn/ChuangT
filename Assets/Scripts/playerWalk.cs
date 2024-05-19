using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerWalk : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Animator animator;
    int a = 1, b = 1, c = 1, d = 1;
    public GameObject[] KuangText;
    int Kuang = 0;//按下的数字对应哪个框
    public bag Bag;
    public bag USE_Bag;//按下1-9按钮，对应的物品
    public bag WorkOne_Bag;
    public Item item;
    public GameObject equip;
    public Blood bloody;
    void Start()
    {
        animator = GetComponent<Animator>();
        bloody = GameObject.FindGameObjectWithTag("bloody").GetComponent<Blood>();
    }  

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        if (verticalInput < 0&&a==1)
        {
            animator.SetTrigger("isZheng");
            a = 2;
        }
        if (verticalInput == 0 && a == 2)
        {
            animator.SetTrigger("idleZheng");
            a = 1;
        }
        if (verticalInput > 0&&b==1)
        {
            animator.SetTrigger("isHou");
            b = 2;
        }
        if (verticalInput == 0 && b == 2)
        {
            animator.SetTrigger("idleHou");
            b = 1;
        }
        if (horizontalInput < 0&&c==1)
        {
            animator.SetTrigger("isLeft");
            c = 2;
        }
        if (horizontalInput == 0 && c == 2)
        {
            animator.SetTrigger("idleLeft");
            c = 1;
        }
        if (horizontalInput > 0&& d==1)
        {
            animator.SetTrigger("isRight");
            d = 2;
        }
        if (horizontalInput == 0 && d == 2)
        {
            animator.SetTrigger("idleRight");
            d = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateGameObjectAtIndex(0);
            Kuang = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivateGameObjectAtIndex(1);
            Kuang = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActivateGameObjectAtIndex(2);
            Kuang = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ActivateGameObjectAtIndex(3);
            Kuang = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ActivateGameObjectAtIndex(4);
            Kuang = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            ActivateGameObjectAtIndex(5);
            Kuang = 5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            ActivateGameObjectAtIndex(6);
            Kuang = 6;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            ActivateGameObjectAtIndex(7);
            Kuang = 7;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            ActivateGameObjectAtIndex(8);
            Kuang = 8;
        }
        if (USE_Bag.itemList[Kuang] != null) {
            item = USE_Bag.itemList[Kuang];
            if (item.equip == true)
            {
                animator.SetTrigger("juqi");
                equip.GetComponent<SpriteRenderer>().sprite= item.itemImage;

                if (Input.GetMouseButtonDown(1))
                {
                    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    int layerMask = 1 << LayerMask.NameToLayer("player");
                    RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, layerMask);
                    Debug.Log(hit.collider.name);
                    if (hit.collider != null && hit.collider == gameObject.GetComponent<Collider2D>())
                    {
                        animator.SetTrigger("bujuqi");
                        DescreaseTheItem(item);
                        bloody.increseBlood(5);
                    }
                }
            }
            else if (item.equip == false)
            {
                animator.SetTrigger("bujuqi");
                equip.GetComponent<SpriteRenderer>().sprite = null;
            }
        }
    }
    public void DescreaseTheItem(Item thisItem)
    {

        thisItem.itemHeld -= 1;
        if (thisItem.itemHeld <= 0)
        {
            //等于0的时候销毁
            Bag.itemList.Remove(thisItem);
            USE_Bag.itemList.Remove(thisItem);
            WorkOne_Bag.itemList.Remove(thisItem);
        }
        BagManager.RefreshItem();
        BagManager.RefreshUSEItem();
        BagManager.RefreshWorkOneItemXY();

    }
    void ActivateGameObjectAtIndex(int index)
    {
        for (int i = 0; i < KuangText.Length; i++)
        {
            if (i == index)
            {
                KuangText[i].GetComponent<Image>().enabled = true; // 激活目标GameObject
            }
            else
            {
                KuangText[i].GetComponent<Image>().enabled = false;  // 关闭其他GameObject
            }
        }
    }
}
