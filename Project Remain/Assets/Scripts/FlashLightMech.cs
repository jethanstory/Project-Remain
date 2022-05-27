//Flashlight mechanic for FPS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightMech : MonoBehaviour
{
    public bool isOn = false;
    public GameObject lightSource;

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("FKey"))
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isOn == false)
                {
                    lightSource.SetActive(true);
                    isOn = true;
                }

            else if (isOn == true)
            {
                lightSource.SetActive(false);
                isOn = false;
            }
            
        } 
    }
}
