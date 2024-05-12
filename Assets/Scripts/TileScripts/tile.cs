using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class tile : MonoBehaviour
{
    public bool isPlowed = false; // �ؿ��Ƿ��Ѹ���
    public bool isWatered = false; // �ؿ��Ƿ��ѽ�ˮ
    public bool isPlanted = false; // �ؿ��Ƿ�����ֲ������
                                   //public GameObject seedPrefab; // ����Ԥ����
    //public GameObject maturePlantPrefab; // �����ֲ��Ԥ����
    public GameObject currentPlantPrefab; // ��ǰ��ֲ��ֲ��Ԥ����
    public GameObject growedtPlantPrefab; // ��ǰ��ֲ��ֲ�����Ԥ����
    public Sprite powedSprite; // ��ˮ���ͼƬ
    public Sprite wateredSprite; // ��ˮ���ͼƬ
    public GameObject Kuang;
    public bool playerInRange = false;//�����Ƿ���npc����ײ��Χ��

    public GameObject[] KuangText;
    public bag Bag;
    public bag USE_Bag;//����1-9��ť����Ӧ����Ʒ
    public bag WorkOne_Bag;
    int KuangNum = 0;//���µ����ֶ�Ӧ�ĸ���

    public static int flag = 1;//�����һ�θ���

    public Text daytext;//��������
    public  int plantStartTime = 0;//ֲ�ﱻ���ֿ�ʼ��ʱ��
    public int timeToGrow=1;//��ɳ�������
    //public static int daysPassed=0;//����������

    private Animator animator;//����Ķ���

    public int intFlag;

    public Blood bloody;
    void Start()
    {
        StartCoroutine(WaitForDayTextUpdate());
        /*string objectIdentifier = gameObject.name;
        daytext = (GameObject.FindGameObjectWithTag("daytext")).GetComponent<Text>();
        KuangText = GameObject.FindGameObjectsWithTag("kuang");
        animator = GameObject.FindGameObjectWithTag("player").GetComponent<Animator>();
        bloody= GameObject.FindGameObjectWithTag("bloody").GetComponent<Blood>();
        if (PlayerPrefs.GetInt("DataInitialized"+ objectIdentifier) ==0)//�жϸ����Ƿ��ʼ)
        {
            InitializeData();
            PlayerPrefs.SetInt("DataInitialized"+ objectIdentifier, 1);
        }
        else
        {
            LoadData();
            Debug.Log("ʱ������ɴ˴���곤᯳�������" + int.Parse(daytext.text));
        }*/
    }
    IEnumerator WaitForDayTextUpdate()
    {
        yield return new WaitForSeconds(0.01f); // �ȴ�0.1�룬���Ը�����Ҫ����
        string objectIdentifier = gameObject.name;
        daytext = (GameObject.FindGameObjectWithTag("daytext")).GetComponent<Text>();
        KuangText = GameObject.FindGameObjectsWithTag("kuang");
        animator = GameObject.FindGameObjectWithTag("player").GetComponent<Animator>();
        bloody = GameObject.FindGameObjectWithTag("bloody").GetComponent<Blood>();
        if (PlayerPrefs.GetInt("DataInitialized" + objectIdentifier) == 0)//�жϸ����Ƿ��ʼ)
        {
            InitializeData();
            PlayerPrefs.SetInt("DataInitialized" + objectIdentifier, 1);
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
    // ʵ�ֽӿڵķ���
    void OnMouseOver()//��������ڰ�ť֮�ϣ���ť��ɫ�仯
    {
        if (playerInRange == true)
        {
            Kuang.SetActive(true);
        }
    }

    private void OnMouseExit()//����뿪��ť�Ϸ�����ť��ɫ��λ
    {
        Kuang.SetActive(false);
    }

     void Update()
    {
       
        intFlag = PlayerPrefs.GetInt("intFlag");

        
        // ������ֲʱ�侭��������
        //daysPassed = int.Parse(daytext.text) - plantStartTime;
        //�Ҽ�����
        if (Input.GetMouseButtonDown(1) )
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int layerMask = 1 << LayerMask.NameToLayer("Default");
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, layerMask);
            Debug.Log(hit.collider.name);
            if (hit.collider != null && hit.collider == gameObject.GetComponent<Collider2D>() && playerInRange == true &&flag==1&&intFlag==3)
            {
                //��һ����ֲ
                //������������ؿ�
                Debug.Log("�����.");
                MouseDown0();
            }
            else if(hit.collider != null && hit.collider == gameObject.GetComponent<Collider2D>() && playerInRange == true && flag==2&&intFlag==2)
            {
                //�ڶ�����ֲ
                Debug.Log("�����.");
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
                KuangText[i].GetComponent<Image>().enabled=true ; // ����Ŀ��GameObject
            }
            else
            {
                KuangText[i].GetComponent<Image>().enabled = false;
            }
        }
    }
    public void MouseDown0()
    {
        string objectIdentifier = gameObject.name;
        if (isPlanted == true)
        {
            Debug.Log("genzhonggenzhong");
        }
        if (!isPlowed)
        {
            // ����
            bloody.decreseBlood(5);
            isPlowed = true;
            animator.SetTrigger("isAction");
            GetComponent<SpriteRenderer>().sprite = powedSprite;
            SaveData(); // ��������
        }
        else
        {
            Item item = USE_Bag.itemList[KuangNum];
            if (!isPlanted)
            {
                //���û����ֲ����ֲ
                if (item.grow == true)
                {
                    bloody.decreseBlood(5);
                    //������ֲʱ��
                    plantStartTime = int.Parse(daytext.text);
                    PlayerPrefs.SetInt("StartTime" + objectIdentifier, plantStartTime);//���濪ʼ������
                    //
                    isPlanted = true;
                    animator.SetTrigger("isAction");
                    Instantiate(item.prefab,transform.position, Quaternion.identity).transform.parent = transform;
                    currentPlantPrefab = item.prefab; // ���õ�ǰ��ֲ��ֲ��Ԥ����
                    
                    growedtPlantPrefab = item.growed;//����״̬

                    SaveData(); // ��������
                    //item.itemHeld -= 1;
                    //bloodText.text = (int.Parse(bloodText.text) - grow).ToString();//�����˾���ֵ
                    /*BagManager.RefreshItem();
                    BagManager.RefreshUSEItem();*/
                    DescreaseTheItem(item);
                  
                }
            }
            else
            {
                bloody.decreseBlood(5);
                //�����ֲ�ˣ���ˮ
                isWatered = true;
                animator.SetTrigger("isAction");
                GetComponent<SpriteRenderer>().sprite = wateredSprite;
                SaveData(); // ��������
                flag = 2;//��һ�ν̳���ֲ���
                PlayerPrefs.SetInt("intFlag", 1);//��һ����ֲ���
            }
        }
    }
 
    public void MouseDown()
    {
        string objectIdentifier = gameObject.name;
        if (!isPlowed)
        {
            bloody.decreseBlood(5);
            // ����
            isPlowed = true;
            animator.SetTrigger("isAction");
            GetComponent<SpriteRenderer>().sprite = powedSprite;
            SaveData(); // ��������
        }
        else
        {
            Item item = USE_Bag.itemList[KuangNum];
            if (!isPlanted)
            {
                //���û����ֲ����ֲ
                if (item.grow == true)
                {
                    bloody.decreseBlood(5);
                    //������ֲʱ��
                    plantStartTime = int.Parse(daytext.text);
                    PlayerPrefs.SetInt("StartTime" + objectIdentifier, plantStartTime);//���濪ʼ������
                    isPlanted = true;
                    animator.SetTrigger("isAction");
                    currentPlantPrefab = item.prefab; // ���õ�ǰ��ֲ��ֲ��Ԥ����
                    growedtPlantPrefab = item.growed;//����״̬
                    
                    Instantiate(item.prefab, gameObject.transform.position, Quaternion.identity).transform.parent = transform;
                    SaveData(); // ��������
                                //item.itemHeld -= 1;
                                //bloodText.text = (int.Parse(bloodText.text) - grow).ToString();//�����˾���ֵ
                    /* BagManager.RefreshItem();
                     BagManager.RefreshUSEItem();*/
                    DescreaseTheItem(item);

                }
            }
            else if(isPlanted&&!isWatered)
            {
                bloody.decreseBlood(5);
                //�����ֲ�ˣ���ˮ
                isWatered = true;
                animator.SetTrigger("isAction");
                GetComponent<SpriteRenderer>().sprite = wateredSprite;
                SaveData(); // ��������
            }
        }
    }
    public void DescreaseTheItem(Item thisItem)
    {

        thisItem.itemHeld -= 1;
        if (thisItem.itemHeld <= 0)
        {
            //����0��ʱ������
            Bag.itemList.Remove(thisItem);
            USE_Bag.itemList.Remove(thisItem);
            WorkOne_Bag.itemList.Remove(thisItem);
        }
        BagManager.RefreshItem();
        BagManager.RefreshUSEItem();
        BagManager.RefreshWorkOneItemXY();
    
    }
    private void SaveData()
    {
        // ����ؿ�״̬��Ϣ
        PlayerPrefs.SetInt("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_Plowed", isPlowed ? 1 : 0);
        PlayerPrefs.SetInt("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_Planted", isPlanted ? 1 : 0);
        PlayerPrefs.SetInt("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_Watered", isWatered ? 1 : 0);
        // ������ֲ��ֲ��Ԥ������Ϣ
        PlayerPrefs.SetString("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_PlantPrefab", currentPlantPrefab != null ? currentPlantPrefab.name : "");
        //PlayerPrefs.SetString("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_PlantPrefab2", growingPlantPrefab != null ? growingPlantPrefab.name : "");
        PlayerPrefs.SetString("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_PlantPrefab3", growedtPlantPrefab != null ? growedtPlantPrefab.name : "");
        PlayerPrefs.SetInt("PlantStartTime_" + transform.position.x.ToString() + "_" + transform.position.y.ToString(), plantStartTime);
    }
    private void LoadData()
    {
        string objectIdentifier = gameObject.name;
        // ���صؿ�״̬��Ϣ
        isPlowed = PlayerPrefs.GetInt("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_Plowed", 0) == 1;
        isPlanted = PlayerPrefs.GetInt("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_Planted", 0) == 1;
        isWatered = PlayerPrefs.GetInt("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_Watered", 0) == 1;

        // ����ÿ���ؿ�� plantStartTime ��Ϣ
        plantStartTime = PlayerPrefs.GetInt("PlantStartTime_" + transform.position.x.ToString() + "_" + transform.position.y.ToString(), 0);

        // ������ֲʱ�侭��������
        //daysPassed = int.Parse(daytext.text) - plantStartTime;
        // ���ݼ��ص�״̬���µؿ����
        //Debug.Log("����ʱ���ȥ��" + daysPassed);
        if (isPlowed&&!isWatered)
        {
            GetComponent<SpriteRenderer>().sprite = powedSprite;
        }
        if (isWatered)
        {
            GetComponent<SpriteRenderer>().sprite = wateredSprite;
        }

        // ������ֲ��ֲ��Ԥ������Ϣ
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
            // ʵ������ֲ��ֲ��Ԥ���壨����Ѿ���ֲ��
            Debug.Log("�Ҳ����谡������ʱ���ȥ������" + int.Parse(daytext.text));
            if (int.Parse(daytext.text)- PlayerPrefs.GetInt("StartTime" + objectIdentifier, plantStartTime) >= timeToGrow)
            {
                Instantiate(growedtPlantPrefab, transform.position, Quaternion.identity).transform.parent = transform;
            }
            else if (int.Parse(daytext.text) - PlayerPrefs.GetInt("StartTime" + objectIdentifier, plantStartTime) < timeToGrow)
            {
                Instantiate(currentPlantPrefab, transform.position, Quaternion.identity).transform.parent = transform;
            }
        }
    }
    private void InitializeData()
    {
        // ��ʼ���ؿ�״̬Ϊδ���֡�δ��ֲ��δ��ˮ
        PlayerPrefs.SetInt("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_Plowed", 0);
        PlayerPrefs.SetInt("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_Planted", 0);
        PlayerPrefs.SetInt("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_Watered", 0);
        // �����ֲ��ֲ��Ԥ������Ϣ
        PlayerPrefs.SetString("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_PlantPrefab", "");
        PlayerPrefs.SetString("Tile_" + transform.position.x.ToString() + "_" + transform.position.y.ToString() + "_PlantPrefab3", "");
    }
    private void DestroyChildGameObject(string prefabName)
    {
        Debug.Log("���������������");
        // ���������������
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Debug.Log(" // ����������Ƿ�ΪҪ�ݻٵ�Ԥ����");
            // ����������Ƿ�ΪҪ�ݻٵ�Ԥ����
            if (child.name == prefabName)
            {
                Debug.Log("  // ����������");
                // ����������
                Destroy(child.gameObject);
                break; // �ҵ�������һ�����������������������ѭ��
            }
        }
    }
}
