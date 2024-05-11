using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;
public class DiawithMiluo_Grow : MonoBehaviour
{
    public string ChatName;    //����ѡ���ĸ��Ի�block
    //��ǰ�Ƿ���ԶԻ�
    private Flowchart flowchart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        int intGrowDia = PlayerPrefs.GetInt("intGrowDia");
        if (intGrowDia == 1)
        {
            PlayerPrefs.SetInt("intGrowDia", 2);
            say();
            intGrowDia = 2;
        }
    }
    public void say()
    {
            if (flowchart.HasBlock(ChatName))
            {
                flowchart.ExecuteBlock(ChatName);
            }
    }
}
