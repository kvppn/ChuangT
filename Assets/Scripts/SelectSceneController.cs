using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SelectSceneController : MonoBehaviour
{

    public GameObject selectButon;
    public GameObject selectJieMian;
    private Animator transmit1;
    private Animator transmit2;
    private Animator sleep1;
    private Animator sleep2;
    //private bool isCoroutineRunning = false; // 用于标记协程是否正在运行
    // Start is called before the first frame update
    void Start()
    {
        transmit2 = GameObject.FindGameObjectWithTag("2").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void SelectScene()
    {
        selectButon.SetActive(false);
        selectJieMian.SetActive(true);
    }
    public void exit()
    {
        selectButon.SetActive(true);
        selectJieMian.SetActive(false);
    }
    public void growButton()
    {
        SceneManager.LoadScene("Grow");
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnSceneLoaded;

    }
    public void clothesButton()
    {
        SceneManager.LoadScene("ClothesStore");
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnSceneLoadedclothes;

    }
    public void barButton()
    {
        SceneManager.LoadScene("Bar");
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnSceneLoadedbar;

    }
    public void storeButton()
    {
        SceneManager.LoadScene("store");
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnSceneLoadedstore;

    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            Debug.Log("0000022");
            GameObject player = GameObject.FindGameObjectWithTag("player");
            player.transform.position = new Vector3(-0.5f, -4.5f, 0);

            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
    private void OnSceneLoadedclothes(Scene scene, LoadSceneMode mode)
    {
       
        if (scene.buildIndex == 0)
        {
            Debug.Log("0000022");
            GameObject player = GameObject.FindGameObjectWithTag("player");
            player.transform.position = new Vector3(-0.3f, -4.4f, 0);
            //StartCoroutine(PlayAnimationAndWait());
            SceneManager.sceneLoaded -= OnSceneLoadedclothes;
        }
    }
   /* IEnumerator PlayAnimationAndWait()
    {
        if (transmit2 == null)
        {
            yield break; // 如果animator为空，则退出协程
        }

        transmit2.enabled = true;

        // 等待动画播放完成
        while (transmit2.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            yield return null;
        }

        // 动画播放完成后禁用Animator组件
        transmit2.enabled = false;
       // SceneManager.sceneLoaded -= OnSceneLoadedclothes;
    }
    void OnDestroy()
    {
        if (isCoroutineRunning)
        {
            StopAllCoroutines(); // 停止所有协程
        }
    }*/
    private void OnSceneLoadedbar(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            Debug.Log("0000022");
            GameObject player = GameObject.FindGameObjectWithTag("player");
            player.transform.position = new Vector3(-4.38f, -6.16f, 0);

            SceneManager.sceneLoaded -= OnSceneLoadedbar;
        }
    }
    private void OnSceneLoadedstore(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            GameObject player = GameObject.FindGameObjectWithTag("player");
            player.transform.position = new Vector3(3.15f, -4.48f, 0);

            SceneManager.sceneLoaded -= OnSceneLoadedbar;
        }
    }
}
