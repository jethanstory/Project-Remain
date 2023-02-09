using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTextScr : MonoBehaviour
{
    float secondsCount;
    public GameObject goalText;
    public GameObject textControls;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        secondsCount += Time.deltaTime;

        if (secondsCount > 5) 
        {
            goalText.SetActive(false);
            textControls.SetActive(true);
            if (secondsCount > 10)
            {
                textControls.SetActive(false);
            }
        }
    }
}
