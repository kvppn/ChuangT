using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToSleep : MonoBehaviour
{
    public bool playerInRange = false;//主角是否在npc的碰撞范围内
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
                // 找到你要激活的GameObject
                if (obj.CompareTag("gosleep"))
                {
                    // 激活GameObject
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
