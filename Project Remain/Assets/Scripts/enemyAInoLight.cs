//Enemy AI with without light functions
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

            GameObject.Find("longOne").GetComponent<AdvancedWanderAI>().enabled = false;
            GameObject.Find("longOne").GetComponent<FollowingEnemy>().enabled = true;
            lookAtPlayer();
            if (fpsTargetDistance < attackDistance) {
                myRenderer.material.color = Color.red;
                GameObject.Find("longOne").GetComponent<AttackPlayer>().enabled = true;
                //attackPlease();
            }
        }
        
        else{
            myRenderer.material.color = Color.blue;
            GameObject.Find("longOne").GetComponent<AdvancedWanderAI>().enabled = true;
             gameObject.GetComponent<NavMeshAgent>().enabled = true;
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

