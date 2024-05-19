using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SaleSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    public Item slotItem;//格子中的物品
    public Image slotImage;//格子的图片
    public Text slotNum;//格子物品的数量
    public Text Saleinfo;
    public MoneyController money;
    static SaleSlot instance;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Saleinfo = GameObject.FindGameObjectWithTag("saleInfo").GetComponent<Text>();
        money = GameObject.FindGameObjectWithTag("money").GetComponent<MoneyController>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        UIcontrollerr.instance_.uitextobj.position = new Vector3(Input.mousePosition.x + 60, Input.mousePosition.y - 50, 0);
        UIcontrollerr.instance_.uitextobj.gameObject.SetActive(true);
        //UIcontrollerr.instance_.text.text = this.name;
    }
    //鼠标离开
    public void OnPointerExit(PointerEventData eventData)
    {
        UIcontrollerr.instance_.uitextobj.gameObject.SetActive(false);
    }
    //鼠标在ui里滑动
    public void OnPointerMove(PointerEventData eventData)
    {
        UIcontrollerr.instance_.uitextobj.position = new Vector3(Input.mousePosition.x + 60, Input.mousePosition.y - 50, 0);
        UIcontrollerr.instance_.uitextobj.gameObject.SetActive(true);
        //UIcontrollerr.instance_.text.text = this.name;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        // 点击左键
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("背电极");
            Saleinfo.text = slotItem.itemInfo;
            //按钮点击
            saleClothes.GetMoneyNum(slotItem.money);
        }
    }
    
}
