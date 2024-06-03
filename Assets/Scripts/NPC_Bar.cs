using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NPC_Bar : MonoBehaviour
{
    public bool playerInRange = false;//主角是否在npc的碰撞范围内
    //public Canvas NPCbar;

    public static int flag = 1;//判断与Npc是对话还是买东西
    public string ChatName;    //定义选择哪个对话block
    public string ChatNameEve;    //定义选择哪个对话block
    public string description;    //定义选择哪个对话block
    public string afteropen;    //定义选择哪个对话block

    private Flowchart flowchart;
    private Flowchart flowchart2;
    public static int Diaing = 1;//判断是否对话结束
    public static int flag2 = 1;//判断是否是介绍的第一次，退出交易界面，弹出对话
    public Image black;//黑幕
    float fadeOutTime=2f;

    public GameObject Canvas;
    void Start()
    {
        Canvas = GameObject.FindGameObjectWithTag("Canvas");
        //PlayerPrefs.SetInt("intbar", 1);//跟酒店老板娘的对话
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

      //对话逻辑

        if (flowchart.HasExecutingBlocks() == true)
        {
            Debug.Log("正在进行对话ing");
        }
        if (flowchart.HasExecutingBlocks() == false && Diaing == 2)
        {
            Debug.Log("已经结束对话了");
            black.enabled = true;
            StartCoroutine(Black());
        }
        if (flowchart2.HasExecutingBlocks() == false && Diaing == 4)
        {
            Debug.Log("已经结束对话了");
            black.enabled = true;
            StartCoroutine(BlackAgain());
            Diaing = 5;
        }
        if (Diaing == 3)
        {
            SayEve();
        }
        int intbar = PlayerPrefs.GetInt("intbar");
        if (Input.GetMouseButtonDown(1)&&flag==1&&intbar==1) // 1代表鼠标右键
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
                flag = 2;
            }
        }
        else if (Input.GetMouseButtonDown(1)&&flag==2) // 1代表鼠标右键
        {
            Debug.Log("1");
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int layerMask = 1 << LayerMask.NameToLayer("Default");

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, layerMask);
            if (hit.collider != null && hit.collider ==gameObject.GetComponent<Collider2D>() && playerInRange == true)
            {
                Canvas.SetActive(false);
                GameObject.FindGameObjectWithTag("player").GetComponent<playerWalk>().enabled = false;
                //NPCbar.enabled = true;
                foreach (GameObject obj in otherScene.GetRootGameObjects())
                {
                    // 找到你要激活的GameObject
                    if (obj.CompareTag("NPCBar"))
                    {
                        // 激活GameObject
                        obj.SetActive(true);
                        break;
                    }
                }
                SayDescription();
                flag = 3;
            }
            
        }
        else if (Input.GetMouseButtonDown(1) && flag == 3) // 1代表鼠标右键
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
                    // 找到你要激活的GameObject
                    if (obj.CompareTag("NPCBar"))
                    {
                        // 激活GameObject
                        obj.SetActive(true);
                        break;
                    }
                }
            }
        }
        if (flag2 == 2)
        {
            SayAfterOpen();
            flag2 = 3;//对话结束了
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
        Diaing = 3;//第二次对话开始  
    }
    //这个黑屏就是跳转到下一个场景了
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
        SceneManager.LoadScene("bar");
        SceneManager.LoadScene("Player", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnSceneLoadedhome;

    }
    private void OnSceneLoadedhome(Scene scene, LoadSceneMode mode)
    {
        PlayerPrefs.SetInt("intKey", 1);//可以开始计时了
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
              Diaing = 4;//第二段对话结束
          }
      }
}
