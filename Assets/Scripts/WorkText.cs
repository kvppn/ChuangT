using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WorkText : MonoBehaviour
{
    public Text TEXT;
    public string text = "";
    public float letterDelay = 0.08f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Dialogue());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Dialogue()
    {
        TEXT.text = ""; // 清空文本
        foreach (char letter in text)
        {
            TEXT.text += letter; // 逐字添加到文本中
            yield return new WaitForSeconds(letterDelay); // 等待一段时间
        }
    }
}
