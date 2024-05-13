using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TImeController : MonoBehaviour
{

    public static float gameTime = 0f; // ��Ϸʱ�䣬��λ��Сʱ
    public static int day= 1; // ����
    public Text dayText;
    public string sceneToCheck = "Bar";
    public int flag = 0;

 
    private void Update()
    {

        gameTime += Time.deltaTime; // ��ʵʱ������
        dayText.text = day.ToString();
        if (gameTime >= 25f) // һ��20Сʱ
        {
            gameTime = 0f;

                SceneManager.LoadScene("bar");
                SceneManager.LoadScene("Player", LoadSceneMode.Additive);
                SceneManager.sceneLoaded += OnSceneLoadedhome;

            day++;
        }
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
        if (scene.buildIndex == 0)
        {
            GameObject player = GameObject.FindGameObjectWithTag("player");
            player.transform.position = new Vector3(-1.04f, 0.07f, 0);

            SceneManager.sceneLoaded -= OnSceneLoadedhome;
        }
    }
}
