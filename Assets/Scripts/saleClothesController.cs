using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class saleClothesController : MonoBehaviour
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
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Scene otherScene = SceneManager.GetSceneByName("Player");
        if (Input.GetMouseButtonDown(1)) // 1��������Ҽ�
        {
            Debug.Log("1");
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int layerMask = 1 << LayerMask.NameToLayer("Default");

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, layerMask);

            if (hit.collider != null && hit.collider == GetComponent<Collider2D>() && playerInRange == true)
            {
                foreach (GameObject obj in otherScene.GetRootGameObjects())
                {
                    // �ҵ���Ҫ�����GameObject
                    if (obj.CompareTag("saleCanvas"))
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
