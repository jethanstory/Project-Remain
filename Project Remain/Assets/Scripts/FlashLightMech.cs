//Flashlight mechanic for FPS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightMech : MonoBehaviour
{
    public bool isOn = false;
    public GameObject lightSource;

    public GameObject torchSound;

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("FKey"))
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isOn == false)
                {
                    torchSound.SetActive(false);
                    lightSource.SetActive(true);
                    isOn = true;
                    torchSound.SetActive(true);

                }

            else if (isOn == true)
            {
                torchSound.SetActive(false);
                lightSource.SetActive(false);
                isOn = false;
                torchSound.SetActive(true);
            }
            
        } 
    }
}
