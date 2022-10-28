using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class randomKarakterAI : MonoBehaviour
{
    public static randomKarakterAI instance;

    NavMeshAgent agent;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        print(GameController.instance.imdat);
        if (Car.instance.isParked)
        {
            if (GameController.instance.imdat)
                SolSedye();
            else if (!GameController.instance.imdat)
                SagSedye();
        }
    }

    private void SolSedye() 
    {
        agent.SetDestination(new Vector3(-1.06f, 2.03f, -28.95f));
    }

    private void SagSedye()
    {
        agent.SetDestination(new Vector3(3.556f, 2.69f, -28.734f));
    }
}

