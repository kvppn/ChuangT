using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;
public class CraftingSystem : MonoBehaviour
{
    public bool isWorkOne;
    public Item resultItem;//合成的物品
    public bag CraftingBag;//

  // public static CraftingSystem instance;

    public bag Mybag;//属于哪个背包
    public bag USE_Bag;
    public bag WorkOneBag;
    public bag saleBag;

    public GameObject CraftingGrid;
    public GameObject CraftingGrid2;
    public GameObject CraftingExit;//合成出口
    public GameObject CraftingPanel;
    public CraftingSlot craftingSlotPrefab;
    public GameObject[] buttons;
    public Sprite[] image;//被点击按钮的图片
    public Sprite[] imageInitial;//被点击按钮的图片原始的样子
    public GameObject[] crafting;//合成的三个按钮
    public Animator transitionAnimators; // 存储不同切换动画的Animator组件
    public GameObject work2BG;
    public Animator animator;
    public Animator shiningg;//闪光动画
    public Animator animatorPlayer;//主角的动画
    public GameObject player;

    private int currentIndex = 0; // 当前按钮的索引
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
        transitionAnimators = GameObject.FindGameObjectWithTag("transAnimator").GetComponent<Animator>();
    }
     void Update()
    {
        animator = GameObject.FindGameObjectWithTag("workinganimitor").GetComponent<Animator>();
        
        // 检查动画是否播放完成
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            // 如果动画播放完成，停止动画
            StopAnimation();
        }
    }
    public void Exit()
    {
        GameObject.FindGameObjectWithTag("player").GetComponent<playerWalk>().enabled = true;
        transitionAnimators.Play("workOne_idle");
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
            GameObject Camera = GameObject.FindGameObjectWithTag("camera");
            
            Camera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 3.88f;//虚拟相机
                                                                                            // 获取CinemachineVirtualCamera组件
            CinemachineVirtualCamera virtualCamera = Camera.GetComponent<CinemachineVirtualCamera>();

            // 获取当前的Follow组件
            CinemachineTransposer transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();

            // 修改follow offset
            transposer.m_FollowOffset = new Vector3(-0.02f, 0.49f, -10);

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
                DescreaseTheItem(thisItem, BagManager.instance.WorkOneBagItems);//背包物体的减少
            else
            {
                if (CraftingBag.itemList.Count == 0 && thisItem.itemType == Item.ItemType.Fabric){//第一个被点击物品步，背包数量减少
                    DescreaseTheItem(thisItem, BagManager.instance.WorkTwoBagItems);
                 }
                else if (CraftingBag.itemList.Count == 1 && thisItem.itemType == Item.ItemType.Thread)
                {//第二个被点击物品步，背包数量减少
                    DescreaseTheItem(thisItem, BagManager.instance.WorkTwoBagItems);
                }
                else if (CraftingBag.itemList.Count > 1)//其他情况
                    DescreaseTheItem(thisItem, BagManager.instance.WorkTwoBagItems);
                else
                {
                    Debug.Log("无法点击，不是原材料");
                }
            }
        }
        // 检查 CraftingGrid 是否存在
        if (CraftingGrid != null)
        {
            //if (thisItem.itemHeld>0)
            //工作台的物品添加  
            if (isWorkOne)
                AddCraftingNewItem(thisItem, BagManager.instance.WorkOneBagItems);
            else
            {
                if (CraftingBag.itemList.Count == 0 && thisItem.itemType == Item.ItemType.Fabric)
                {
                    AddCraftingNewItem(thisItem, BagManager.instance.WorkTwoBagItems);//正在制作衣服
                }
                else if (CraftingBag.itemList.Count == 1 && thisItem.itemType == Item.ItemType.Thread)
                {
                    AddCraftingNewItem(thisItem, BagManager.instance.WorkTwoBagItems);//正在制作衣服
                }
                else if (CraftingBag.itemList.Count > 1)//其他情况
                    AddCraftingNewItem(thisItem, BagManager.instance.WorkTwoBagItems);//正在制作衣服
                else
                {
                    Debug.Log("这个地方必须放入指定物品！");
                }
            }
           
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
    //切换页签  0=布  1=线  2=染料
    public void Switch(int index)
    {
        Debug.Log("index"+index);
        for(int i = 0; i < buttons.Length; i++)
        {
            Debug.Log("壁了" + index);
            //buttons[i].transform.GetChild(0).gameObject.SetActive(false);
            crafting[i].SetActive(false);
            //buttons[i].GetComponent<Image>().color = new Color(1,1,1,1);
            buttons[i].GetComponent<RectTransform>().localScale = new Vector2(1f, 1f);
            buttons[i].GetComponent<Image>().sprite = imageInitial[i];
        }
        //buttons[index].transform.GetChild(0).gameObject.SetActive(true);
        // 播放切换动画
        PlayTransitionAnimation(currentIndex, index);
        // 更新当前索引
        currentIndex = index;


        crafting[index].SetActive(true);
        //buttons[index].GetComponent<Image>().color = new Color(175f / 255f, 175f / 255f, 175f / 255f, 1);
        buttons[index].GetComponent<RectTransform>().localScale = new Vector2(1.2f,1.2f);
        buttons[index].GetComponent<Image>().sprite = image[index];
    }
    private void PlayTransitionAnimation(int fromIndex, int toIndex)
    {
            transitionAnimators.Play(fromIndex+"to"+toIndex);
    }
    //点击按钮合成布
    public void Craft1()
    {
       
        if(CraftingBag.itemList.Count == 5)
        {
           
            //XY:Item是引用类型，只能自己创建新的，不能直接使用。由于没有表文件，因此在代码里根据配方，编写合成路径
            Item result = new Item();
            //如果是合成布，生成结果进工作台背包2
            int hemu = 0;
            int basi = 0;
            int zishan = 0;
            int jiaoma = 0;

            int qulityTotal = 0;//总品质

            for (int i = 0; i < CraftingBag.itemList.Count; i++)
            {
             if (CraftingBag.itemList[i].itemName=="赫姆棉")
                {
                    hemu++;
                }
             else if (CraftingBag.itemList[i].itemName == "巴斯棉")
                {
                    basi++;
                }
                else if (CraftingBag.itemList[i].itemName == "紫杉苎麻")
                {
                    zishan++;
                }
                else if (CraftingBag.itemList[i].itemName == "蕉麻")
                {
                    jiaoma++;
                }
                qulityTotal += CraftingBag.itemList[i].quality;
            }
            result.itemHeld = 1;
            if (hemu == 5)
            {
                //合成赫姆棉布，需要添加其他信息在这写
                result.itemName = "赫姆棉布";
                result.itemType = Item.ItemType.Fabric;
                result.quality = qulityTotal / CraftingBag.itemList.Count;
                result.itemImage = Resources.Load<Sprite>("fabric1");//临时图片
                result.itemInfo = "赫姆棉布 百分百的赫姆棉制成的布料。";
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else if (basi == 5)
            {
                //合成巴斯棉布，需要添加其他信息在这写
                result.itemName = "巴斯棉布";
                result.itemType = Item.ItemType.Fabric;
                result.quality = qulityTotal / CraftingBag.itemList.Count;
                result.itemImage = Resources.Load<Sprite>("fabric2");//临时图片
                result.itemInfo = "巴斯棉布 百分百的巴斯棉制成的布料。";
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else if (hemu == 3 && basi == 2)
            {
                //合成混合棉布，需要添加其他信息在这写
                result.itemName = "混合棉布";
                result.itemType = Item.ItemType.Fabric;
                result.quality = qulityTotal / CraftingBag.itemList.Count;
                result.itemImage = Resources.Load<Sprite>("fabric5");//临时图片
                result.itemInfo = "混合棉布 赫姆棉与巴斯棉混纺成的布料。";
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else if (zishan == 5)
            {
                //合成紫杉麻布，需要添加其他信息在这写
                result.itemName = "紫杉麻布";
                result.itemType = Item.ItemType.Fabric;
                result.quality = qulityTotal / CraftingBag.itemList.Count;
                result.itemImage = Resources.Load<Sprite>("fabric3");//临时图片
                result.itemInfo = "紫杉麻布 百分百的紫杉麻制成的布料。";
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else if (jiaoma == 5)
            {
                //合成蕉麻布，需要添加其他信息在这写
                result.itemName = "蕉麻布";
                result.itemType = Item.ItemType.Fabric;
                result.quality = qulityTotal / CraftingBag.itemList.Count;
                result.itemImage = Resources.Load<Sprite>("fabric4");//临时图片
                result.itemInfo = "蕉麻布 百分百的蕉麻制成的布料。";
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else if (zishan == 3 && jiaoma == 2)
            {
                //合成混合麻布，需要添加其他信息在这写
                result.itemName = "混合麻布";
                result.itemType = Item.ItemType.Fabric;
                result.quality = qulityTotal / CraftingBag.itemList.Count;
                result.itemImage = Resources.Load<Sprite>("fabric6");//临时图片
                result.itemInfo = "混合麻布 紫杉苎麻和蕉麻混纺成的布料。";
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else if (hemu == 1 && basi == 1 && zishan == 1 && jiaoma == 2)
            {
                //合成棉麻布，需要添加其他信息在这写
                result.itemName = "棉麻布";
                result.itemType = Item.ItemType.Fabric;
                result.quality = qulityTotal / CraftingBag.itemList.Count;
                result.itemImage = Resources.Load<Sprite>("fabric7");//临时图片
                result.itemInfo = "棉麻布 棉麻混纺成的布料。";
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else
            {
                //合成失败
                //合成失败的UI表现写在这
                print("不能合成");
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
    //点击按钮合成线
    public void Craft2()
    {

        if (CraftingBag.itemList.Count == 5)
        {

            //XY:Item是引用类型，只能自己创建新的，不能直接使用。由于没有表文件，因此在代码里根据配方，编写合成路径
            Item result = new Item();
            //，生成结果进工作台背包2
            int fengzhi = 0;
            int xingrong = 0;
            int shuangjing = 0;
            int chilin = 0;

            int qulityTotal = 0;//总品质
            int specialityCount = 0;//特性数值
            for (int i = 0; i < CraftingBag.itemList.Count; i++)
            {
                if (CraftingBag.itemList[i].itemName == "风织花")
                {
                    fengzhi++;
                }
                else if (CraftingBag.itemList[i].itemName == "星绒草")
                {
                    xingrong++;
                }
                else if (CraftingBag.itemList[i].itemName == "霜晶莲")
                {
                    shuangjing++;
                }
                else if (CraftingBag.itemList[i].itemName == "炽鳞草")
                {
                    chilin++;
                }
                qulityTotal += CraftingBag.itemList[i].quality;
            }
            result.itemHeld = 1;
            if (fengzhi == 3&&xingrong==2)
            {
                //合成风织线，需要添加其他信息在这写
                result.itemName = "风织线";
                result.itemType = Item.ItemType.Thread;
                result.quality = qulityTotal / CraftingBag.itemList.Count;
                result.itemImage = Resources.Load<Sprite>("thread1");//临时图片
                result.itemSpeciality = Item.ItemSpeciality.Dexterity;
                result.specialityCount = 30;//特性固定，需修改在这写公式即可
                result.itemInfo = "风织线 极其轻柔，放在手中好似不存在一般，但如果用力拉扯会发现怎样都不会断。";
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else if (xingrong == 5)
            {
                //合成星绒线，需要添加其他信息在这写
                result.itemName = "星绒线";
                result.itemType = Item.ItemType.Thread;
                result.quality = qulityTotal / CraftingBag.itemList.Count;
                result.itemImage = Resources.Load<Sprite>("thread2");//临时图片
                result.itemSpeciality = Item.ItemSpeciality.Shine;
                result.specialityCount = 50;//特性固定，需修改在这写公式即可
                result.itemInfo = "星绒线 发出淡淡的光芒，在夜晚尤其明显。";
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else if (shuangjing == 3 && xingrong == 2)
            {
                //合成霜晶莲线，需要添加其他信息在这写
                result.itemName = "霜晶莲线";
                result.itemType = Item.ItemType.Thread;
                result.quality = qulityTotal / CraftingBag.itemList.Count;
                result.itemImage = Resources.Load<Sprite>("thread3");//临时图片
                result.itemSpeciality = Item.ItemSpeciality.Ice;
                result.specialityCount = 30;//特性固定，需修改在这写公式即可
                result.itemInfo = "霜晶莲线 握在手中冰冰凉凉，晶莹剔透。";
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else if (chilin == 3&& xingrong==2)
            {
                //合成炽鳞线，需要添加其他信息在这写
                result.itemName = "炽鳞线";
                result.itemType = Item.ItemType.Thread;
                result.quality = qulityTotal / CraftingBag.itemList.Count;
                result.itemImage = Resources.Load<Sprite>("thread4");//临时图片
                result.itemSpeciality = Item.ItemSpeciality.Fire;
                result.specialityCount = 30;//特性固定，需修改在这写公式即可
                result.itemInfo = "炽鳞线 质感硬硬的，温度比一般的线要高不少，就像在燃烧一样。";
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
        
            else
            {
                //合成失败
                //合成失败的UI表现写在这
                print("不能合成");
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
    //点击按钮合成染料
    public void Craft3()
    {

        if (CraftingBag.itemList.Count == 5)
        {

            //XY:Item是引用类型，只能自己创建新的，不能直接使用。由于没有表文件，因此在代码里根据配方，编写合成路径
            Item result = new Item();
            //，生成结果进工作台背包2
            int tiancai = 0;
            int diedou = 0;
            int huluo = 0;
            int lingtan = 0;
            int caifu = 0;
          
            for (int i = 0; i < CraftingBag.itemList.Count; i++)
            {
                if (CraftingBag.itemList[i].itemName == "甜菜根")
                {
                    tiancai++;
                }
                else if (CraftingBag.itemList[i].itemName == "蝶豆花")
                {
                    diedou++;
                }
                else if (CraftingBag.itemList[i].itemName == "胡萝卜")
                {
                    huluo++;
                }
                else if (CraftingBag.itemList[i].itemName == "灵碳素")
                {
                    lingtan++;
                }
                else if (CraftingBag.itemList[i].itemName == "彩蝠的分泌液")
                {
                    caifu++;
                }

            }
            result.itemHeld = 1;
            if (tiancai == 5)
            {
                //合成红色染剂，需要添加其他信息在这写
                result.itemName = "红色染剂";
                result.itemType = Item.ItemType.Dye;
             
                result.itemImage = Resources.Load<Sprite>("dye1");//临时图片
                result.itemColor = Item.ItemColor.Red;
                result.fashion = 25;
                result.itemInfo = "红色染剂 能够将衣物染成红色。";
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else if (diedou == 5)
            {
                //合成蓝色染剂，需要添加其他信息在这写
                result.itemName = "蓝色染剂";
                result.itemType = Item.ItemType.Dye;
             
                result.itemImage = result.itemImage = Resources.Load<Sprite>("dye2");//临时图片
                result.itemColor = Item.ItemColor.Bule;
                result.fashion = 30;
                result.itemInfo = "蓝色染剂 能够将衣物染成蓝色。";
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else if (huluo ==5)
            {
                //合成黄色染剂，需要添加其他信息在这写
                result.itemName = "黄色染剂";
                result.itemType = Item.ItemType.Dye;
              
                result.itemImage = result.itemImage = Resources.Load<Sprite>("dye3");//临时图片
                result.itemColor = Item.ItemColor.Yellow;
                result.fashion = 20;
                result.itemInfo = "黄色染剂 能够将衣物染成黄色。";
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else if (lingtan == 5)
            {
                //合成黑色染剂，需要添加其他信息在这写
                result.itemName = "黑色染剂";
                result.itemType = Item.ItemType.Dye;
                
                result.itemImage = result.itemImage = Resources.Load<Sprite>("dye4");//临时图片
                result.itemColor = Item.ItemColor.Black;
                result.fashion = 40;
                result.itemInfo = "黑色染剂 能够将衣物染成黑色。";
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
            else if (caifu == 5)
            {
                //合成炫彩染剂，需要添加其他信息在这写
                result.itemName = "炫彩染剂";
                result.itemType = Item.ItemType.Dye;
              
                result.itemImage = result.itemImage = Resources.Load<Sprite>("dye5");//临时图片
                result.itemColor = Item.ItemColor.Colors;
                result.fashion = 60;
                result.itemInfo = "炫彩染剂 能够将衣物染成彩色。";
                AddNewItem(result, BagManager.instance.WorkTwoBag, BagManager.instance.WorkTwoBagItems);

            }
          
            else
            {
                //合成失败
                //合成失败的UI表现写在这
                print("不能合成");
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
    //点击按钮合成衣服
    public void Craft4()
    {
       
        if (CraftingBag.itemList.Count == 5)
        {

            //XY:Item是引用类型，只能自己创建新的，不能直接使用。由于没有表文件，因此在代码里根据配方，编写合成路径
            Item result = new Item();
            //如果是合成衣服，生成结果进其他背包
           
            int qulityTotal = 0;//品质
            int specialityCount = 0;//特性数值
            int fashion = 0;//时尚


            bool isF = false;//是否有布
            bool isT = false;//是否有线
            for (int i = 0; i < CraftingBag.itemList.Count; i++)
            {
               if(CraftingBag.itemList[i].itemType==Item.ItemType.Fabric || CraftingBag.itemList[i].itemType == Item.ItemType.Thread)
                qulityTotal += CraftingBag.itemList[i].quality;

                if (CraftingBag.itemList[i].itemType == Item.ItemType.Decorate || CraftingBag.itemList[i].itemType == Item.ItemType.Thread)
                    specialityCount += CraftingBag.itemList[i].specialityCount;

                if (CraftingBag.itemList[i].itemType == Item.ItemType.Decorate || CraftingBag.itemList[i].itemType == Item.ItemType.Dye)
                    fashion += CraftingBag.itemList[i].fashion;

                if (CraftingBag.itemList[0].itemType == Item.ItemType.Fabric)
                    isF = true;//第一个是布

                if (CraftingBag.itemList[1].itemType == Item.ItemType.Thread)
                    isT = true;//第二个是线
            }
            result.itemHeld = 1;
            if (isF&&isT)
            {
                //合成衣服，需要添加其他信息在这写
                result.itemName = "衣服";
                result.itemType = Item.ItemType.Cloth;
                result.quality = qulityTotal;
                result.itemImage = CraftingBag.itemList[0].itemImage;//临时图片
                result.specialityCount = specialityCount;
                result.fashion = fashion;
                result.money = qulityTotal * 5 + specialityCount * 3 + fashion * 2;
                AddNewClothesItem(result, saleBag);//衣服放哪个背包在这可以修改，目前放售卖背包
                //合成之后销毁
                int childCount1 = CraftingGrid.transform.childCount;
                for (int i = 0; i < childCount1; i++)
                {
                    Destroy(CraftingGrid.transform.GetChild(i).gameObject);
                }
                //销毁 CraftingGrid2 的子物体
                int childCount2 = CraftingGrid2.transform.childCount;
                for (int i = 0; i < childCount2; i++)
                {
                    Destroy(CraftingGrid2.transform.GetChild(i).gameObject);
                }
                CraftingBag.itemList.Clear();
                //合成成功衣服衣服的动画播放
                player.SetActive(false);//主角消失
                CraftingPanel.SetActive(false);//UI消失
                Scene otherScene = SceneManager.GetSceneByName("ClothesStore");
                foreach (GameObject obj in otherScene.GetRootGameObjects())
                {
                    // 找到你要激活的GameObject
                    if (obj.CompareTag("workTwoBG"))
                    {
                        work2BG = obj;
                        // 激活GameObject
                        obj.SetActive(true);
                        break;
                    }
                }
                animator.enabled = true;//激活背景和动画
                PlayAnimation("working_01");//播放哪个动画
                //AddNewClothesItem(result, BagManager.instance.SaleBag);//衣服放哪个背包在这可以修改，目前放售卖背包
                //AddNewClothesItem(result, saleBag);//衣服放哪个背包在这可以修改，目前放售卖背包
            }
            else
            {
                //合成失败
                //合成失败的UI表现写在这
                print("不能合成");
                return;
            }
           //合成之后销毁
            /*for (int i = 0; i < CraftingGrid.transform.childCount; i++)
            {
                if (CraftingGrid.transform.childCount == 0)
                    break;
                Destroy(CraftingGrid.transform.GetChild(i).gameObject);
            }
            for (int i = 0; i < CraftingGrid2.transform.childCount; i++)
            {
                if (CraftingGrid2.transform.childCount == 0)
                    break;
                Destroy(CraftingGrid2.transform.GetChild(i).gameObject);
            }
            CraftingBag.itemList.Clear();*/
        }
    }
    public void PlayAnimation(string animationName)
    {
        animator.Play(animationName);
    }

    // 停止当前正在播放的动画
    public void StopAnimation()
    {
        work2BG.SetActive(false);
        animator.enabled = false; // 禁用Animator组件以停止动画播放
        CraftingPanel.SetActive(true);
        player.SetActive(true);
        player.transform.position = new Vector3(9.07f, -0.64f, 0);
        animatorPlayer.SetTrigger("juqi");
        StartCoroutine(SHINE());
    }
    IEnumerator SHINE()
    {
        shiningg.gameObject.SetActive(true);
        shiningg.Play("shining");
        yield return new WaitForSeconds(shiningg.GetCurrentAnimatorStateInfo(0).length);
        animatorPlayer.SetTrigger("bujuqi");
        shiningg.gameObject.SetActive(false);
    }
    public void StopAnimationShine()
    {
        animatorPlayer.SetTrigger("bujuqi");
        shiningg.enabled = false;
        shiningg.gameObject.SetActive(false);
    }
    public void DescreaseTheItem(Item thisItem, Dictionary<string, Item> bagItems)
    {
            bagItems[thisItem.itemName].itemHeld -= 1;
        if (bagItems[thisItem.itemName].itemHeld <= 0)
        {
            //等于0的时候销毁
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
    public void AddNewItem(Item thisItem,bag bag, Dictionary<string, Item> bagItems=null)//XY:使用bag传参传入指定背包
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
                // Mybag.itemList.Add(thisItem);//这个物品添加到这个包里面
                //   USE_Bag.itemList.Add(thisItem);//这个物品添加到这个包里面
                bag.itemList.Add(thisItem);//这个物品添加到这个包里面
                                           //BagManager.CreateNewItem(thisItem);
            }
            else
            {
                thisItem.itemHeld += 1;
            }
            BagManager.RefreshItem();
            BagManager.RefreshUSEItem();
            BagManager.RefreshSaleItem();
            if (isWorkOne)
                BagManager.RefreshWorkOneItemXY();
            else
                BagManager.RefreshWorkTwoItemXY();
            Destroy(newItem.gameObject);
        });
     
    }
    public void AddNewClothesItem(Item thisItem, bag bag, Dictionary<string, Item> bagItems = null)//XY:使用bag传参传入指定背包
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
            {
                bagItems.Remove(thisItem.itemName);
            }
        }
            if (!bag.itemList.Contains(thisItem))
            {
                bag.itemList.Add(thisItem);//这个物品添加到这个包里面
                                           //BagManager.CreateNewItem(thisItem);
            }
            else
            {
                thisItem.itemHeld += 1;
            }
            BagManager.RefreshItem();
            BagManager.RefreshUSEItem();
            BagManager.RefreshSaleItem();
            if (isWorkOne)
                BagManager.RefreshWorkOneItemXY();
            else
                BagManager.RefreshWorkTwoItemXY();    
    }
}
