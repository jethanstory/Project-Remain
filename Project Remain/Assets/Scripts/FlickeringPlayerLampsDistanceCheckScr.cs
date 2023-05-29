using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringPlayerLampsDistanceCheckScr : MonoBehaviour
{
    public bool isFlickering;
    public int FlickerMode;
    public float FlickerTime;

    public bool canFlicker;
    public GameObject lightSource;

    public Light light;

     private float restartIn = 1f; //1


    
    public float RandomIntensity;
   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canFlicker)
        {
            isFlickering = true;
            StartCoroutine(FlickerLight());
        }
            
        
        else {
            light.intensity = restartIn;
        }

    }

    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "FlickeringLight") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            canFlicker = true;
            // canpickup = true;  //set the pick up bool to true
            // ObjectIwantToPickUp = other.gameObject; //set the gameobject you collided with to one you can reference

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "FlickeringLight") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            canFlicker = false;
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
    }
}
