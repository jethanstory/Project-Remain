//NavMesh based AI wander system

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]

public class AdvancedWanderAI : MonoBehaviour
{
    public NavMeshAgent agent;
    //public NavMeshAgent fpsTarget;
    // Start is called before the first frame update

    //public float targetTime = 10.0f;
    //public bool timerStarted = false;
    //public float timer = 0.0f;

    [Range(0, 500)] public float speed; //100
    [Range(1, 500)] public float walkRadius;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent != null)
        {
            agent.speed = speed;
            agent.SetDestination(RandomNavMeshLocation());
        }
    }

    public Vector3 RandomNavMeshLocation()
    {
        Vector3 finalPosition = Vector3.zero;
        Vector3 randomPosition = Random.insideUnitSphere * walkRadius;
        randomPosition += transform.position;
        if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, walkRadius, 1)) {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    // Update is called once per frame
    void Update() //FixedUpdate()
    {
        if (agent != null && agent.remainingDistance <= agent.stoppingDistance)
        {
            //agent.enabled = false;
            //agent.enabled = true;
            agent.SetDestination(RandomNavMeshLocation());
            //Debug.Log("FOUND!");
        }
        
        //agent.SetDestination(fpsTarget)

    }
}
