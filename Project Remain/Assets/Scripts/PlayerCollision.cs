//Player collision with enemies
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter (UnityEngine.Collision collisionInfo) 
    {
        if (collisionInfo.collider.name == "Enemy" || collisionInfo.collider.name == "WanderingEnemy" || collisionInfo.collider.name == "flyingEnemy" || collisionInfo.collider.name == "longOne" )
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(2);
            Debug.Log("HIT");
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

/*|| collisionInfo.collider.name == "longOne" || collisionInfo.collider.name == "watcherEnemy" */