using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    public GameObject EnvelopAnim;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("NewPlayerEnvelope", 0) == 1)
        {
            EnvelopAnim.SetActive(true);
            PlayerPrefs.SetInt("NewPlayerEnvelope", 2);//²¥³öÒ»´Î
        }
        else
        {
            EnvelopAnim.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
