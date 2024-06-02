using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;
public class DiawithMiluo_Grow : MonoBehaviour
{
    public string ChatName;    //定义选择哪个对话block
    //当前是否可以对话
    private Flowchart flowchart;
    public GameObject Canvas;

    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        int intGrowDia = PlayerPrefs.GetInt("intGrowDia");
        if (intGrowDia == 1)
        {
            PlayerPrefs.SetInt("intGrowDia", 2);//之后进入就不会说话了
            StartCoroutine(firstDia());
            intGrowDia = 2;
        }
       
    }
    IEnumerator firstDia()
    {
        yield return new WaitForSeconds(1.5f);
        if (flowchart.HasBlock(ChatName))
        {
            flowchart.ExecuteBlock(ChatName);
        }
       /* if (flowchart.HasExecutingBlocks() == false)
        {
            Canvas.SetActive(true);
        }*/
    }
}
