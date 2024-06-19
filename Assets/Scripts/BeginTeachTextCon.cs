using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BeginTeachTextCon : MonoBehaviour
{
    public Text TEXT;

    public float letterDelay = 0.08f;

    public GameObject JiaoCheng;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("player").GetComponent<playerWalk>().enabled = false;
        StartCoroutine(Dialogue());
        StartCoroutine(JiaoChengAnim());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Dialogue()
    {
        string sentence = "等到成熟的那天，你亲手栽培的原料就可以用来制作你在裁缝店的第一件作品了。";
        TEXT.text = ""; // 清空文本
        foreach (char letter in sentence)
        {
            TEXT.text += letter; // 逐字添加到文本中
            yield return new WaitForSeconds(letterDelay); // 等待一段时间
        }
    }
    IEnumerator JiaoChengAnim()
    {
        JiaoCheng.SetActive(true);
        yield return new WaitForSeconds(JiaoCheng.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length - 0.1f);
        JiaoCheng.GetComponent<Animator>().enabled = false;//对话框的动画结束
    }
    public void PlayerActive()
    {
        GameObject.FindGameObjectWithTag("player").GetComponent<playerWalk>().enabled = true;
    }
}
