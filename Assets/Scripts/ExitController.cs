using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitController : MonoBehaviour
{
    public bool playerInRange = false;//主角是否在npc的碰撞范围内
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
                // 找到你要激活的GameObject
                if (obj.CompareTag("selectScene"))
                {
                    Debug.Log("激活GameObject");
                    // 激活GameObject
                    obj.SetActive(true);
                    break;
                }
            }
        }
        else if(playerInRange==false)
        {
            foreach (GameObject obj in otherScene.GetRootGameObjects())
            {
                // 找到你要激活的GameObject
                if (obj.CompareTag("selectScene"))
                {
                    // 激活GameObject
                    obj.SetActive(false);
                    break;
                }
            }
        }
    }
}
