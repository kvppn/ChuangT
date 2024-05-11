using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSystem : MonoBehaviour
{
    public bool isWorkOne;
    public Item resultItem;//�ϳɵ���Ʒ
    /*public Item resultFabric_1;//�ϳɵĲ���
    public Item resultFabric_2;
    public Item resultFabric_3;
    public Item resultFabric_4;*/
    public bag CraftingBag;//

  // public static CraftingSystem instance;

    public bag Mybag;//�����ĸ�����
    public bag USE_Bag;
    public bag WorkOneBag;

    public GameObject CraftingGrid;
    public GameObject CraftingExit;//�ϳɳ���
    public CraftingSlot craftingSlotPrefab;
    public GameObject[] buttons;

    private void Awake()
    {
        //if (instance != null)
        //    Destroy(this);
        //instance = this;
    }
    private void OnEnable()
    {
        if (isWorkOne)
        {
            BagManager.RefreshWorkOneItemXY();
            Switch(0);
        }
            
        else
            BagManager.RefreshWorkTwoItemXY();
    }
    void Start()
    {
        //SetResultItem(ResultItem);
    }
    public void Exit()
    {
        if (isWorkOne)
        {
            for (int i=0;i< CraftingBag.itemList.Count;i++)
            {
                AddTheItem(CraftingBag.itemList[i], BagManager.instance.WorkOneBagItems);
            }
          

        }
        else
        {
            for (int i = 0; i < CraftingBag.itemList.Count; i++)
            {
                AddTheItem(CraftingBag.itemList[i], BagManager.instance.WorkTwoBagItems);
            }
         
        }
        for (int i = 0; i < CraftingGrid.transform.childCount; i++)
        {
            if (CraftingGrid.transform.childCount == 0)
                break;
            Destroy(CraftingGrid.transform.GetChild(i).gameObject);
        }
        CraftingBag.itemList.Clear();
    }
    public void DescreaseItem(Item thisItem)
    {
        if (CraftingBag == null)
        {
            Debug.LogError("CraftingSystem instance or CraftingBag is not initialized properly.");
            return;
        }
        if (CraftingBag.itemList.Count < 5)
        {
            if (isWorkOne)
                DescreaseTheItem(thisItem, BagManager.instance.WorkOneBagItems);//��������ļ���
            else
                DescreaseTheItem(thisItem, BagManager.instance.WorkTwoBagItems);
        }
        // ��� CraftingGrid �Ƿ����
        if (CraftingGrid != null)
        {
            //if (thisItem.itemHeld>0)
            //����̨����Ʒ���  
            if (isWorkOne)
                AddCraftingNewItem(thisItem, BagManager.instance.WorkOneBagItems);
            else
                AddCraftingNewItem(thisItem, BagManager.instance.WorkTwoBagItems);
           
        }
        else
        {
            Debug.LogError("CraftingGrid is not assigned in CraftingSystem.");
        }
    }

    public void AddCraftingNewItem(Item thisItem, Dictionary<string, Item> bagItems)
    {
       if (CraftingBag.itemList.Count<5)
       {
            Item item = new Item();
            item.itemName = thisItem.itemName;
            item.itemType = thisItem.itemType;
            item.itemImage = thisItem.itemImage;
            item.itemHeld =1;
            item.quality = thisItem.quality;
            item.itemSpeciality = thisItem.itemSpeciality;
            item.specialityCount = thisItem.specialityCount;
            item.itemColor = thisItem.itemColor;
            item.fashion = thisItem.fashion;

            CraftingBag.itemList.Add(item);
            
       }
        BagManager.RefreshCraftingItem(bagItems);
    }
    //�л�ҳǩ  0=��  1=��  2=Ⱦ��
    public void Switch(int index)
    {
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].transform.GetChild(1).gameObject.SetActive(false);
            buttons[i].GetComponent<Image>().color = new Color(1,1,1,1);
        }
        buttons[index].transform.GetChild(1).gameObject.SetActive(true);
        buttons[index].GetComponent<Image>().color = new Color(175f / 255f, 175f / 255f, 175f / 255f, 1);
    }

    //�����ť�ϳɲ�
    public void Craft1()
    {
       
        if(CraftingBag.itemList.Count == 5)
        {
           
            //XY:Item���������ͣ�ֻ���Լ������µģ�����ֱ��ʹ�á�����û�б��ļ�������ڴ���������䷽����д�ϳ�·��
            Item result = new Item();
            //����Ǻϳɲ������ɽ��������̨����2
            int hemu = 0;
            int basi = 0;
            int zishan = 0;
            int jiaoma = 0;

            int qulityTotal = 0;//��Ʒ��

            for (int i = 0; i < CraftingBag.itemList.Count; i++)
            {
             if (CraftingBag.itemList[i].itemName=="��ķ��")
                {
                    hemu++;
                }
             else if (CraftingBag.itemList[i].itemName == "��˹��")
                {
                    basi++;
                }
                else if (CraftingBag.itemList[i].itemName == "��ɼ����")
                {
                    zishan++;
                }
                else if (CraftingBag.itemList[i].itemName == "����")
                {
                    jiaoma++;
                }
                qulityTotal += CraftingBag.itemList[i].quality;
            }
            result.itemHeld = 1;
            if (hemu == 5)
            {
                //�ϳɺ�ķ�޲�����Ҫ���������Ϣ����д
                result.itemName = "��ķ�޲�";
                result.itemType = Item.ItemType.Fabric;
                result.quality = qulityTotal / CraftingBag.itemList.Count;
                result.itemImage = Resources.Load<Sprite>("fabric1");//��ʱͼƬ

                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else if (basi == 5)
            {
                //�ϳɰ�˹�޲�����Ҫ���������Ϣ����д
                result.itemName = "��˹�޲�";
                result.itemType = Item.ItemType.Fabric;
                result.quality = qulityTotal / CraftingBag.itemList.Count;
                result.itemImage = Resources.Load<Sprite>("fabric2");//��ʱͼƬ
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else if (hemu == 3 && basi == 2)
            {
                //�ϳɻ���޲�����Ҫ���������Ϣ����д
                result.itemName = "����޲�";
                result.itemType = Item.ItemType.Fabric;
                result.quality = qulityTotal / CraftingBag.itemList.Count;
                result.itemImage = Resources.Load<Sprite>("fabric5");//��ʱͼƬ
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else if (zishan == 5)
            {
                //�ϳ���ɼ�鲼����Ҫ���������Ϣ����д
                result.itemName = "��ɼ�鲼";
                result.itemType = Item.ItemType.Fabric;
                result.quality = qulityTotal / CraftingBag.itemList.Count;
                result.itemImage = Resources.Load<Sprite>("fabric3");//��ʱͼƬ
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else if (jiaoma == 5)
            {
                //�ϳɽ��鲼����Ҫ���������Ϣ����д
                result.itemName = "���鲼";
                result.itemType = Item.ItemType.Fabric;
                result.quality = qulityTotal / CraftingBag.itemList.Count;
                result.itemImage = Resources.Load<Sprite>("fabric4");//��ʱͼƬ
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else if (zishan == 3 && jiaoma == 2)
            {
                //�ϳɻ���鲼����Ҫ���������Ϣ����д
                result.itemName = "����鲼";
                result.itemType = Item.ItemType.Fabric;
                result.quality = qulityTotal / CraftingBag.itemList.Count;
                result.itemImage = Resources.Load<Sprite>("fabric6");//��ʱͼƬ
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else if (hemu == 1 && basi == 1 && zishan == 1 && jiaoma == 2)
            {
                //�ϳ����鲼����Ҫ���������Ϣ����д
                result.itemName = "���鲼";
                result.itemType = Item.ItemType.Fabric;
                result.quality = qulityTotal / CraftingBag.itemList.Count;
                result.itemImage = Resources.Load<Sprite>("fabric7");//��ʱͼƬ
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else
            {
                //�ϳ�ʧ��
                //�ϳ�ʧ�ܵ�UI����д����
                print("���ܺϳ�");
                return;
            }
            for (int i = 0; i < CraftingGrid.transform.childCount; i++)
            {
                if (CraftingGrid.transform.childCount == 0)
                    break;
                Destroy(CraftingGrid.transform.GetChild(i).gameObject);
            }
            CraftingBag.itemList.Clear();
        }
    }
    //�����ť�ϳ���
    public void Craft2()
    {

        if (CraftingBag.itemList.Count == 5)
        {

            //XY:Item���������ͣ�ֻ���Լ������µģ�����ֱ��ʹ�á�����û�б��ļ�������ڴ���������䷽����д�ϳ�·��
            Item result = new Item();
            //�����ɽ��������̨����2
            int fengzhi = 0;
            int xingrong = 0;
            int shuangjing = 0;
            int chilin = 0;

            int qulityTotal = 0;//��Ʒ��
            int specialityCount = 0;//������ֵ
            for (int i = 0; i < CraftingBag.itemList.Count; i++)
            {
                if (CraftingBag.itemList[i].itemName == "��֯��")
                {
                    fengzhi++;
                }
                else if (CraftingBag.itemList[i].itemName == "���޲�")
                {
                    xingrong++;
                }
                else if (CraftingBag.itemList[i].itemName == "˪����")
                {
                    shuangjing++;
                }
                else if (CraftingBag.itemList[i].itemName == "���۲�")
                {
                    chilin++;
                }
                qulityTotal += CraftingBag.itemList[i].quality;
            }
            result.itemHeld = 1;
            if (fengzhi == 3&&xingrong==2)
            {
                //�ϳɷ�֯�ߣ���Ҫ���������Ϣ����д
                result.itemName = "��֯��";
                result.itemType = Item.ItemType.Thread;
                result.quality = qulityTotal / CraftingBag.itemList.Count;
                result.itemImage = Resources.Load<Sprite>("thread1");//��ʱͼƬ
                result.itemSpeciality = Item.ItemSpeciality.Dexterity;
                result.specialityCount = 30;//���Թ̶������޸�����д��ʽ����
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else if (xingrong == 5)
            {
                //�ϳ������ߣ���Ҫ���������Ϣ����д
                result.itemName = "������";
                result.itemType = Item.ItemType.Thread;
                result.quality = qulityTotal / CraftingBag.itemList.Count;
                result.itemImage = Resources.Load<Sprite>("thread2");//��ʱͼƬ
                result.itemSpeciality = Item.ItemSpeciality.Shine;
                result.specialityCount = 50;//���Թ̶������޸�����д��ʽ����
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else if (shuangjing == 3 && xingrong == 2)
            {
                //�ϳ�˪�����ߣ���Ҫ���������Ϣ����д
                result.itemName = "˪������";
                result.itemType = Item.ItemType.Thread;
                result.quality = qulityTotal / CraftingBag.itemList.Count;
                result.itemImage = Resources.Load<Sprite>("thread3");//��ʱͼƬ
                result.itemSpeciality = Item.ItemSpeciality.Ice;
                result.specialityCount = 30;//���Թ̶������޸�����д��ʽ����
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else if (chilin == 3&& xingrong==2)
            {
                //�ϳɳ����ߣ���Ҫ���������Ϣ����д
                result.itemName = "������";
                result.itemType = Item.ItemType.Thread;
                result.quality = qulityTotal / CraftingBag.itemList.Count;
                result.itemImage = Resources.Load<Sprite>("thread4");//��ʱͼƬ
                result.itemSpeciality = Item.ItemSpeciality.Fire;
                result.specialityCount = 30;//���Թ̶������޸�����д��ʽ����
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
        
            else
            {
                //�ϳ�ʧ��
                //�ϳ�ʧ�ܵ�UI����д����
                print("���ܺϳ�");
                return;
            }
            for (int i = 0; i < CraftingGrid.transform.childCount; i++)
            {
                if (CraftingGrid.transform.childCount == 0)
                    break;
                Destroy(CraftingGrid.transform.GetChild(i).gameObject);
            }
            CraftingBag.itemList.Clear();




        }
    }
    //�����ť�ϳ�Ⱦ��
    public void Craft3()
    {

        if (CraftingBag.itemList.Count == 5)
        {

            //XY:Item���������ͣ�ֻ���Լ������µģ�����ֱ��ʹ�á�����û�б��ļ�������ڴ���������䷽����д�ϳ�·��
            Item result = new Item();
            //�����ɽ��������̨����2
            int tiancai = 0;
            int diedou = 0;
            int huluo = 0;
            int lingtan = 0;
            int caifu = 0;
          
            for (int i = 0; i < CraftingBag.itemList.Count; i++)
            {
                if (CraftingBag.itemList[i].itemName == "��˸�")
                {
                    tiancai++;
                }
                else if (CraftingBag.itemList[i].itemName == "������")
                {
                    diedou++;
                }
                else if (CraftingBag.itemList[i].itemName == "���ܲ�")
                {
                    huluo++;
                }
                else if (CraftingBag.itemList[i].itemName == "��̼��")
                {
                    lingtan++;
                }
                else if (CraftingBag.itemList[i].itemName == "����ķ���Һ")
                {
                    caifu++;
                }

            }
            result.itemHeld = 1;
            if (tiancai == 5)
            {
                //�ϳɺ�ɫȾ������Ҫ���������Ϣ����д
                result.itemName = "��ɫȾ��";
                result.itemType = Item.ItemType.Dye;
             
                result.itemImage = Resources.Load<Sprite>("dye1");//��ʱͼƬ
                result.itemColor = Item.ItemColor.Red;
                result.fashion = 25;
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else if (diedou == 5)
            {
                //�ϳ���ɫȾ������Ҫ���������Ϣ����д
                result.itemName = "��ɫȾ��";
                result.itemType = Item.ItemType.Dye;
             
                result.itemImage = result.itemImage = Resources.Load<Sprite>("dye2");//��ʱͼƬ
                result.itemColor = Item.ItemColor.Bule;
                result.fashion = 30;
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else if (huluo ==5)
            {
                //�ϳɻ�ɫȾ������Ҫ���������Ϣ����д
                result.itemName = "��ɫȾ��";
                result.itemType = Item.ItemType.Dye;
              
                result.itemImage = result.itemImage = Resources.Load<Sprite>("dye3");//��ʱͼƬ
                result.itemColor = Item.ItemColor.Yellow;
                result.fashion = 20;
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else if (lingtan == 5)
            {
                //�ϳɺ�ɫȾ������Ҫ���������Ϣ����д
                result.itemName = "��ɫȾ��";
                result.itemType = Item.ItemType.Dye;
                
                result.itemImage = result.itemImage = Resources.Load<Sprite>("dye4");//��ʱͼƬ
                result.itemColor = Item.ItemColor.Black;
                result.fashion = 40;
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else if (caifu == 5)
            {
                //�ϳ��Ų�Ⱦ������Ҫ���������Ϣ����д
                result.itemName = "�Ų�Ⱦ��";
                result.itemType = Item.ItemType.Dye;
              
                result.itemImage = result.itemImage = Resources.Load<Sprite>("dye5");//��ʱͼƬ
                result.itemColor = Item.ItemColor.Colors;
                result.fashion = 60;
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
          
            else
            {
                //�ϳ�ʧ��
                //�ϳ�ʧ�ܵ�UI����д����
                print("���ܺϳ�");
                return;
            }
            for (int i = 0; i < CraftingGrid.transform.childCount; i++)
            {
                if (CraftingGrid.transform.childCount == 0)
                    break;
                Destroy(CraftingGrid.transform.GetChild(i).gameObject);
            }
            CraftingBag.itemList.Clear();
        }
    }
    //�����ť�ϳ��·�
    public void Craft4()
    {

        if (CraftingBag.itemList.Count == 5)
        {

            //XY:Item���������ͣ�ֻ���Լ������µģ�����ֱ��ʹ�á�����û�б��ļ�������ڴ���������䷽����д�ϳ�·��
            Item result = new Item();
            //����Ǻϳ��·������ɽ������������
           
            int qulityTotal = 0;//Ʒ��
            int specialityCount = 0;//������ֵ
            int fashion = 0;//ʱ��


            bool isF = false;//�Ƿ��в�
            bool isT = false;//�Ƿ�����
            for (int i = 0; i < CraftingBag.itemList.Count; i++)
            {
               if(CraftingBag.itemList[i].itemType==Item.ItemType.Fabric || CraftingBag.itemList[i].itemType == Item.ItemType.Thread)
                qulityTotal += CraftingBag.itemList[i].quality;

                if (CraftingBag.itemList[i].itemType == Item.ItemType.Decorate || CraftingBag.itemList[i].itemType == Item.ItemType.Thread)
                    specialityCount += CraftingBag.itemList[i].specialityCount;

                if (CraftingBag.itemList[i].itemType == Item.ItemType.Decorate || CraftingBag.itemList[i].itemType == Item.ItemType.Dye)
                    fashion += CraftingBag.itemList[i].fashion;

                if (CraftingBag.itemList[i].itemType == Item.ItemType.Fabric)
                    isF = true;

                if (CraftingBag.itemList[i].itemType == Item.ItemType.Thread)
                    isT = true;
            }
            result.itemHeld = 1;
            if (isF&&isT)
            {
                //�ϳ��·�����Ҫ���������Ϣ����д
                result.itemName = "�·�";
                result.itemType = Item.ItemType.Cloth;
                result.quality = qulityTotal;
                result.itemImage = CraftingBag.itemList[0].itemImage;//��ʱͼƬ
                result.specialityCount = specialityCount;
                result.fashion = fashion;
                result.money = qulityTotal * 5 + specialityCount * 3 + fashion * 2;


                AddNewItem(result, BagManager.instance.SaleBag);//�·����ĸ�������������޸ģ�Ŀǰ����������

            }
          
            else
            {
                //�ϳ�ʧ��
                //�ϳ�ʧ�ܵ�UI����д����
                print("���ܺϳ�");
                return;
            }
            for (int i = 0; i < CraftingGrid.transform.childCount; i++)
            {
                if (CraftingGrid.transform.childCount == 0)
                    break;
                Destroy(CraftingGrid.transform.GetChild(i).gameObject);
            }
            CraftingBag.itemList.Clear();




        }
    }
    public void DescreaseTheItem(Item thisItem, Dictionary<string, Item> bagItems)
    {
       
    
            bagItems[thisItem.itemName].itemHeld -= 1;
        if (bagItems[thisItem.itemName].itemHeld <= 0)
        {
            //����0��ʱ������
            bagItems.Remove(thisItem.itemName);
        }
        BagManager.RefreshItem();
        BagManager.RefreshUSEItem();
        if (isWorkOne)
            BagManager.RefreshWorkOneItemXY();
        else
            BagManager.RefreshWorkTwoItemXY();
    }
    public void AddTheItem(Item thisItem, Dictionary<string, Item> bagItems)
    {

        if (bagItems.ContainsKey(thisItem.itemName))
            bagItems[thisItem.itemName].itemHeld += 1;
        else
            bagItems.Add(thisItem.itemName, thisItem);
        BagManager.RefreshItem();
        BagManager.RefreshUSEItem();
        if (isWorkOne)
            BagManager.RefreshWorkOneItemXY();
        else
            BagManager.RefreshWorkTwoItemXY();
    }
    public void AddNewItem(Item thisItem,bag bag, Dictionary<string, Item> bagItems=null)//XY:ʹ��bag���δ���ָ������
    {
       
        if (bagItems != null)
        {
            if (bagItems.ContainsKey(thisItem.itemName))
            {
                bagItems[thisItem.itemName].itemHeld += thisItem.itemHeld;
            }
            else
            {
                bagItems.Add(thisItem.itemName, thisItem);
            }
            if (bagItems[thisItem.itemName].itemHeld <= 0)
                bagItems.Remove(thisItem.itemName);
        }

        CraftingSlot newItem = Instantiate(craftingSlotPrefab, CraftingExit.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(CraftingExit.transform);
        newItem.slotImage.sprite = thisItem.itemImage;
        newItem.slotItem = thisItem;
        newItem.slotNum.text = thisItem.itemHeld.ToString();

        newItem.gameObject.AddComponent<Button>().onClick.AddListener(()=> {
            if (!bag.itemList.Contains(thisItem))
            {
                // Mybag.itemList.Add(thisItem);//�����Ʒ��ӵ����������
                //   USE_Bag.itemList.Add(thisItem);//�����Ʒ��ӵ����������
                bag.itemList.Add(thisItem);//�����Ʒ��ӵ����������
                                           //BagManager.CreateNewItem(thisItem);
            }
            else
            {
                thisItem.itemHeld += 1;
            }
            BagManager.RefreshItem();
            BagManager.RefreshUSEItem();
            if (isWorkOne)
                BagManager.RefreshWorkOneItemXY();
            else
                BagManager.RefreshWorkTwoItemXY();
            Destroy(newItem.gameObject);
        });
     
    }
}
