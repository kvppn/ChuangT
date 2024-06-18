using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneExitOut : MonoBehaviour
{
    public RectTransform imageRect; // UI元素的RectTransform
    public Transform position; // 世界坐标位置

    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(position.position); // 将世界坐标转换为屏幕坐标
        imageRect.position = screenPos; // 设置UI元素的位置为屏幕坐标位置
    }
}
