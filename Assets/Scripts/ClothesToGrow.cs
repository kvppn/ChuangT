using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ClothesToGrow : MonoBehaviour
{
    private Transform playerSpawnPoint; // ����Ӧ�ó��ֵ�λ��

    private GeminiDia geminiDia;

   public static int flag = 1;
   public int intVal = 2;


    // Start is called before the first frame update
    void Start()
    {
        GameObject NPCObject = GameObject.FindGameObjectWithTag("NPCTotal");
        if (NPCObject != null)
        {
            geminiDia = NPCObject.GetComponent<GeminiDia>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == 1)
        {
            intVal = PlayerPrefs.GetInt("intCut");
            flag = 2;
        }
        if (intVal == 1)
        {
            intVal = 2;
            StartCoroutine(LoadCharacterScene());
        }
    }
    IEnumerator LoadCharacterScene()
    {

        // �ƶ����ǵ��̶�λ��
        GameObject player = GameObject.FindGameObjectWithTag("player");

        AsyncOperation asyncLoadGrow = SceneManager.LoadSceneAsync("Grow");
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Player", LoadSceneMode.Additive);

        while (!asyncLoad.isDone || !asyncLoadGrow.isDone)
        {
            yield return null;
        }
        GameObject playerSpawnObject = GameObject.FindGameObjectWithTag("playerSpawn_1");
        if (playerSpawnObject != null)
        {
            playerSpawnPoint = playerSpawnObject.GetComponent<Transform>();
        }
        player.transform.position = playerSpawnPoint.position;//�������ɵ�λ��
    }
}
