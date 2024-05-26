using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ButtonBehavior : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image buttonImage;
    public Sprite normalSprite; // 未被选择时的图片
    public Sprite selectedSprite; // 被选择时的图片

    // 当鼠标进入按钮时触发
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = selectedSprite; // 切换为被选择时的图片
        buttonImage.transform.localScale *= 2f; // 放大两倍
    }

    // 当鼠标离开按钮时触发
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = normalSprite; // 切换为未被选择时的图片
        buttonImage.transform.localScale /= 2f; // 恢复原始大小
    }

    // 当按钮被点击时触发
    public void OnPointerClick(PointerEventData eventData)
    {
        // 可以在这里添加按钮点击的逻辑
        Debug.Log("Button Clicked!");
    }
}
