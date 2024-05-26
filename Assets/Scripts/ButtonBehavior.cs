using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ButtonBehavior : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image buttonImage;
    public Sprite normalSprite; // δ��ѡ��ʱ��ͼƬ
    public Sprite selectedSprite; // ��ѡ��ʱ��ͼƬ

    // �������밴ťʱ����
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = selectedSprite; // �л�Ϊ��ѡ��ʱ��ͼƬ
        buttonImage.transform.localScale *= 2f; // �Ŵ�����
    }

    // ������뿪��ťʱ����
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = normalSprite; // �л�Ϊδ��ѡ��ʱ��ͼƬ
        buttonImage.transform.localScale /= 2f; // �ָ�ԭʼ��С
    }

    // ����ť�����ʱ����
    public void OnPointerClick(PointerEventData eventData)
    {
        // ������������Ӱ�ť������߼�
        Debug.Log("Button Clicked!");
    }
}
