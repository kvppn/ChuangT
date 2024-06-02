using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;
public class ChestController : MonoBehaviour
{
    public bool playerInRange = false;//�����Ƿ���npc����ײ��Χ��

    public Item thisItem;//�����ĸ���Ʒ
    public bag Mybag;//�����ĸ�����
    public bag USE_Bag;
    public bag WorkOneBag;
    public static int flag = 1;//�ж��Ƿ���������
   public static int lastDia = 1;//�ж��Ƿ������ĶԻ�

    public string ChatName;    //����ѡ���ĸ��Ի�block
    public string ChatNameBye;    //����ѡ���ĸ��Ի�block

    private Flowchart flowchart;

    public GameObject Canvas;
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
     void Start()
    {
        Canvas = GameObject.FindGameObjectWithTag("Canvas");
        if (PlayerPrefs.GetInt("ChestOpened_1", 0) == 1)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            //GetComponent<CircleCollider2D>().enabled = false;
        }
        if(PlayerPrefs.GetInt("intGrowFirstDia", 0) == 1)
        {
            Debug.Log("intGrowFirstDia");

            StartCoroutine(hhhh());
            
        }
    }
   IEnumerator hhhh()
    {
        yield return new WaitForSeconds(0.5f);
        Canvas.SetActive(false);
        PlayerPrefs.SetInt("intGrowFirstDia", 2);
    }
    void Update()
    {

        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();


        int intFlag = PlayerPrefs.GetInt("intFlag");
       
        if (flowchart.HasExecutingBlocks() == false && flag == 2)
        {
            //Canvas.SetActive(true);
            flag = 3;
        }
        if (intFlag == 1)
        {
            PlayerPrefs.SetInt("intFlag", 2);//���ؽ̳̽���
            sayLast();//�������˵��Ҫ������������ĶԻ�
            intFlag = 2;
        }

        if (flowchart.HasExecutingBlocks() == false&&lastDia==2)
        {
            lastDia = 3;
            SceneManager.LoadScene("Bar");
            SceneManager.LoadScene("Player", LoadSceneMode.Additive);
            SceneManager.sceneLoaded += OnSceneLoadedbar;
        }

        if (Input.GetMouseButtonDown(1)) // 1��������Ҽ�
        {
            Debug.Log("1");
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int layerMask = 1 << LayerMask.NameToLayer("Default");

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, layerMask);

            if (hit.collider != null && hit.collider == GetComponent<Collider2D>() && playerInRange == true&&flag==1)
            {
                Debug.Log("Canvasզ������");
                Canvas.SetActive(true);
                Debug.Log("3");
                PlayerPrefs.SetInt("ChestOpened_1" , 1);//��ʾ�����Ѿ�����
                gameObject.GetComponent<SpriteRenderer>().enabled=false;
                //gameObject.GetComponent<CircleCollider2D>().enabled = false;
                if (!Mybag.itemList.Contains(thisItem))
                {
                    Debug.Log("233333");
                    Mybag.itemList.Add(thisItem);//�����Ʒ��ӵ����������
                    USE_Bag.itemList.Add(thisItem);//�����Ʒ��ӵ����������
                    WorkOneBag.itemList.Add(thisItem);//�����Ʒ��ӵ����������
                    //BagManager.CreateNewItem(thisItem);

                }
                BagManager.RefreshItem();
                BagManager.RefreshUSEItem();
                BagManager.RefreshWorkOneItem();

                StartCoroutine(ToCoroutine());
                flag = 2;
            }
        }
    }
    IEnumerator ToCoroutine()
    {
        // �ȴ�����
        yield return new WaitForSeconds(2f);

        if (flowchart.HasBlock(ChatName))
            {
                flowchart.ExecuteBlock(ChatName);
            }

    }
    public void sayLast()
    {
        StartCoroutine(ToBarCoroutine());
    }
    IEnumerator ToBarCoroutine()
    {
        
        yield return new WaitForSeconds(2f);
        //Canvas.SetActive(false);
        if (flowchart.HasBlock(ChatNameBye))
        {
            flowchart.ExecuteBlock(ChatNameBye);
        }
        // �ȴ�����
        yield return new WaitForSeconds(2f);
        lastDia = 2;
    }
    private void OnSceneLoadedbar(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            Debug.Log("0000022");
            GameObject player = GameObject.FindGameObjectWithTag("player");
            player.transform.position = new Vector3(-4.31f, -4.96f, 0);

            SceneManager.sceneLoaded -= OnSceneLoadedbar;
        }
    }
}
