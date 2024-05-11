using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOpen : MonoBehaviour
{
    public GameObject TimeCon;
    public GameObject select;
    // Start is called before the first frame update
    void Start()
    {
        //ActivateTimeCon();
    }

    // Update is called once per frame
    void Update()
    {
        int intVal = PlayerPrefs.GetInt("intKey");
        if (intVal == 1)
        {
            select.SetActive(true);
            TimeCon.SetActive(true);
            //ActivateTimeCon();
        }
    }
    void ActivateTimeCon()
    {
        if (PlayerPrefs.GetInt("TimeConActive", 0) == 1)
        {
            TimeCon.SetActive(true);
        }
    }
    // 在离开场景时保存TimeCon的激活状态
    /*private void OnDestroy()
    {
        if (TimeCon.activeSelf)
        {
            PlayerPrefs.SetInt("TimeConActive", 1);
        }
        else
        {
            PlayerPrefs.SetInt("TimeConActive", 0);
        }
    }*/
}
