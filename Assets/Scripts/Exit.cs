using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void sleStoreExit()
    {
        canvas.SetActive(true);
        GameObject.FindGameObjectWithTag("player").GetComponent<playerWalk>().enabled = true;
    }
}
