using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToSleep : MonoBehaviour
{
    public bool playerInRange = false;//�����Ƿ���npc����ײ��Χ��
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
    void Update()
    {
        Scene otherScene = SceneManager.GetSceneByName("Player");
        if (playerInRange == true)
        {
            foreach (GameObject obj in otherScene.GetRootGameObjects())
            {
                // �ҵ���Ҫ�����GameObject
                if (obj.CompareTag("gosleep"))
                {
                    // ����GameObject
                    obj.SetActive(true);
                    break;
                }
            }
        }
        else if (playerInRange == false)
        {
            foreach (GameObject obj in otherScene.GetRootGameObjects())
            {
                if (obj.CompareTag("gosleep"))
                {
                    obj.SetActive(false);
                    break;
                }
            }
        }
    }
}
