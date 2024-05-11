using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TreeController : MonoBehaviour
{
    private Animator animatorTree;
    private Animator playerAnimator;
    public bool playerInRange = false;//主角是否在npc的碰撞范围内

    public bool playerIswalking = false;

    private Text bloodText;//精力条

    public int KanBlood=1;
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
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("player");
        GameObject bloodObject = GameObject.FindGameObjectWithTag("blood");
        if (bloodObject != null)
        {
            bloodText = bloodObject.GetComponent<Text>();
            if (bloodText == null)
            {
                Debug.LogError("Player object does not have an Text component");
            }
        }
        else
        {
            Debug.LogError("Player object not found in the scene");
        }
        if (playerObject != null)
        {
            playerAnimator = playerObject.GetComponent<Animator>();
            if (playerAnimator == null)
            {
                Debug.LogError("Player object does not have an Animator component");
            }
        }
        else
        {
            Debug.LogError("Player object not found in the scene");
        }
        animatorTree = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        AnimatorStateInfo stateInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);
        if (Input.GetMouseButtonDown(1)) // 检测鼠标右键点击
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null && hit.collider == GetComponent<Collider2D>() && playerInRange == true)
            {
                animatorTree.SetTrigger("Tree");
                if (stateInfo.IsName("idle_zhengMian") || stateInfo.IsName("walk_zhengMian") ) // 判断是否处于Idle状态
                {
                    Debug.Log("处于Idle状态");
                    playerAnimator.SetTrigger("KanZheng");
                    bloodText.text = (int.Parse(bloodText.text) - KanBlood).ToString();
                }
                if (stateInfo.IsName("idle_houMian") || stateInfo.IsName("walk_houMian") ) // 判断是否处于Idle状态
                {
                    Debug.Log("处于Idle状态");
                    playerAnimator.SetTrigger("KanBei");
                    bloodText.text = (int.Parse(bloodText.text) - KanBlood).ToString();
                }
                if (stateInfo.IsName("idle_left") || stateInfo.IsName("walk_left") ) // 判断是否处于Idle状态
                {
                    Debug.Log("处于Idle状态");
                    playerAnimator.SetTrigger("KanLeft");
                    bloodText.text = (int.Parse(bloodText.text) - KanBlood).ToString();
                }
                if (stateInfo.IsName("idle_right") || stateInfo.IsName("walk_right") ) // 判断是否处于Idle状态
                {
                    Debug.Log("处于Idle状态");
                    playerAnimator.SetTrigger("KanRight");
                    bloodText.text = (int.Parse(bloodText.text) - KanBlood).ToString();
                }
            } 
        }
       
    }
}
