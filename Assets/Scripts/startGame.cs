using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class startGame : MonoBehaviour
{
    public string firstLevelSceneName;
    public string playerSceneName;
    private Text moneyText;
    private Text bloodText;
    public int money;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void OnClick()
    {
        SceneManager.LoadScene(firstLevelSceneName);
        SceneManager.LoadScene(playerSceneName, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnSceneLoaded;
        //��Ϸ��ʼ��������Ϸ��ʼ��ֵ
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("00000");
        if (scene.buildIndex == 0)
        {
            Debug.Log("000002333");
            bloodText= GameObject.FindGameObjectWithTag("blood").GetComponent<Text>();
            PlayerPrefs.SetInt("BloodY", 100); // ����PlayerPrefs�еĳ�ʼֵ
            bloodText.text = PlayerPrefs.GetInt("BloodY", 0).ToString();//��ʼ����

            GameObject moneyObject = GameObject.FindGameObjectWithTag("money");
            if (moneyObject != null)
            {
                moneyText = moneyObject.GetComponent<Text>();
                if (moneyText != null)
                {
                    PlayerPrefs.SetInt("moneY", 1000); // ����PlayerPrefs�е�ֵ
                    money = PlayerPrefs.GetInt("moneY", 0);
                    moneyText.text = money.ToString();
                    Debug.Log("�ҵ���");
                }
                else
                {
                    Debug.LogError("�ҵ��˴��� 'money' ��ǩ����Ϸ���󣬵�û���ҵ� Text ���");
                }
            }
            else
            {
                Debug.LogError("û���ҵ����� 'money' ��ǩ����Ϸ����");
            }
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

}
