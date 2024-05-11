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
                //treeObject.layer = Mathf.Max(player.layer - 1, 0); // ��������layer��playerС
            }
            else
            {
                //treeObject.layer = Mathf.Min(player.layer + 1, 31); // ��������layer��player��
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
                treeObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 0.5f); // ����͸����Ϊ0.5��ʵ�ֵ���Ч��
            }
            else
            {
                treeObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f); // �ָ�ԭʼ͸���ȣ�ʵ�ֵ���Ч��
            }

        }
    }

       
}
