using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class workOneSlot : MonoBehaviour, IPointerClickHandler
{
    
    public Item slotItem;//�����е���Ʒ
    public Image slotImage;//���ӵ�ͼƬ
    public Text slotNum;//������Ʒ������
                        //public CraftingSystem craftingSystem;
    public CraftingSystem craftingSystem;
    public bool isClick = true;
    public void Update()
    {
        craftingSystem = FindObjectOfType<CraftingSystem>();
       
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        // ������
        if (eventData.button == PointerEventData.InputButton.Left && craftingSystem.CraftingExit.transform.childCount==0)
        {
            // ���� CraftingSystem �� DescreaseItem �����������Ӧ����Ʒ
            craftingSystem.DescreaseItem(slotItem);
        }
    }
}
