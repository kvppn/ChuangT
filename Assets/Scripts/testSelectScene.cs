using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class testSelectScene : MonoBehaviour
{
    public Animator transmit1;
    public Animator transmit2;
    public GameObject transmit;
    public Animator sleep1;
    public Animator sleep2;
    public GameObject sleep;
    public GameObject selectScene;
    public GameObject sleepselectScene;
    public AudioSource bar;
    public AudioSource store;
    public AudioSource grow;
    public AudioSource clothes;
    public static int flag = 1;//判断是否按下睡觉的按钮，按下变成2
   // private bool isTransmitting = false;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("soundBar") != null) 
        {
            bar = GameObject.FindGameObjectWithTag("soundBar").GetComponent<AudioSource>();
        }
        if (GameObject.FindGameObjectWithTag("soundStore") != null)
        {  
            store=GameObject.FindGameObjectWithTag("soundStore").GetComponent<AudioSource>();
        }
        if (GameObject.FindGameObjectWithTag("soundGrow") != null)
        {
            grow = GameObject.FindGameObjectWithTag("soundGrow").GetComponent<AudioSource>();
        }
        if (GameObject.FindGameObjectWithTag("soundClothes") != null)
        {
            clothes = GameObject.FindGameObjectWithTag("soundClothes").GetComponent<AudioSource>();
        }
        if (flag == 1)
        {
            StartCoroutine(Sound());
        }
        if (flag == 2)
        {
            flag = 1;
            StartCoroutine(SLEEP());
        }
    }
    public void GotoSleep()
    {
        flag = 2;
        sleepselectScene.SetActive(false);
        GameObject.FindGameObjectWithTag("exit2").SetActive(false);
        StartCoroutine(GOTOSLEEP());
    }
    IEnumerator GOTOSLEEP()
    {
        // 播放 transmit1 动画
        sleep1.gameObject.SetActive(true);
        sleep1.enabled = true;
        sleep1.Play("sleepScene_01");
        // 等待动画播放结束
        yield return new WaitForSeconds(sleep1.GetCurrentAnimatorStateInfo(0).length-0.1f);
        sleep1.enabled = false;
        sleep1.gameObject.SetActive(false);
        sleep.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        // 加载 Clothes 场景
        SceneManager.LoadScene("Bar");
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnSceneLoadedhomebar;
    }
     public IEnumerator SLEEP()
    {
        sleep.SetActive(false);
        sleep2.gameObject.SetActive(true);
        sleep2.enabled = true;
        sleep2.Play("sleepScene_02");//播放开屏动画
        yield return new WaitForSeconds(sleep2.GetCurrentAnimatorStateInfo(0).length);
        sleep2.gameObject.SetActive(false);
        // 如果动画播放完成，停止动画
        sleep2.enabled = false;
        if (store != null)
        {
            store.Play();
        }
        if (bar != null)
        {
            bar.Play();
        }
        if (grow != null)
        {
            grow.Play();
        }
        if (clothes != null)
        {
            clothes.Play();
        }
    }
    IEnumerator Sound()
    {
        transmit.SetActive(false);
        transmit2.gameObject.SetActive(true);
        transmit2.enabled = true;
        transmit2.Play("transmitScene_2");
        yield return new WaitForSeconds(transmit2.GetCurrentAnimatorStateInfo(0).length);
        if (store != null)
        {
            store.Play();
        }
        if (bar != null)
        {
            bar.Play();
        }
        if (grow != null)
        {
            grow.Play();
        }
        if (clothes != null)
        {
            clothes.Play();
        }

    }
    private void Update()
    {
        // 检查动画是否播放完成
        if (transmit2.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            transmit2.gameObject.SetActive(false);
            // 如果动画播放完成，停止动画
            transmit2.enabled = false;
        }
    }
    public void clothesButton()
    {
        selectScene.SetActive(false);
        GameObject.FindGameObjectWithTag("exit").SetActive(false);
        StartCoroutine(LoadClothesScene());
    }
    public void growButton()
    {
        selectScene.SetActive(false);
        GameObject.FindGameObjectWithTag("exit").SetActive(false);
        StartCoroutine(LoadgrowScene());
    }
    public void barButton()
    {
        selectScene.SetActive(false);
        GameObject.FindGameObjectWithTag("exit").SetActive(false);
        StartCoroutine(LoadbarScene());
    }
    public void storeButton()
    {
        selectScene.SetActive(false);
        GameObject.FindGameObjectWithTag("exit").SetActive(false);
        StartCoroutine(LoadstoreScene());
    }
    private IEnumerator LoadClothesScene()
    {
        // 播放 transmit1 动画
        transmit1.gameObject.SetActive(true);
        transmit1.enabled = true;
        transmit1.Play("Transmit1");
        // 等待动画播放结束
        yield return new WaitForSeconds(transmit1.GetCurrentAnimatorStateInfo(0).length-0.1f);
        transmit.SetActive(true);
        yield return new WaitForSeconds(0.1f); 
        transmit1.enabled = false;
        transmit1.gameObject.SetActive(false);
        // 加载 Clothes 场景
        SceneManager.LoadScene("ClothesStore");   
        SceneManager.LoadScene(1, LoadSceneMode.Additive); 
        SceneManager.sceneLoaded += OnSceneLoadedclothes;
    }
    private IEnumerator LoadgrowScene()
    {
        // 播放 transmit1 动画
        transmit1.gameObject.SetActive(true);
        transmit1.enabled = true;
        transmit1.Play("Transmit1");
        // 等待动画播放结束
        //yield return new WaitForSeconds(transmit1.GetCurrentAnimatorStateInfo(0).length);
        yield return new WaitForSeconds(transmit1.GetCurrentAnimatorStateInfo(0).length - 0.1f);
        transmit.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        transmit1.enabled = false;
        transmit1.gameObject.SetActive(false);
        // 加载 Clothes 场景
        SceneManager.LoadScene("Grow");
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private IEnumerator LoadbarScene()
    {
        // 播放 transmit1 动画
        transmit1.gameObject.SetActive(true);
        transmit1.enabled = true;
        transmit1.Play("Transmit1");

        // 等待动画播放结束
        //yield return new WaitForSeconds(transmit1.GetCurrentAnimatorStateInfo(0).length);
        yield return new WaitForSeconds(transmit1.GetCurrentAnimatorStateInfo(0).length - 0.1f);
        transmit.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        transmit1.enabled = false;
        transmit1.gameObject.SetActive(false);
        // 加载 Clothes 场景
        SceneManager.LoadScene("Bar");
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnSceneLoadedbar;
    }
    private IEnumerator LoadstoreScene()
    {
        transmit1.gameObject.SetActive(true);
        // 播放 transmit1 动画
        transmit1.enabled = true;
        transmit1.Play("Transmit1");
        // 等待动画播放结束
        //yield return new WaitForSeconds(transmit1.GetCurrentAnimatorStateInfo(0).length);
        yield return new WaitForSeconds(transmit1.GetCurrentAnimatorStateInfo(0).length - 0.1f);
        transmit.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        transmit1.enabled = false;
        transmit1.gameObject.SetActive(false);
        // 加载 Clothes 场景
        SceneManager.LoadScene("store");
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnSceneLoadedstore;
    }
    private void OnSceneLoadedclothes(Scene scene, LoadSceneMode mode)
    {

        if (scene.buildIndex == 1)
        {
            Debug.Log("0000022");
            GameObject player = GameObject.FindGameObjectWithTag("player");
            player.transform.position = new Vector3(-0.3f, -4.4f, 0);
            SceneManager.sceneLoaded -= OnSceneLoadedclothes;
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            Debug.Log("0000022");
            GameObject player = GameObject.FindGameObjectWithTag("player");
            player.transform.position = new Vector3(-4.33f, -1.63f, 0);

            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
    private void OnSceneLoadedbar(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            Debug.Log("0000022");
            GameObject player = GameObject.FindGameObjectWithTag("player");
            player.transform.position = new Vector3(-4.41f, -4.31f, 0);

            SceneManager.sceneLoaded -= OnSceneLoadedbar;
        }
    }
    private void OnSceneLoadedhomebar(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            Debug.Log("0000022");
            GameObject player = GameObject.FindGameObjectWithTag("player");
            player.transform.position = new Vector3(-2f, -0.95f, 0);

            SceneManager.sceneLoaded -= OnSceneLoadedhomebar;
        }
    }
    private void OnSceneLoadedstore(Scene scene, LoadSceneMode mode)
    {    
        if (scene.buildIndex == 1)
        {
            GameObject player = GameObject.FindGameObjectWithTag("player");
            player.transform.position = new Vector3(2.94f, -3.78f, 0);

            SceneManager.sceneLoaded -= OnSceneLoadedbar;
        }
    }
}
