using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    public Item slotItem;//�����е���Ʒ
    public Image slotImage;//���ӵ�ͼƬ
    public Text slotNum;//������Ʒ������
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("abs");
        UIcontrollerr.instance_.uitextobj.position = new Vector3(Input.mousePosition.x + 60, Input.mousePosition.y - 100, 0);
        UIcontrollerr.instance_.SetInfo(slotItem.itemInfo);
        //UIcontrollerr.instance_.text.text = this.name;
    }
    //����뿪
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("abbs");

        UIcontrollerr.instance_.HideInfo();
    }
    //�����ui�ﻬ��
    public void OnPointerMove(PointerEventData eventData)
    {
        /*UIcontrollerr.instance_.uitextobj.position = new Vector3(Input.mousePosition.x + 60, Input.mousePosition.y - 50, 0);
        UIcontrollerr.instance_.uitextobj.gameObject.SetActive(true);*/
        //UIcontrollerr.instance_.text.text = this.name;
    }
}