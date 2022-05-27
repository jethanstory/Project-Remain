//Old test light flicker experimental code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public bool isFlickering;
    public int FlickerMode;
    public float FlickerTime;

    public GameObject lightSource;

    public Light light;



    public float RandomIntensity;

    // Start is called before the first frame update
    void Start()
    {
        isFlickering = false;
        //lightSource= GetComponent<Light>();
    }


    // Update is called once per frame
    void Update()
    {
        if (isFlickering == false)
        {
            StartCoroutine(FlickerLight());
        }
    }

    IEnumerator FlickerLight()
    {
        if (FlickerMode == 1)
        {
            //this.gameObject.GetComponent<Light>().enabled = false;
            lightSource.SetActive(false);
            FlickerTime = Random.Range(0f, 0.26f);
            RandomIntensity = Random.Range(0f, 3.1f);
            light.intensity = RandomIntensity;
            FlickerTime = Random.Range(0f, 0.05f);
            yield return new WaitForSeconds(FlickerTime);
            RandomIntensity = Random.Range(0f, 3.1f);
            light.intensity = RandomIntensity;
            lightSource.SetActive(true);
            //this.gameObject.GetComponent<Light>().enabled = true;
            isFlickering = false;
        }

        if (FlickerMode == 2)
        {
            //this.gameObject.GetComponent<Light>().enabled = false;
            //RandomIntensity = Random.Range(0f, 3.1f);
            //light.intensity = RandomIntensity;
            //FlickerTime = Random.Range(0f, 0.05f);
            yield return new WaitForSeconds(FlickerTime);
            //RandomIntensity = Random.Range(0f, 3.1f);
            //light.intensity = RandomIntensity;
            //this.gameObject.GetComponent<Light>().enabled = true;
            isFlickering = false;
        }
         if (FlickerMode == 3)
        {
            FlickerMode = Random.Range(1, 3);
            isFlickering = false;
        }
    }

}