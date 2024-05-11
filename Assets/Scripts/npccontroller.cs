using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class npccontroller : MonoBehaviour
{
    public string ChatName;    //定义选择哪个对话block
    //当前是否可以对话

    public bool playerInRange = false;//主角是否在npc的碰撞范围内

    public float speed = 5.0f;
    public WenJianController WenJian;

    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            playerInRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            playerInRange = false;
        }
    }
    void Update()
    {
        if (WenJian.playerIswalking == true)
        {
            StartCoroutine(MyCoroutine());
           
        }
        if (Input.GetMouseButtonDown(1)) // 1代表鼠标右键
        {
            Debug.Log("1");
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            
            if (hit.collider != null&& hit.collider == GetComponent<Collider2D>()&&playerInRange ==true)
                {
                    Debug.Log("3");
                Say();
            }
            }
        }
   public void Say()
    {
        Debug.Log("aaaa");
        Flowchart flowChart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        if (flowChart.HasBlock(ChatName))
        {
            flowChart.ExecuteBlock(ChatName);
        }
    }
    IEnumerator MyCoroutine()
    {
        Debug.Log("Coroutine started");
        yield return new WaitForSeconds(1); // 等待2秒
        gameObject.transform.Translate(Vector2.left * speed * Time.deltaTime);
        yield return new WaitForSeconds(2); // 等待2秒
        WenJian.playerIswalking = false;
        Debug.Log("Coroutine finished");
    }
}


