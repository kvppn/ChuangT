using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TImeController : MonoBehaviour
{

    public static float gameTime = 0f; // 游戏时间，单位：小时
    public static int day= 1; // 天数
    public Text dayText;
    public string sceneToCheck = "Bar";
    public int flag = 0;
    public Blood blloody;
 
    private void Update()
    {

        gameTime += Time.deltaTime; // 真实时间流逝
        dayText.text = day.ToString();
        if (gameTime >= 70f) // 一天20小时
        {
            blloody.sleepBlood();
            gameTime = 0f;
                SceneManager.LoadScene("bar");
                SceneManager.LoadScene("Player", LoadSceneMode.Additive);
                SceneManager.sceneLoaded += OnSceneLoadedhome;

            day++;
        }
    }
    public void GoToSleep()
    {
        blloody.sleepBlood();
        gameTime = 0;
        dayText.text = day.ToString();
        SceneManager.LoadScene("bar");
        SceneManager.LoadScene("Player", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnSceneLoadedhome;
        day++;
    }
    bool IsSceneLoaded(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name == sceneName)
            {
                return true;
            }
        }
        return false;
    }
    private void OnSceneLoadedhome(Scene scene, LoadSceneMode mode)
    { 
        if (scene.buildIndex == 1)
        {
            GameObject player = GameObject.FindGameObjectWithTag("player");
            player.transform.position = new Vector3(-2f, -0.95f, 0);

            SceneManager.sceneLoaded -= OnSceneLoadedhome;
        }
    }
}
