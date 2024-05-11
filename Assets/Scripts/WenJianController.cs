using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class WenJianController : MonoBehaviour
{
    public GameObject redDot;
    public Image newImage;

    public GameObject image;

    public GameObject exitButton;//信件退出的按钮。

    public bool playerInRange = false;//主角是否在npc的碰撞范围内

    public bool playerIswalking = false;

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
    void Start()
    {
        image.SetActive(true);
        redDot.SetActive(true);
        newImage.gameObject.SetActive(false);
        exitButton.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // 检测鼠标右键点击
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            //Debug.Log("Right clicked on: " + hit.collider.gameObject.name);
            if (hit.collider != null && hit.collider == GetComponent<Collider2D>() && playerInRange == true)
            {
                Debug.Log("3");
                Debug.Log("Image被鼠标右键点击了");
                image.SetActive(false);
                redDot.SetActive(false);
                newImage.gameObject.SetActive(true);
                exitButton.SetActive(true);
            }
           /* RectTransform rt = image.rectTransform;
            Vector2 localMousePosition = rt.InverseTransformPoint(Input.mousePosition);

            if (rt.rect.Contains(localMousePosition))
            {
                Debug.Log("Image被鼠标右键点击了");
                image.gameObject.SetActive(false);
                redDot.gameObject.SetActive(false);
                newImage.gameObject.SetActive(true);
                exitButton.SetActive(true);
            }*/
        }
    }
    public void Exit()
    {
        image.SetActive(false);
        redDot.SetActive(false);
        newImage.gameObject.SetActive(false);
        exitButton.SetActive(false);
        playerIswalking = true;
    }
}
