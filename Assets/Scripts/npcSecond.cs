using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class npcSecond : MonoBehaviour
{
    public string ChatName;    //����ѡ���ĸ��Ի�block
    //��ǰ�Ƿ���ԶԻ�

    public bool playerInRange = false;//�����Ƿ���npc����ײ��Χ��

    public float speed = 3f;

   
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // 1��������Ҽ�
        {
            Debug.Log("1");
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider == GetComponent<Collider2D>() && playerInRange == true)
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
   
   
    /*IEnumerator MyCoroutine()
    {
        Debug.Log("Coroutine started");
        yield return new WaitForSeconds(1); // �ȴ�2��
        gameObject.transform.Translate(Vector2.left * speed * Time.deltaTime);
        yield return new WaitForSeconds(4); // �ȴ�2��
        Debug.Log("Coroutine finished");
    }*/
}
