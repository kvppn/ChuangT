using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ʼ���ݵ�һЩ����
public class firstController : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        //��Ϸ��ʼ��ֵ
        PlayerPrefs.SetInt("intGemi", 1);//˫��̥�ĶԻ�
        PlayerPrefs.SetInt("intbar", 1);//���Ƶ��ϰ���ĶԻ�
        PlayerPrefs.SetInt("ChestOpened_1", 0);//��ʾ�����Ѿ�����
        PlayerPrefs.SetInt("intKey", 0);//���ǿ�ʼ��ʱʱ��Ĵ�������ʼΪ0
        PlayerPrefs.SetInt("intFlag", 3);
        for (int i = 0; i<=40;i++) {
            PlayerPrefs.SetInt("DataInitialized" + "tile_"+i.ToString(), 0);//�жϸ����Ƿ��ʼ
            PlayerPrefs.SetInt("StartTime" + "tile_" + i.ToString(), 0);//���濪ʼ������
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
