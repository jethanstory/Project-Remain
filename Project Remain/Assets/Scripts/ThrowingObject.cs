using System.Collections;

using System.Collections.Generic;

using UnityEngine;

//this script is used for throwing the grenade and destrouing it after some delay

public class ThrowingObject : MonoBehaviour

{

    public Transform spawnPoint;
    public GameObject flare;
    public GameObject staticFlare;

    float range = 15f;

    public GameObject myHands; //reference to your hands/the position where you want your object to go

    //public Rigidbody rb;

    //public ParticleSystem part;

    //public Light light;
    //public Light light2;
    //public Light light3;

    //public AudioSource audioSource;

    // Update is called once per frame

    public int flareCount = 0;
    //public AudioSource audio;

    public GameObject[] lights;
    private bool lightEnabled;
    //public GameObject[] sounds;

    //public bool canThrow;

    public GameObject ObjectIwantToPickUp; // the gameobject onwhich you collided with



    bool canpickup; //a bool to see if you can or cant pick up the item
    bool hasItem; // a bool to see if you have an item in your hand




    void Start () {
        //light = GetComponent<Light> ();
        //light2 = GetComponent<Light> ();
        //light3 = GetComponent<Light> ();
        //canThrow = false;
        canpickup = false;    //setting both to false
        hasItem = false;
        //audio = GetComponent<AudioSource>();
    }

    void FixedUpdate() //FixedUpdate()

    {
        throwCheck();
        

        if (flareCount > 0) { //canThrow == true
            if (Input.GetMouseButtonDown(0)) // && canThrow == true

            {
            flareCount -= 1; //flareCount
            //canThrow = false;

            //Destroy(flare);

            //rb.AddForce(new Vector3(0,15,15), ForceMode.Impulse);// used to apply force 

            //Invoke("delay", 4f);//it is used to create delay in destroying the game object 
            Launch();
            
            }
        }

        
    }

    private void throwCheck()

    {
        if(canpickup == true) // if you enter thecollider of the objecct
        {
            //audio.Play(); //Play it
            //Destroy(staticFlare);
            //canThrow = true;
            
            //flareCount += 1;
        }
    }

    public void delay() // whenever this function is called the object gets destroyed

    {

        //Destroy(gameObject);


    }
    private void Launch()
    {
        
        flare.transform.SetParent(null);
        GameObject flareInstance = Instantiate(flare, spawnPoint.position, spawnPoint.rotation);
        flareInstance.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * range, ForceMode.Impulse);
        flareInstance.GetComponent <ParticleSystem>().Play ();
        //flareInstance.GetComponent <AudioSource>().Play ();

        ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
        //light = flareInstance.GetComponent <Light>();

        //audioSource = flareInstance.GetComponent<AudioSource>();

        //audioSource.SetActive(lightEnabled);
        //audioSource.Play();
        em.enabled = true;

        lightEnabled = !lightEnabled;

        foreach (var light in lights)
        {
            light.SetActive(lightEnabled);
        }
        
        
        
        /*
        //ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
        ObjectIwantToPickUp.transform.position = myHands.transform.position; // sets the position of the object to your hand position
        ObjectIwantToPickUp.transform.rotation = myHands.transform.rotation; // sets t
        ObjectIwantToPickUp.GetComponent<Rigidbody>().useGravity = true;
        ObjectIwantToPickUp.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * range, ForceMode.Impulse);
        */
        //foreach (var audioSource in sounds)
        //{
          //  audioSource.SetActive(lightEnabled);
        //}

        
        //light.enabled = true;
        //light2.enabled = true;
        //light3.enabled = true;






    }

    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "PickUp") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            canpickup = true;  //set the pick up bool to true
            ObjectIwantToPickUp = other.gameObject; //set the gameobject you collided with to one you can reference
            flareCount += 1;
            Destroy(ObjectIwantToPickUp);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canpickup = false; //when you leave the collider set the canpickup bool to false
     
    }
}
