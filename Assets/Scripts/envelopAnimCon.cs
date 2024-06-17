using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class envelopAnimCon : MonoBehaviour
{
    public GameObject EnvelopClosed;
    public GameObject EnvelopOpen;
    public GameObject TextAnim;
    public GameObject Dia;
    public GameObject nextButton;
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
        nextButton.SetActive(true);
    }
}