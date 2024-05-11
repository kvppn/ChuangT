using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//初始数据的一些控制
public class firstController : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        //游戏初始的值
        PlayerPrefs.SetInt("intGemi", 1);//双胞胎的对话
        PlayerPrefs.SetInt("intbar", 1);//跟酒店老板娘的对话
        PlayerPrefs.SetInt("ChestOpened_1", 0);//表示宝箱已经被打开
        PlayerPrefs.SetInt("intKey", 0);//这是开始计时时间的触发，初始为0
        PlayerPrefs.SetInt("intFlag", 3);
        for (int i = 0; i<=40;i++) {
            PlayerPrefs.SetInt("DataInitialized" + "tile_"+i.ToString(), 0);//判断耕地是否初始
            
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
