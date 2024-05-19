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
        UIcontrollerr.instance_.uitextobj.position = new Vector3(Input.mousePosition.x + 60, Input.mousePosition.y -50, 0);
        UIcontrollerr.instance_.uitextobj.gameObject.SetActive(true);
        //UIcontrollerr.instance_.text.text = this.name;
    }
    //����뿪
    public void OnPointerExit(PointerEventData eventData)
    {
        UIcontrollerr.instance_.uitextobj.gameObject.SetActive(false);
    }
    //�����ui�ﻬ��
    public void OnPointerMove(PointerEventData eventData)
    {
        UIcontrollerr.instance_.uitextobj.position = new Vector3(Input.mousePosition.x + 60, Input.mousePosition.y -50, 0);
        UIcontrollerr.instance_.uitextobj.gameObject.SetActive(true);
        //UIcontrollerr.instance_.text.text = this.name;
    }
}
