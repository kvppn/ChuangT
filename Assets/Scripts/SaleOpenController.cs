using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaleOpenController : MonoBehaviour
{
    public bool playerInRange = false;//主角是否在npc的碰撞范围内

    public GameObject Sale;//工作台1的UI
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
        Sale = GameObject.FindGameObjectWithTag("saleCanvas");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1)) // 1代表鼠标右键
        {
            Debug.Log("1");
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int layerMask = 1 << LayerMask.NameToLayer("Default");

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, layerMask);

            if (hit.collider != null && hit.collider == GetComponent<Collider2D>() && playerInRange == true)
            {
                Sale.GetComponent<Canvas>().enabled = true;
            }
        }
    }
}
