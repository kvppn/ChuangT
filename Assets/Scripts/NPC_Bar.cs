using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NPC_Bar : MonoBehaviour
{
    public bool playerInRange = false;//�����Ƿ���npc����ײ��Χ��

    public static int flag = 1;//�ж���Npc�ǶԻ���������
    public string ChatName;    //����ѡ���ĸ��Ի�block
    private Flowchart flowchart;

    public static int Diaing = 1;//�ж��Ƿ�Ի�����
    public static int flag2 = 1;//�ж��Ƿ��ǽ��ܵĵ�һ�Σ��˳����׽��棬�����Ի�

    public GameObject Canvas;
    void Start()
    {
        Canvas = GameObject.FindGameObjectWithTag("Canvas");
        //PlayerPrefs.SetInt("intbar", 1);//���Ƶ��ϰ���ĶԻ�
    }
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
        Scene otherScene = SceneManager.GetSceneByName("Player");
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
     
        GameObject blackObject = GameObject.FindGameObjectWithTag("black");
      
      //�Ի��߼�

        if (flowchart.HasExecutingBlocks() == true)
        {
            Debug.Log("���ڽ��жԻ�ing");
        }
        if (flowchart.HasExecutingBlocks() == false && flag==2)
        {
            flag = 3;
            SceneManager.LoadScene("bar");
            SceneManager.LoadScene("Player", LoadSceneMode.Additive);
            SceneManager.sceneLoaded += OnSceneLoadedhome;
        }
        int intbar = PlayerPrefs.GetInt("intbar");
        if (Input.GetMouseButtonDown(1)&&flag==1&&intbar==1) // 1��������Ҽ�
        {
            PlayerPrefs.SetInt("intbar", 2);
            Debug.Log("1");
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int layerMask = 1 << LayerMask.NameToLayer("Default");

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, layerMask);
            if (hit.collider != null && hit.collider == gameObject.GetComponent<Collider2D>() && playerInRange == true)
            {
                Canvas.SetActive(false);
                GameObject.FindGameObjectWithTag("player").GetComponent<playerWalk>().enabled = false;
                Say();
                flag = 2;//��һ�εĶԻ�����
            }
        }
        else if (Input.GetMouseButtonDown(1) && flag == 3) // 1��������Ҽ�
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int layerMask = 1 << LayerMask.NameToLayer("Default");

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, layerMask);
           
           if (hit.collider != null && hit.collider == gameObject.GetComponent<Collider2D>() && playerInRange == true)
            {
                Canvas.SetActive(false);
                GameObject.FindGameObjectWithTag("player").GetComponent<playerWalk>().enabled = false;
                foreach (GameObject obj in otherScene.GetRootGameObjects())
                {
                    // �ҵ���Ҫ�����GameObject
                    if (obj.CompareTag("NPCBar"))
                    {
                        // ����GameObject
                        obj.SetActive(true);
                        break;
                    }
                }
            }
        }
    }
    //�������������ת����һ��������
  /*  IEnumerator BlackAgain()
    {
      *//*  for (float t = 0.0f; t < fadeOutTime; t += Time.deltaTime)
        {
            Color color = black.color;
            color.a = Mathf.Lerp(0.0f, 1.0f, t / fadeOutTime);
            black.color = color;
            yield return null;
        }*//*
        yield return new WaitForSeconds(1f);
    }*/
    private void OnSceneLoadedhome(Scene scene, LoadSceneMode mode)
    {
        PlayerPrefs.SetInt("intKey", 1);//���Կ�ʼ��ʱ��
        if (scene.buildIndex == 1)
        {
            GameObject player = GameObject.FindGameObjectWithTag("player");
            player.transform.position = new Vector3(-2f, -0.95f, 0);

            SceneManager.sceneLoaded -= OnSceneLoadedhome;
        }
    }
    public void Say()
    {
        if (flowchart.HasBlock(ChatName))
        {
            flowchart.ExecuteBlock(ChatName);
        }
    }
}
