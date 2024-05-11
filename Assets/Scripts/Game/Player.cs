using UnityEngine;
using UnityEngine.Tilemaps;
using QFramework;
using UnityEngine.UI;
namespace YouChuangThree
{
	public partial class Player : ViewController
	{
		public Grid Grid;//����
		public Tilemap Tilemap;//ԭʼ����
        public Tilemap WaterTilemap;//��ˮde��ء�  
        private Animator animator;//����
        public Animator actionAnimator;//��Ϊ�Ķ���

        public Text bloodText;//������
        public int Dohole=4;//�������ĵľ���
        public int water = 4;//��ˮ���ĵľ���
        public int grow = 4;//��ֲ�������ĵľ���
        public GameObject[] KuangText;
        public bag USE_Bag;//����1-9��ť����Ӧ����Ʒ
        int Kuang = 0;//���µ����ֶ�Ӧ�ĸ���

        public static int flag = 1;//�����һ�θ���
    
       
    void Start()
		{
            animator = GetComponent<Animator>();
        }
        private void Update()
        {
            GameObject gridObject = GameObject.FindGameObjectWithTag("grid");
            if (gridObject != null)
            {
                Grid = gridObject.GetComponent<Grid>();
            }
            GameObject tilemapObject = GameObject.FindGameObjectWithTag("tilemap");
            if (tilemapObject != null)
            {
                Tilemap = tilemapObject.GetComponent<Tilemap>();
            }
            GameObject watermapObject = GameObject.FindGameObjectWithTag("watermap");
            if (watermapObject != null)
            {
                WaterTilemap = watermapObject.GetComponent<Tilemap>();
            }
            var cellPosition = Grid.WorldToCell(transform.position);
            var cellwaterPosition = Grid.WorldToCell(transform.position);
            if (Input.GetKeyDown(KeyCode.J) && flag == 1)
            {
                if (Tilemap.GetTile(cellPosition) != null)
                {
                    Tilemap.SetTile(cellPosition, tile: null);
                    bloodText.text = (int.Parse(bloodText.text) - Dohole).ToString();
                }
                else
                {
                    Item item = USE_Bag.itemList[Kuang];
                    if (WaterTilemap.GetTile(cellwaterPosition) != null)
                    {
                        Debug.Log("5555");
                        WaterTilemap.SetTile(cellwaterPosition, tile: null);
                        bloodText.text = (int.Parse(bloodText.text) - water).ToString();
                        animator.SetTrigger("isWater");
                        actionAnimator.SetTrigger("water");
                    }
                    else if (item != null && Tilemap.GetTile(cellwaterPosition) == null)
                    {
                        if (item.grow == true)
                        {
                            Instantiate(item.prefab, Tilemap.GetCellCenterWorld(cellPosition), Quaternion.identity);
                            item.itemHeld -= 1;
                            bloodText.text = (int.Parse(bloodText.text) - grow).ToString();//�����˾���ֵ
                            flag = 2;//��һ�ν̳���ֲ���
                            PlayerPrefs.SetInt("intFlag", 1);
                            BagManager.RefreshItem();
                            BagManager.RefreshUSEItem();
                        }
                    }
                }
            }
             else if (Input.GetKeyDown(KeyCode.J)&&flag==2)
            {
                if (Tilemap.GetTile(cellPosition) != null)
                {
                    Tilemap.SetTile(cellPosition, tile: null);
                    bloodText.text = (int.Parse(bloodText.text) - Dohole).ToString();
                }
                else
                {
                    Item item = USE_Bag.itemList[Kuang];
                    if (WaterTilemap.GetTile(cellwaterPosition) != null)
                    {
                        Debug.Log("5555");
                        WaterTilemap.SetTile(cellwaterPosition, tile: null);
                        bloodText.text = (int.Parse(bloodText.text) - water).ToString();
                        animator.SetTrigger("isWater");
                        actionAnimator.SetTrigger("water");
                    }
                    else if (item != null&& Tilemap.GetTile(cellwaterPosition) == null)
                    {
                        if (item.grow == true)
                        {
                            Instantiate(item.prefab, Tilemap.GetCellCenterWorld(cellPosition), Quaternion.identity);
                            item.itemHeld -= 1;
                            bloodText.text = (int.Parse(bloodText.text) - grow).ToString();//�����˾���ֵ
                            BagManager.RefreshItem();
                            BagManager.RefreshUSEItem();
                        }
                    }
                }
             
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ActivateGameObjectAtIndex(0);
                Kuang = 0;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ActivateGameObjectAtIndex(1);
                Kuang = 1;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ActivateGameObjectAtIndex(2);
                Kuang = 2;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                ActivateGameObjectAtIndex(3);
                Kuang = 3;
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                ActivateGameObjectAtIndex(4);
                Kuang = 4;
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                ActivateGameObjectAtIndex(5);
                Kuang = 5;
            }
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                ActivateGameObjectAtIndex(6);
                Kuang = 6;
            }
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                ActivateGameObjectAtIndex(7);
                Kuang = 7;
            }
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                ActivateGameObjectAtIndex(8);
                Kuang = 8;
            }
        }
        void ActivateGameObjectAtIndex(int index)
        {
            for (int i = 0; i < KuangText.Length; i++)
            {
                if (i == index)
                {
                    KuangText[i].SetActive(true); // ����Ŀ��GameObject
                }
                else
                {
                    KuangText[i].SetActive(false); // �ر�����GameObject
                }
            }
        }
    }
}
