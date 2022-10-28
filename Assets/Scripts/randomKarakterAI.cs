using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class randomKarakterAI : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject sedyeTransform;
    

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        sedyeTransform = Resources.Load("SedyeDeneme") as GameObject;
    }

    private void Update()
    {
        if (Car.instance.isParked)
        {
            agent.SetDestination(new Vector3(-5.3f,0f,-27.8f));
        }
            
    }
}
