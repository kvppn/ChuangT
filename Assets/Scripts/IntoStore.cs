using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class IntoStore : MonoBehaviour
{
    public bool playerInRange = false;//主角是否在npc的碰撞范围内
    public float fadeOutTime = 1f;//遮罩渐隐渐显的时间
    public GameObject Canvas;
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
        Canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        Scene otherScene = SceneManager.GetSceneByName("Player");
        if (Input.GetMouseButtonDown(1)) // 1代表鼠标右键
        {
            Debug.Log("1");
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int layerMask = 1 << LayerMask.NameToLayer("other");

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, layerMask);

            if (hit.collider != null && hit.collider == GetComponent<Collider2D>() && playerInRange == true)
            {
                Canvas.SetActive(false);
                Debug.Log(" obj.SetActive");
                GameObject.FindGameObjectWithTag("player").GetComponent<playerWalk>().enabled = false;
                foreach (GameObject obj in otherScene.GetRootGameObjects())
                {
                    Debug.Log("SetActive");
                    // 找到你要激活的GameObject
                    if (obj.CompareTag("store"))
                    {
                        Debug.Log(" obj.SetActive(true)");
                        // 激活GameObject
                        obj.SetActive(true);
                        obj.transform.GetChild(1).GetComponent<Animator>().enabled = true;
                        obj.transform.GetChild(2).GetComponent<Animator>().enabled = true;
                        StartCoroutine(UIwork(obj));
                        StartCoroutine(UIDiawork(obj));
                        StartCoroutine(ZheZhao(obj));
                        break;
                    }
                }
            }

        }
    }
    IEnumerator UIwork(GameObject obj)
    {
        yield return new WaitForSeconds(obj.transform.GetChild(1).GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length - 0.1f);
        obj.transform.GetChild(1).GetComponent<Animator>().enabled = false;
    }
    IEnumerator UIDiawork(GameObject obj)
    {
        yield return new WaitForSeconds(obj.transform.GetChild(2).GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length - 0.1f);
        obj.transform.GetChild(2).GetComponent<Animator>().enabled = false;
    }
    IEnumerator ZheZhao(GameObject obj)
    {
        for (float t = 0.0f; t < fadeOutTime; t += Time.deltaTime)
        {
            Color color = obj.transform.GetChild(0).GetComponent<Image>().color;
            color.a = Mathf.Lerp(0.0f, 1.0f, t / fadeOutTime);
            obj.transform.GetChild(0).GetComponent<Image>().color = color;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
    }
}
