using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    public GameObject EnvelopAnim;
    public GameObject WorkOnePanel;
    public GameObject WorkTwoPanel;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("NewPlayerEnvelope", 0) == 1)
        {
            EnvelopAnim.SetActive(true);
            PlayerPrefs.SetInt("NewPlayerEnvelope", 2);//播出一次
        }
        else
        {
            EnvelopAnim.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
      /* if(PlayerPrefs.GetInt("WorkOnE", 0) == 1)
        {
            WorkOnePanel.SetActive(true);
            PlayerPrefs.SetInt("WorkOnE", 2);//工作台的触发，初始为1
        }*/
      /*  if (PlayerPrefs.GetInt("WorkTwo", 0) == 1)
        {
            WorkTwoPanel.SetActive(true);
            PlayerPrefs.SetInt("WorkTwo", 2);//工作台的触发，初始为1
        }*/
    }
}
