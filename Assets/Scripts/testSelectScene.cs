using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class testSelectScene : MonoBehaviour
{

    public Animator transmit2;
    public Animator transmit1;
    public GameObject selectScene;
   // private bool isTransmitting = false;

    void Start()
    {
        //transmit2 = GameObject.FindGameObjectWithTag("2").GetComponent<Animator>();
        // 在 Start() 中不再获取 transmit2
    }

    public void clothesButton()
    {
        selectScene.SetActive(false);
        StartCoroutine(LoadClothesScene());
    }
    public void growButton()
    {
        selectScene.SetActive(false);
        StartCoroutine(LoadgrowScene());
    }
    public void barButton()
    {
        selectScene.SetActive(false);
        StartCoroutine(LoadbarScene());
    }
    public void storeButton()
    {
        selectScene.SetActive(false);
        StartCoroutine(LoadstoreScene());
    }
    private IEnumerator LoadClothesScene()
    {
        // 播放 transmit1 动画
        transmit1.enabled = true;
        transmit1.Play("Transmit1");

        // 等待动画播放结束
        yield return new WaitForSeconds(transmit1.GetCurrentAnimatorStateInfo(0).length);
        transmit1.enabled = false;
        // 加载 Clothes 场景
        SceneManager.LoadScene("ClothesStore");
        Debug.Log("transmitScene_2");
        transmit2.enabled = true;
        transmit2.Play("transmitScene_2");
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
        yield return new WaitForSeconds(transmit2.GetCurrentAnimatorStateInfo(0).length);
        transmit2.enabled = false;
        SceneManager.sceneLoaded += OnSceneLoadedclothes;
        // 等待一段时间确保场景加载完成
        yield return new WaitForSeconds(1f);
    }
    private IEnumerator LoadgrowScene()
    {
        // 播放 transmit1 动画
        transmit1.enabled = true;
        transmit1.Play("Transmit1");

        // 等待动画播放结束
        yield return new WaitForSeconds(transmit1.GetCurrentAnimatorStateInfo(0).length);
        transmit1.enabled = false;
        // 加载 Clothes 场景
        SceneManager.LoadScene("Grow");
        Debug.Log("transmitScene_2");
        transmit2.enabled = true;
        transmit2.Play("transmitScene_2");
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
        yield return new WaitForSeconds(transmit2.GetCurrentAnimatorStateInfo(0).length);
        transmit2.enabled = false;
        SceneManager.sceneLoaded += OnSceneLoadedclothes;
        // 等待一段时间确保场景加载完成
        yield return new WaitForSeconds(1f);
    }
    private IEnumerator LoadbarScene()
    {
        // 播放 transmit1 动画
        transmit1.enabled = true;
        transmit1.Play("Transmit1");

        // 等待动画播放结束
        yield return new WaitForSeconds(transmit1.GetCurrentAnimatorStateInfo(0).length);
        transmit1.enabled = false;
        // 加载 Clothes 场景
        SceneManager.LoadScene("Bar");
        Debug.Log("transmitScene_2");
        transmit2.enabled = true;
        transmit2.Play("transmitScene_2");
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
        yield return new WaitForSeconds(transmit2.GetCurrentAnimatorStateInfo(0).length);
        transmit2.enabled = false;
        SceneManager.sceneLoaded += OnSceneLoadedclothes;
        // 等待一段时间确保场景加载完成
        yield return new WaitForSeconds(1f);
    }
    private IEnumerator LoadstoreScene()
    {
        // 播放 transmit1 动画
        transmit1.enabled = true;
        transmit1.Play("Transmit1");

        // 等待动画播放结束
        yield return new WaitForSeconds(transmit1.GetCurrentAnimatorStateInfo(0).length);
        transmit1.enabled = false;
        // 加载 Clothes 场景
        SceneManager.LoadScene("store");
        Debug.Log("transmitScene_2");
        transmit2.enabled = true;
        transmit2.Play("transmitScene_2");
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
        yield return new WaitForSeconds(transmit2.GetCurrentAnimatorStateInfo(0).length);
        transmit2.enabled = false;
        SceneManager.sceneLoaded += OnSceneLoadedclothes;
        // 等待一段时间确保场景加载完成
        yield return new WaitForSeconds(1f);
    }
    private void OnSceneLoadedclothes(Scene scene, LoadSceneMode mode)
    {

        if (scene.buildIndex == 0)
        {
            Debug.Log("0000022");
            GameObject player = GameObject.FindGameObjectWithTag("player");
            player.transform.position = new Vector3(-0.3f, -4.4f, 0);
            SceneManager.sceneLoaded -= OnSceneLoadedclothes;
        }
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
