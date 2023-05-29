//Player collision with enemies
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public bool hasCollided;
    GameObject ObjectIwantToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        //gameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


/*|| collisionInfo.collider.name == "longOne" || collisionInfo.collider.name == "watcherEnemy" */


// void OnCollisionEnter (UnityEngine.Collision collisionInfo) 
//     {
//         //if (collisionInfo.collider.name == "Enemy" || collisionInfo.collider.name == "WanderingEnemy" || collisionInfo.collider.name == "flyingEnemy" || collisionInfo.collider.name == "longOne" )
//         if (collisionInfo.collider.tag == "Enemy")
//         {
//             hasCollided = true;
//             //Cursor.lockState = CursorLockMode.None;
//             //Cursor.visible = true;
            
//             //SceneManager.LoadScene("GameOver");
//             Debug.Log("HIT");
            
            
//         }
        
//     }

private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "Enemy") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            // canpickup = true;  //set the pick up bool to true
            // ObjectIwantToPickUp = other.gameObject; //set the gameobject you collided with to one you can reference

            Debug.Log("HIT");
            hasCollided = true;
            //ObjectIwantToDestroy = other.gameObject; //set the gameobject you collided with to one you can reference
            //Destroy(ObjectIwantToDestroy);
        }
    }  
}