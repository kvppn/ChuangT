using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIcontrollerr : MonoBehaviour
{
    public static UIcontrollerr instance_;
    public Transform uitextobj;
    public Text text;
    private void Awake()
    {
        instance_ = this;
    }

    public void SetInfo(string info)
    {
        text.text = info;
        uitextobj.gameObject.SetActive(true);
    }
    public void HideInfo()
    {
        uitextobj.gameObject.SetActive(false);
    }

}
