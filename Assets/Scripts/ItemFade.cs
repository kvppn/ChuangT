using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFade : MonoBehaviour
{
    public GameObject treeObject;
    public bool isNearTree = false;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }
    void Update()
    {
        if (player != null)
        {
            if (player.transform.position.y < treeObject.transform.position.y)
            {
                //treeObject.layer = Mathf.Max(player.layer - 1, 0); // 设置树的layer比player小
            }
            else
            {
                //treeObject.layer = Mathf.Min(player.layer + 1, 31); // 设置树的layer比player大
            }
            if (Vector3.Distance(player.transform.position, treeObject.transform.position) < 2f)
            {
                isNearTree = true;
            }
            else
            {
                isNearTree = false;
            }

            if (isNearTree)
            {
                treeObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 0.5f); // 设置透明度为0.5，实现淡出效果
            }
            else
            {
                treeObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f); // 恢复原始透明度，实现淡入效果
            }

        }
    }

       
}
