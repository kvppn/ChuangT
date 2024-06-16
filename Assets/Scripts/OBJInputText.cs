using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OBJInputText : MonoBehaviour
{
    public string t;
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
    private void OnMouseEnter()
    {
        if (playerInRange == true)
        {
            UIcontrollerr.instance_.uitextobj.position = new Vector3(Input.mousePosition.x + 120, Input.mousePosition.y - 100, 0);
            UIcontrollerr.instance_.uitextobj.gameObject.SetActive(true);
            UIcontrollerr.instance_.text.text = t;
        }
    }
    private void OnMouseExit()
    {
        UIcontrollerr.instance_.uitextobj.gameObject.SetActive(false);
    }
    private void OnMouseOver()
    {
        if (playerInRange == true)
        {
            UIcontrollerr.instance_.uitextobj.position = new Vector3(Input.mousePosition.x + 120, Input.mousePosition.y - 100, 0);
            UIcontrollerr.instance_.uitextobj.gameObject.SetActive(true);
            UIcontrollerr.instance_.text.text = t;
        }
    }
}
