using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Item",menuName ="Bag/New Item")]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        None,
        FabricMaterial,//����-������
       ThreadMaterial,//����-�߲���
        DyeMaterial,//����-Ⱦ�ϲ���
        Fabric,//��
        Thread,//��
        Dye,//Ⱦ��
        Decorate,//װ��
        Cloth//�·�
    }
    public enum ItemSpeciality
    {
        None,
        Dexterity,//����
        Shine,//����
        Ice,//��
        Fire,//����
    }
    public enum ItemColor
    {
        None,
        Red,
        Bule,
        Yellow,
        Black,
        Colors
    }
    public string itemName;//��Ʒ����
    public ItemType itemType;//��Ʒ����
    public GameObject prefab;//���ӵ�Ԥ����
    public GameObject growed;//�����Ԥ����
    public Sprite itemImage;//ͼƬ
    public int itemHeld;//��Ʒ������
    [TextArea]
    public string itemInfo;//һЩ��Ϣ��������д
    public int money;
    public bool equip;//�Ƿ����װ��
    public bool grow;//�Ƿ����װ��


    public int quality;//Ʒ��
    public ItemSpeciality itemSpeciality;//��Ʒ����
    public int specialityCount;//������ֵ
    public ItemColor itemColor;//��Ʒ��ɫ
    public int fashion;//ʱ����ֵ
}