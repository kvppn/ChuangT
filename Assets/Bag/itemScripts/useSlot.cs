using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class useSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    // Start is called before the first frame update
    public Item slotItem;//�����е���Ʒ
    public Image slotImage;//���ӵ�ͼƬ
    public Text slotNum;//������Ʒ������

    public void OnPointerEnter(PointerEventData eventData)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector2 offset = new Vector2(rectTransform.rect.width / 2f, rectTransform.rect.height / 2f);
        UIcontrollerr.instance_.uitextobj.position = new Vector3(Input.mousePosition.x + offset.x + 60, Input.mousePosition.y + offset.y - 50, 0);
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
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector2 offset = new Vector2(rectTransform.rect.width / 2f, rectTransform.rect.height / 2f);
        UIcontrollerr.instance_.uitextobj.position = new Vector3(Input.mousePosition.x + offset.x + 60, Input.mousePosition.y + offset.y - 50, 0);
        UIcontrollerr.instance_.uitextobj.gameObject.SetActive(true);
        //UIcontrollerr.instance_.text.text = this.name;
    }
}