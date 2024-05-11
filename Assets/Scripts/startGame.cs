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
        //游戏开始，设置游戏初始的值
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("00000");
        if (scene.buildIndex == 0)
        {
            Debug.Log("000002333");
            bloodText= GameObject.FindGameObjectWithTag("blood").GetComponent<Text>();
            PlayerPrefs.SetInt("BloodY", 100); // 设置PlayerPrefs中的初始值
            bloodText.text = PlayerPrefs.GetInt("BloodY", 0).ToString();//初始精力

            GameObject moneyObject = GameObject.FindGameObjectWithTag("money");
            if (moneyObject != null)
            {
                moneyText = moneyObject.GetComponent<Text>();
                if (moneyText != null)
                {
                    PlayerPrefs.SetInt("moneY", 1000); // 更新PlayerPrefs中的值
                    money = PlayerPrefs.GetInt("moneY", 0);
                    moneyText.text = money.ToString();
                    Debug.Log("找到了");
                }
                else
                {
                    Debug.LogError("找到了带有 'money' 标签的游戏对象，但没有找到 Text 组件");
                }
            }
            else
            {
                Debug.LogError("没有找到带有 'money' 标签的游戏对象");
            }
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

}
