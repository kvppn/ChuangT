using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class tile : MonoBehaviour
{
    public bool isPlowed = false; // 地块是否已耕种
    public bool isWatered = false; // 地块是否已浇水
    public bool isPlanted = false; // 地块是否已种植种子了
                                   //public GameObject seedPrefab; // 种子预制体
    //public GameObject maturePlantPrefab; // 成熟的植物预制体
    public GameObject currentPlantPrefab; // 当前种植的植物预制体
    //public GameObject growingPlantPrefab; // 当前种植的植物预制体
    public GameObject growedtPlantPrefab; // 当前种植的植物成熟预制体
    public Sprite powedSprite; // 浇水后的图片
    public Sprite wateredSprite; // 浇水后的图片
    public GameObject Kuang;
    public bool playerInRange = false;//主角是否在npc的碰撞范围内

    public GameObject[] KuangText;
    public bag USE_Bag;//按下1-9按钮，对应的物品
    int KuangNum = 0;//按下的数字对应哪个框

    public static int flag = 1;//代表第一次耕种

    public Text daytext;//引用天数
    public  int plantStartTime = 0;//植物被播种开始的时间
    public int timeToGrow=1;//半成长的天数
    //public int timeToMature=2;//
    public static int daysPassed=0;//经过的天数

    private Animator animator;//人物的动画

    public int intFlag;
    void Start()
    { 
        string objectIdentifier = gameObject.name;
        daytext = (GameObject.FindGameObjectWithTag("daytext")).GetComponent<Text>();
        KuangText = GameObject.FindGameObjectsWithTag("kuang");
        animator = GameObject.FindGameObjectWithTag("player").GetComponent<Animator>();
 
        if (PlayerPrefs.GetInt("DataInitialized"+ objectIdentifier) ==0)//判断耕地是否初始)
        {
            InitializeData();
            PlayerPrefs.SetInt("DataInitialized"+ objectIdentifier, 1);
        }
        else
        {
            LoadData();
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            playerInRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            playerInRange = false;
        }
    }
    // 实现接口的方法
    void OnMouseOver()//鼠标悬浮于按钮之上，按钮颜色变化
    {
        if (playerInRange == true)
        {
            Kuang.SetActive(true);
        }
    }

    private void OnMouseExit()//鼠标离开按钮上方，按钮颜色复位
    {
        Kuang.SetActive(false);
    }

     void Update()
    {
        intFlag = PlayerPrefs.GetInt("intFlag");
        Debug.Log("时间过去了"+ (int.Parse(daytext.text) - plantStartTime));
        
        // 计算种植时间经过的天数
        daysPassed = int.Parse(daytext.text) - plantStartTime;
        //右键操作
        if (Input.GetMouseButtonDown(1) )
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int layerMask = 1 << LayerMask.NameToLayer("Default");
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, layerMask);
            Debug.Log(hit.collider.name);
            if (hit.collider != null && hit.collider == gameObject.GetComponent<Collider2D>() && playerInRange == true &&flag==1&&intFlag==3)
            {
                //第一次种植
                //如果点击了这个地块
                Debug.Log("点击了.");
                MouseDown0();
            }
            else if(hit.collider != null && hit.collider == gameObject.GetComponent<Collider2D>() && playerInRange == true && flag==2&&intFlag==2)
            {
                //第二次种植
                Debug.Log("点击了.");
                MouseDown();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateGameObjectAtIndex(0);
            KuangNum = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivateGameObjectAtIndex(1);
            KuangNum = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActivateGameObjectAtIndex(2);
            KuangNum = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ActivateGameObjectAtIndex(3);
            KuangNum = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ActivateGameObjectAtIndex(4);
            KuangNum = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            ActivateGameObjectAtIndex(5);
            KuangNum = 5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            ActivateGameObjectAtIndex(6);
            KuangNum = 6;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            ActivateGameObjectAtIndex(7);
            KuangNum = 7;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            ActivateGameObjectAtIndex(8);
            KuangNum = 8;
        }
    }
    void ActivateGameObjectAtIndex(int index)
    {
        for (int i = 0; i < KuangText.Length; i++)
        {
            if (i == index)
            {
                KuangText[i].GetComponent<Image>().enabled=true ; // 激活目标GameObject
            }
            else
            {
                KuangText[i].GetComponent<Image>().enabled = false;
            }
        }
    }
    public void MouseDown0()
    {
        if (isPlanted == true)
        {
            Debug.Log("genzhonggenzhong");
        }
        if (!isPlowed)
        {
            // 耕种
            isPlowed = true;
            animator.SetTrigger("isAction");
            GetComponent<SpriteRenderer>().sprite = powedSprite;
            SaveData(); // 保存数据
        }
        else
        {
            Item item = USE_Bag.itemList[KuangNum];
            if (!isPlanted)
            {
                Debug.Log("genzhonggenzhong");
                //如果没有种植则种植
                if (item.grow == true)
                {
                    //计算种植时间
                    plantStartTime = int.Parse(daytext.text);
                    //
                    isPlanted = true;
                    animator.SetTrigger("isAction");
                    Instantiate(item.prefab,transform.position, Quaternion.identity).transform.parent = transform;
                    currentPlantPrefab = item.prefab; // 设置当前种植的植物预制体
                    
                    growedtPlantPrefab = item.growed;//成熟状态

                    SaveData(); // 保存数据
                    item.itemHeld -= 1;
                    //bloodText.text = (int.Parse(bloodText.text) - grow).ToString();//消耗了精力值
                    BagManager.RefreshItem();
                    BagManager.RefreshUSEItem();
                  
                }
            }
            else
            {
                //如果种植了，则浇水
                isWatered = true;
                animator.SetTrigger("isAction");
                GetComponent<SpriteRenderer>().sprite = wateredSprite;
                SaveData(); // 保存数据
                flag = 2;//第一次教程种植完毕
                PlayerPrefs.SetInt("intFlag", 1);//第一次种植完毕
            }
        }
    }
 
    public void MouseDown()
    {
        if (!isPlowed)
        {
            // 耕种
            isPlowed = true;
            animator.SetTrigger("isAction");
            GetComponent<SpriteRenderer>().sprite = powedSprite;
            SaveData(); // 保存数据
        }
        else
        {
            Item item = USE_Bag.itemList[KuangNum];
            if (!isPlanted)
            {
                //如果没有种植则种植
                if (item.grow == true)
                {
                    //计算种植时间
                    plantStartTime = int.Parse(daytext.text);
                    isPlanted = true;
                    animator.SetTrigger("isAction");
                    currentPlantPrefab = item.prefab; // 设置当前种植的植物预制体
                    growedtPlantPrefab = item.growed;//成熟状态
                    
                    Instantiate(item.prefab, gameObject.transform.position, Quaternion.identity).transform.parent = transform;
                    SaveData(); // 保存数据
                    item.itemHeld -= 1;
                    //bloodText.text = (int.Parse(bloodText.text) - grow).ToString();//消耗了精力值
                    BagManager.RefreshItem();
                    BagManager.RefreshUSEItem();

                }
            }
            else if(isPlanted&&!isWatered)
            {
                //如果种植了，则浇水
                isWatered = true;
                animator.SetTrigger("isAction");
                GetComponent<SpriteRenderer>().sprite = wateredSprite;
                SaveData(); // 保存数据
            }
        }
    }
    private void SaveData()
    {
        // 保存地块状态信息
        PlayerPrefs.SetInt("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_Plowed", isPlowed ? 1 : 0);
        PlayerPrefs.SetInt("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_Planted", isPlanted ? 1 : 0);
        PlayerPrefs.SetInt("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_Watered", isWatered ? 1 : 0);
        // 保存种植的植物预制体信息
        PlayerPrefs.SetString("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_PlantPrefab", currentPlantPrefab != null ? currentPlantPrefab.name : "");
        //PlayerPrefs.SetString("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_PlantPrefab2", growingPlantPrefab != null ? growingPlantPrefab.name : "");
        PlayerPrefs.SetString("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_PlantPrefab3", growedtPlantPrefab != null ? growedtPlantPrefab.name : "");
        PlayerPrefs.SetInt("PlantStartTime_" + transform.position.x.ToString() + "_" + transform.position.y.ToString(), plantStartTime);
    }
    private void LoadData()
    {
        // 加载地块状态信息
        isPlowed = PlayerPrefs.GetInt("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_Plowed", 0) == 1;
        isPlanted = PlayerPrefs.GetInt("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_Planted", 0) == 1;
        isWatered = PlayerPrefs.GetInt("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_Watered", 0) == 1;

        // 加载每个地块的 plantStartTime 信息
        plantStartTime = PlayerPrefs.GetInt("PlantStartTime_" + transform.position.x.ToString() + "_" + transform.position.y.ToString(), 0);

        // 计算种植时间经过的天数
        //daysPassed = int.Parse(daytext.text) - plantStartTime;
        // 根据加载的状态更新地块外观
        Debug.Log("加载时间过去了" + daysPassed);
        if (isPlowed&&!isWatered)
        {
            GetComponent<SpriteRenderer>().sprite = powedSprite;
        }
        if (isWatered)
        {
            GetComponent<SpriteRenderer>().sprite = wateredSprite;
        }

        // 加载种植的植物预制体信息
        string plantPrefabName = PlayerPrefs.GetString("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_PlantPrefab", "");
        string growedPrefabName = PlayerPrefs.GetString("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_PlantPrefab3", "");

        /*if (!string.IsNullOrEmpty(plantPrefabName))
        {*/
            currentPlantPrefab = Resources.Load<GameObject>("Perfab/"+ plantPrefabName);
  
            growedtPlantPrefab  = Resources.Load<GameObject>("Perfab/" + growedPrefabName);
           /* if (currentPlantPrefab == null)
            {
                Debug.LogError("Failed to load plant prefab: " + plantPrefabName);
            }*/
        //}
        if (isPlanted)
        {
            // 实例化种植的植物预制体（如果已经种植）
            
            if ( daysPassed >= timeToGrow)
            {
                Instantiate(growedtPlantPrefab, transform.position, Quaternion.identity).transform.parent = transform;
            }
            else if (daysPassed < timeToGrow)
            {
                Instantiate(currentPlantPrefab, transform.position, Quaternion.identity).transform.parent = transform;
            }
        }
    }
    private void InitializeData()
    {
        // 初始化地块状态为未耕种、未种植、未浇水
        PlayerPrefs.SetInt("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_Plowed", 0);
        PlayerPrefs.SetInt("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_Planted", 0);
        PlayerPrefs.SetInt("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_Watered", 0);
        // 清空种植的植物预制体信息
        PlayerPrefs.SetString("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_PlantPrefab", "");
        PlayerPrefs.SetString("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_PlantPrefab3", "");
    }
    private void DestroyChildGameObject(string prefabName)
    {
        Debug.Log("遍历物体的子物体");
        // 遍历物体的子物体
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Debug.Log(" // 检查子物体是否为要摧毁的预制体");
            // 检查子物体是否为要摧毁的预制体
            if (child.name == prefabName)
            {
                Debug.Log("  // 销毁子物体");
                // 销毁子物体
                Destroy(child.gameObject);
                break; // 找到并销毁一个符合条件的子物体后，跳出循环
            }
        }
    }
}
