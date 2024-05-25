using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Work_1Controller : MonoBehaviour
{
    public bool playerInRange = false;//�����Ƿ���npc����ײ��Χ��

    //public GameObject workone;//����̨1��UI
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
        if (Input.GetMouseButtonDown(1)) // 1��������Ҽ�
        {
            Debug.Log("1");
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int layerMask = 1 << LayerMask.NameToLayer("WorkOne");

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, layerMask);
            Debug.Log(hit.collider.name);
            if (hit.collider != null && hit.collider == GetComponent<Collider2D>() && playerInRange == true)
            {
                GameObject.FindGameObjectWithTag("player").GetComponent<playerWalk>().enabled=false ;
                foreach (GameObject obj in otherScene.GetRootGameObjects())
                {
                    // �ҵ���Ҫ�����GameObject
                    if (obj.CompareTag("workCraftingCanvas"))
                    {
                        // ����GameObject
                        obj.SetActive(true);
                        break;
                    }
                }
            }

        }
    }
}
