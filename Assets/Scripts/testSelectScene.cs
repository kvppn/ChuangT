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
        // �� Start() �в��ٻ�ȡ transmit2
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
        // ���� transmit1 ����
        transmit1.enabled = true;
        transmit1.Play("Transmit1");

        // �ȴ��������Ž���
        yield return new WaitForSeconds(transmit1.GetCurrentAnimatorStateInfo(0).length);
        transmit1.enabled = false;
        // ���� Clothes ����
        SceneManager.LoadScene("ClothesStore");
        Debug.Log("transmitScene_2");
        transmit2.enabled = true;
        transmit2.Play("transmitScene_2");
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
        yield return new WaitForSeconds(transmit2.GetCurrentAnimatorStateInfo(0).length);
        transmit2.enabled = false;
        SceneManager.sceneLoaded += OnSceneLoadedclothes;
        // �ȴ�һ��ʱ��ȷ�������������
        yield return new WaitForSeconds(1f);
    }
    private IEnumerator LoadgrowScene()
    {
        // ���� transmit1 ����
        transmit1.enabled = true;
        transmit1.Play("Transmit1");

        // �ȴ��������Ž���
        yield return new WaitForSeconds(transmit1.GetCurrentAnimatorStateInfo(0).length);
        transmit1.enabled = false;
        // ���� Clothes ����
        SceneManager.LoadScene("Grow");
        Debug.Log("transmitScene_2");
        transmit2.enabled = true;
        transmit2.Play("transmitScene_2");
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
        yield return new WaitForSeconds(transmit2.GetCurrentAnimatorStateInfo(0).length);
        transmit2.enabled = false;
        SceneManager.sceneLoaded += OnSceneLoadedclothes;
        // �ȴ�һ��ʱ��ȷ�������������
        yield return new WaitForSeconds(1f);
    }
    private IEnumerator LoadbarScene()
    {
        // ���� transmit1 ����
        transmit1.enabled = true;
        transmit1.Play("Transmit1");

        // �ȴ��������Ž���
        yield return new WaitForSeconds(transmit1.GetCurrentAnimatorStateInfo(0).length);
        transmit1.enabled = false;
        // ���� Clothes ����
        SceneManager.LoadScene("Bar");
        Debug.Log("transmitScene_2");
        transmit2.enabled = true;
        transmit2.Play("transmitScene_2");
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
        yield return new WaitForSeconds(transmit2.GetCurrentAnimatorStateInfo(0).length);
        transmit2.enabled = false;
        SceneManager.sceneLoaded += OnSceneLoadedclothes;
        // �ȴ�һ��ʱ��ȷ�������������
        yield return new WaitForSeconds(1f);
    }
    private IEnumerator LoadstoreScene()
    {
        // ���� transmit1 ����
        transmit1.enabled = true;
        transmit1.Play("Transmit1");

        // �ȴ��������Ž���
        yield return new WaitForSeconds(transmit1.GetCurrentAnimatorStateInfo(0).length);
        transmit1.enabled = false;
        // ���� Clothes ����
        SceneManager.LoadScene("store");
        Debug.Log("transmitScene_2");
        transmit2.enabled = true;
        transmit2.Play("transmitScene_2");
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
        yield return new WaitForSeconds(transmit2.GetCurrentAnimatorStateInfo(0).length);
        transmit2.enabled = false;
        SceneManager.sceneLoaded += OnSceneLoadedclothes;
        // �ȴ�һ��ʱ��ȷ�������������
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
