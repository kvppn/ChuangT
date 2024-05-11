using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIcontroller : MonoBehaviour
{
    public GameObject Bag;
    public GameObject Map;
    public GameObject Menu;
    public GameObject Task;
    public int flagB = 1;//判断是否第一次点击
    public int flagM = 1;//判断是否第一次点击
    public int flagMENU = 1;//判断是否第一次点击
    public int flagT = 1;//判断是否第一次点击
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        Bag.SetActive(false);
        Map.SetActive(false);
        Menu.SetActive(false);
        Task.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (flagB == 1)
            {
                // 在这里编写按下E键后的响应代码
                Debug.Log("按下了E键");
                Bag.SetActive(true);
                flagB = 2;
            }
            else if (flagB == 2)
            {
                Bag.SetActive(false);
                flagB = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (flagT == 1)
            {
                Task.SetActive(true);
                flagT = 2;
            }
            else if (flagT == 2)
            {
                Task.SetActive(false);
                flagT = 1;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (flagM == 1)
            {
                Map.SetActive(true);
                flagM = 2;
            }
            else if (flagM == 2)
            {
                Map.SetActive(false);
                flagM = 1;
            }
           
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (flagMENU == 1)
            {
                Menu.SetActive(true);
                flagMENU = 2;
            }
            else if (flagMENU == 2)
            {
                Menu.SetActive(false);
                flagMENU = 1;
            }
        }
    }
}
