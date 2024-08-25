using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class envelopAnimCon : MonoBehaviour
{
    public GameObject EnvelopClosed;
    public GameObject EnvelopOpen;
    public GameObject TextAnim;
    public GameObject Dia;
    public GameObject nextButton;
    public GameObject nextButton1;
    public Text TEXT;
    public Text NameText;
    public float letterDelay = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(envelop());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator envelop()
    {
        yield return new WaitForSeconds(1.5f);
        EnvelopClosed.SetActive(true);
        yield return new WaitForSeconds(EnvelopClosed.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length - 0.1f);
        EnvelopClosed.GetComponent<Animator>().enabled = false;//信封滑进的动画结束
        TextAnim.SetActive(true);
        yield return new WaitForSeconds(TextAnim.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length - 0.1f);
        TextAnim.SetActive(false);//显示字的动画结束
    }
    public void ClickTheEnvelop()
    {
        StartCoroutine(envelopNext());
        StartCoroutine(Dialogue());
    }
    IEnumerator envelopNext()
    {
        EnvelopOpen.SetActive(true);
        yield return new WaitForSeconds(EnvelopOpen.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length - 0.1f);
        EnvelopOpen.GetComponent<Animator>().enabled = false;//信封打开的动画结束
        EnvelopClosed.SetActive(false);//闭合的信封消失
    }
    IEnumerator Dialogue()
    {
        Dia.SetActive(true);
        yield return new WaitForSeconds(Dia.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length - 0.1f);
        Dia.GetComponent<Animator>().enabled = false;//对话框的动画结束
        
        string sentence = "你好，我们已经收到你的信了。威德很满意你的诚恳和认真，他也好好看了你以前的设计。近日有空的话，请尽快来到店里吧。";
        TEXT.text = ""; // 清空文本
        foreach (char letter in sentence)
        {
            TEXT.text += letter; // 逐字添加到文本中
            yield return new WaitForSeconds(letterDelay); // 等待一段时间
        }
        NameText.text = ""; // 清空文本
        string name = "米罗   威德";
        foreach (char letter in name)
        {
            NameText.text += letter; // 逐字添加到文本中
            yield return new WaitForSeconds(letterDelay); // 等待一段时间
        }
        nextButton.SetActive(true);
        nextButton1.SetActive(true);
    }
}