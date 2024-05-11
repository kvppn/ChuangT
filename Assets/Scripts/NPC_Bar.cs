using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NPC_Bar : MonoBehaviour
{
    public bool playerInRange = false;//�����Ƿ���npc����ײ��Χ��
    //public Canvas NPCbar;

    public static int flag = 1;//�ж���Npc�ǶԻ���������
    public string ChatName;    //����ѡ���ĸ��Ի�block
    public string ChatNameEve;    //����ѡ���ĸ��Ի�block
    public string description;    //����ѡ���ĸ��Ի�block
    public string afteropen;    //����ѡ���ĸ��Ի�block

    private Flowchart flowchart;
    private Flowchart flowchart2;
    public static int Diaing = 1;//�ж��Ƿ�Ի�����
    public static int flag2 = 1;//�ж��Ƿ��ǽ��ܵĵ�һ�Σ��˳����׽��棬�����Ի�
    public Image black;//��Ļ
    float fadeOutTime=2f;
   
    void Start()
    {
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
        flowchart2 = GameObject.Find("Flowchart2").GetComponent<Flowchart>();
     
        GameObject blackObject = GameObject.FindGameObjectWithTag("black");
        if (blackObject != null)
        {
            black = blackObject.GetComponent<Image>();
        }

      //�Ի��߼�

        if (flowchart.HasExecutingBlocks() == true)
        {
            Debug.Log("���ڽ��жԻ�ing");
        }
        if (flowchart.HasExecutingBlocks() == false && Diaing == 2)
        {
            Debug.Log("�Ѿ������Ի���");
            black.enabled = true;
            StartCoroutine(Black());
        }
        if (flowchart2.HasExecutingBlocks() == false && Diaing == 4)
        {
            Debug.Log("�Ѿ������Ի���");
            black.enabled = true;
            StartCoroutine(BlackAgain());
            Diaing = 5;
        }
        if (Diaing == 3)
        {
            SayEve();
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
                Say();
                flag = 2;
            }
        }
        else if (Input.GetMouseButtonDown(1)&&flag==2) // 1��������Ҽ�
        {
            Debug.Log("1");
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int layerMask = 1 << LayerMask.NameToLayer("Default");

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, layerMask);
            if (hit.collider != null && hit.collider ==gameObject.GetComponent<Collider2D>() && playerInRange == true)
            {
                //NPCbar.enabled = true;
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
                SayDescription();
                flag = 3;
            }
            
        }
        else if (Input.GetMouseButtonDown(1) && flag == 3) // 1��������Ҽ�
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int layerMask = 1 << LayerMask.NameToLayer("Default");

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, layerMask);
           
           if (hit.collider != null && hit.collider == gameObject.GetComponent<Collider2D>() && playerInRange == true)
            {
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
        if (flag2 == 2)
        {
            SayAfterOpen();
            flag2 = 3;//�Ի�������
        }
    }
    IEnumerator Black()
    {
        for (float t = 0.0f; t < fadeOutTime; t += Time.deltaTime)
        {
            Color color = black.color;
            color.a = Mathf.Lerp(0.0f, 1.0f, t / fadeOutTime);
            black.color = color;
            yield return null;
        }
        for (float t = 0.0f; t < fadeOutTime; t += Time.deltaTime)
        {
            Color color = black.color;
            color.a = Mathf.Lerp(1.0f, 0.0f, t / fadeOutTime);
            black.color = color;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        Diaing = 3;//�ڶ��ζԻ���ʼ  
    }
    //�������������ת����һ��������
    IEnumerator BlackAgain()
    {
        for (float t = 0.0f; t < fadeOutTime; t += Time.deltaTime)
        {
            Color color = black.color;
            color.a = Mathf.Lerp(0.0f, 1.0f, t / fadeOutTime);
            black.color = color;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("store");
        SceneManager.LoadScene("Player", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnSceneLoadedhome;

    }
    private void OnSceneLoadedhome(Scene scene, LoadSceneMode mode)
    {
        PlayerPrefs.SetInt("intKey", 1);//���Կ�ʼ��ʱ��
        if (scene.buildIndex == 0)
        {
            GameObject player = GameObject.FindGameObjectWithTag("player");
            player.transform.position = new Vector3(-1.04f, 0.07f, 0);

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
      public void SayDescription()
      {
          if (flowchart.HasBlock(description))
          {
              flowchart.ExecuteBlock(description);
          }
      }
      public void SayAfterOpen()
      {
          if (flowchart.HasBlock(afteropen))
          {
              flowchart.ExecuteBlock(afteropen);
              Diaing = 2;
          }
      }
      public void SayEve()
      {
          if (flowchart2.HasBlock(ChatNameEve))
          {
              flowchart2.ExecuteBlock(ChatNameEve);
              Diaing = 4;//�ڶ��ζԻ�����
          }
      }
}
