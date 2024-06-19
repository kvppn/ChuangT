using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TImeController : MonoBehaviour
{
    public static int day= 1; // 天数
    public Text dayText;
    public string sceneToCheck = "Bar";
    public Blood blloody;

    public testSelectScene selectscene;
    private void Update()
    {
        dayText.text = day.ToString();
        /* gameTime += Time.deltaTime; // 真实时间流逝

         if (gameTime >= 70f) // 一天20小时
         {
             blloody.sleepBlood();
             gameTime = 0f;
                 SceneManager.LoadScene("bar");
                 SceneManager.LoadScene("Player", LoadSceneMode.Additive);
                 SceneManager.sceneLoaded += OnSceneLoadedhome;

             day++;
         }*/
    }
    public void GoToSleep()
    {
        blloody.sleepBlood();
        dayText.text = day.ToString();
        day++;
        selectscene.GotoSleep();
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
