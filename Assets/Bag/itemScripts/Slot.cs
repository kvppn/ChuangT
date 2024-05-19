using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    public Item slotItem;//格子中的物品
    public Image slotImage;//格子的图片
    public Text slotNum;//格子物品的数量
    public void OnPointerEnter(PointerEventData eventData)
    {
        UIcontrollerr.instance_.uitextobj.position = new Vector3(Input.mousePosition.x + 60, Input.mousePosition.y -50, 0);
        UIcontrollerr.instance_.uitextobj.gameObject.SetActive(true);
        //UIcontrollerr.instance_.text.text = this.name;
    }
    //鼠标离开
    public void OnPointerExit(PointerEventData eventData)
    {
        UIcontrollerr.instance_.uitextobj.gameObject.SetActive(false);
    }
    //鼠标在ui里滑动
    public void OnPointerMove(PointerEventData eventData)
    {
        UIcontrollerr.instance_.uitextobj.position = new Vector3(Input.mousePosition.x + 60, Input.mousePosition.y -50, 0);
        UIcontrollerr.instance_.uitextobj.gameObject.SetActive(true);
        //UIcontrollerr.instance_.text.text = this.name;
    }
}
