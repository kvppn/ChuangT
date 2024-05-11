using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;
public class GeminiDia : MonoBehaviour
{
    public string ChatName;    //����ѡ���ĸ��Ի�block
    public string ChatNameAgain;    //����ѡ���ĸ��Ի�block
    //��ǰ�Ƿ���ԶԻ�
    public bool playerInRange = false;//�����Ƿ���npc����ײ��Χ��

    private Flowchart flowchart;

    public static int flag = 1;//�ж϶Ի��Ƿ����

    int intGemi;
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
    private void Start()
    {
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        intGemi = PlayerPrefs.GetInt("intGemi");
        if (intGemi == 2)
        {
            flag = 4; // �����κα�ʾ�Ի���Ӧ�ٴδ�����ֵ
        }
        else
        {
            flag = 1; // ȷ���Ի����Դ���
        }
    }
    void Update()
    {
       
        if (flowchart.HasExecutingBlocks()==true)
        {
            Debug.Log("���ڽ��жԻ�ing");
        }
        else if(flowchart.HasExecutingBlocks() == false&&flag==3)
        {
            Debug.Log("�Ѿ������Ի���");
            flag = 4;
            PlayerPrefs.SetInt("intGrowDia", 1);
            SceneManager.LoadScene("Grow");
              SceneManager.LoadScene("Player", LoadSceneMode.Additive);
              SceneManager.sceneLoaded += OnSceneLoaded;
        }
        if (Input.GetMouseButtonDown(1)) // 1��������Ҽ�
        {
            Debug.Log("1");
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            int layerMask = 1 << LayerMask.NameToLayer("Default");

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, layerMask);
            if (hit.collider != null && hit.collider == GetComponent<Collider2D>() && playerInRange == true&&flag==1&&intGemi==1)
            {
                PlayerPrefs.SetInt("intGemi", 2);
                //�˴���flag=1��ʾ��һ�ζԻ�
                Debug.Log("3");
                Say();
            }
            else if (flowchart.HasExecutingBlocks() == false && flag == 2&&hit.collider != null && hit.collider == GetComponent<Collider2D>() && playerInRange == true)
            {
                SayAgain();
            }
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            Debug.Log("0000022");
            GameObject player = GameObject.FindGameObjectWithTag("player");
            player.transform.position = new Vector3(-0.5f, -4.5f, 0);

            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
    public void Say()
    {
        if (flowchart.HasBlock(ChatName))
        {
            flowchart.ExecuteBlock(ChatName);
            flag = 2;
        }
    }
    public void SayAgain()
    {
        if (flowchart.HasBlock(ChatNameAgain))
        {
            flowchart.ExecuteBlock(ChatNameAgain);
            flag = 3;
        }
    }
}
