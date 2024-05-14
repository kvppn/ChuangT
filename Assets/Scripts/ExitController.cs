using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitController : MonoBehaviour
{
    public bool playerInRange = false;//�����Ƿ���npc����ײ��Χ��
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.CompareTag("player"))
        {
            playerInRange = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            playerInRange = false; 
        }
    }
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        Scene otherScene = SceneManager.GetSceneByName("Player");
        if (playerInRange == true)
        {
            foreach (GameObject obj in otherScene.GetRootGameObjects())
            {
                // �ҵ���Ҫ�����GameObject
                if (obj.CompareTag("selectScene"))
                {
                    Debug.Log("����GameObject");
                    // ����GameObject
                    obj.SetActive(true);
                    break;
                }
            }
        }
        else if(playerInRange==false)
        {
            foreach (GameObject obj in otherScene.GetRootGameObjects())
            {
                // �ҵ���Ҫ�����GameObject
                if (obj.CompareTag("selectScene"))
                {
                    // ����GameObject
                    obj.SetActive(false);
                    break;
                }
            }
        }
    }
}
