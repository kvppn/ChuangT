using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class workOneSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{

    public Item slotItem;//�����е���Ʒ
    public Image slotImage;//���ӵ�ͼƬ
    public Text slotNum;//������Ʒ������
                      
    public CraftingSystem craftingSystem;
    public bool isClick = true;

    private void Start()
    {
        //craftingSystem = FindObjectOfType<CraftingSystem>();
        
    }
    public void Update()
    {
        craftingSystem = FindObjectOfType<CraftingSystem>();
    }
     public void OnPointerEnter(PointerEventData eventData) { 
        UIcontrollerr.instance_.uitextobj.position = new Vector3(Input.mousePosition.x + 60, Input.mousePosition.y - 50, 0);
        UIcontrollerr.instance_.uitextobj.gameObject.SetActive(true); 
        UIcontrollerr.instance_.text.text = slotItem.itemInfo;
    } //����뿪 
    public void OnPointerExit(PointerEventData eventData) { 
        UIcontrollerr.instance_.uitextobj.gameObject.SetActive(false); 
    } //�����ui�ﻬ��
    public void OnPointerMove(PointerEventData eventData) { 
       /* UIcontrollerr.instance_.uitextobj.position = new Vector3(Input.mousePosition.x + 60, Input.mousePosition.y - 50, 0);
        UIcontrollerr.instance_.uitextobj.gameObject.SetActive(true); 
        UIcontrollerr.instance_.text.text = slotItem.itemInfo; */
    } //����
      public void OnPointerClick(PointerEventData eventData) { // ������
         if (eventData.button == PointerEventData.InputButton.Left && craftingSystem.CraftingExit.transform.childCount == 0) 
        { // ���� CraftingSystem �� DescreaseItem �����������Ӧ����Ʒ
          craftingSystem.DescreaseItem(slotItem);
        } 
    } 
}
                                                                                                                             //���⿪ʼ
    /*  public void OnPointerEnter(PointerEventData eventData)
      {
          UIcontrollerr.instance_.uitextobj.position = new Vector3(Input.mousePosition.x + 60, Input.mousePosition.y - 50, 0);
          UIcontrollerr.instance_.uitextobj.gameObject.SetActive(true);
          UIcontrollerr.instance_.text.text = slotItem.itemInfo;
      }
      //����뿪
      public void OnPointerExit(PointerEventData eventData)
      {
          UIcontrollerr.instance_.uitextobj.gameObject.SetActive(false);
      }
      //�����ui�ﻬ��
      public void OnPointerMove(PointerEventData eventData)
      {
          UIcontrollerr.instance_.uitextobj.position = new Vector3(Input.mousePosition.x + 60, Input.mousePosition.y - 50, 0);
          UIcontrollerr.instance_.uitextobj.gameObject.SetActive(true);
          UIcontrollerr.instance_.text.text = slotItem.itemInfo;
      }
      //����
      public void OnPointerClick(PointerEventData eventData)
      {
          // ������
          if (eventData.button == PointerEventData.InputButton.Left && craftingSystem.CraftingExit.transform.childCount == 0)
          {
              // ���� CraftingSystem �� DescreaseItem �����������Ӧ����Ʒ
              craftingSystem.DescreaseItem(slotItem);
          }
      }*/


