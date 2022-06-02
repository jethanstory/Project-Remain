//FPS player light flickering mechanic
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickeringLamps : MonoBehaviour
{

    public float fpsTargetDistance;
    //public float fpsTargetWanderingDistance;

    //public float fpsTargetFlyingDistance;

    //public float fpsTargetLongDistance;

    //public float fpsTargetWatchDistance;
    public float enemyLookDistance;
    //public float enemyLookDistance2;
    //public float enemyLookDistance3;
    //public float enemyLookDistance4;
    //public float attackDistance;
    //public float enemyMovementSpeed;
    public float damping;

    public Transform fpsTarget;

    //public Transform fpsTarget2;

    //public Transform fpsTarget3;

    //public Transform fpsTarget4;

    //public Transform fpsTarget5;
    public bool isFlickering;
    public int FlickerMode;
    public float FlickerTime;

    public GameObject lightSource;

    public Light light;

     private float restartIn = 1f;


    
    public float RandomIntensity;
   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fpsTargetDistance = Vector3.Distance(fpsTarget.position, transform.position);
        if (fpsTargetDistance < enemyLookDistance) {
            isFlickering = true;
            StartCoroutine(FlickerLight());
        }
        /*fpsTargetWanderingDistance = Vector3.Distance(fpsTarget2.position, transform.position);
        if (fpsTargetWanderingDistance < enemyLookDistance2) {
            isFlickering = true;
            StartCoroutine(FlickerLight());
        }
        fpsTargetFlyingDistance = Vector3.Distance(fpsTarget3.position, transform.position);
        if (fpsTargetFlyingDistance < enemyLookDistance3) {
            isFlickering = true;
            StartCoroutine(FlickerLight());
        }
        fpsTargetLongDistance = Vector3.Distance(fpsTarget4.position, transform.position);
        if (fpsTargetLongDistance < enemyLookDistance4) {
            isFlickering = true;
            StartCoroutine(FlickerLight());
        }
        */
        /*
        fpsTargetWatchDistance = Vector3.Distance(fpsTarget5.position, transform.position);
        if (fpsTargetWatchDistance < enemyLookDistance) {
            isFlickering = true;
            StartCoroutine(FlickerLight());
        }
        */
        else {
            light.intensity = restartIn;
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
