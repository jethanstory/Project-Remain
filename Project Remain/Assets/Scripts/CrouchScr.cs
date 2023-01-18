using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchScr : MonoBehaviour
{
    public CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            controller.height = 1.0f;
        }

        else
        {
            controller.height = 2.0f;
        }
    }
}
