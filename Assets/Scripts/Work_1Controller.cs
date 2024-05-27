using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Work_1Controller : MonoBehaviour
{
    public bool playerInRange = false;//主角是否在npc的碰撞范围内
    public Animator animator;
    //public GameObject workone;//工作台1的UI
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
    void Start()
    {
        //workone = GameObject.FindGameObjectWithTag("workCraftingCanvas");
    }

    // Update is called once per frame
    void Update()
    {
        Scene otherScene = SceneManager.GetSceneByName("Player");
        if (Input.GetMouseButtonDown(1)) // 1代表鼠标右键
        {
            Debug.Log("1");
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int layerMask = 1 << LayerMask.NameToLayer("WorkOne");

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, layerMask);
            //Debug.Log(hit.collider.name);
            if (hit.collider != null && hit.collider == GetComponent<Collider2D>() && playerInRange == true)
            {
                animator.Play("workOne_jiaohu");
                GameObject.FindGameObjectWithTag("player").GetComponent<playerWalk>().enabled=false ;
                foreach (GameObject obj in otherScene.GetRootGameObjects())
                {
                    // 找到你要激活的GameObject
                    if (obj.CompareTag("workCraftingCanvas"))
                    {
                        // 激活GameObject
                        obj.SetActive(true);
                        break;
                    }
                }
            }

        }
    }
}
