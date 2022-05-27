//Enemy AI with without light functions
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAInoLight : MonoBehaviour
{
   public float fpsTargetDistance;
    public float enemyLookDistance;
    public float attackDistance;
    public float enemyMovementSpeed;
    public float damping;

    //public GameObject lightSource;
    public Transform fpsTarget;
    Rigidbody theRigidBody;
    Renderer myRenderer;

    public bool isOn = false;

    //private Light enemyLight;
    // Start is called before the first frame update
    void Start()
    {
       myRenderer = GetComponent<Renderer>();
       theRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        fpsTargetDistance = Vector3.Distance(fpsTarget.position, transform.position);
        if (fpsTargetDistance < enemyLookDistance) {
            myRenderer.material.color = Color.yellow;
            lookAtPlayer();
            if (fpsTargetDistance < attackDistance) {
                myRenderer.material.color = Color.red;
                attackPlease();
            }
        }
        
        else{
            myRenderer.material.color = Color.blue;
            //enemyLight.color = Color.white;
        }
        
    }

    void lookAtPlayer() {
        Quaternion rotation = Quaternion.LookRotation(fpsTarget.position - transform.position);
        transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
        
    }

    void attackPlease() {
        theRigidBody.AddForce(transform.forward * enemyMovementSpeed);
        //enemyLight.color = Color.red;
        //lightSource.SetActive(true);
    }
}

