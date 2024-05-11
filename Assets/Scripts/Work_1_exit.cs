using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Work_1_exit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void workoneExit()
    {
        GameObject WorkOne = GameObject.FindGameObjectWithTag("workCraftingCanvas");
        WorkOne.GetComponent<Canvas>().enabled = false;
    }
}
