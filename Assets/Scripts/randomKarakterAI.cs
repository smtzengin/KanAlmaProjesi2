using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class randomKarakterAI : MonoBehaviour
{
    public static randomKarakterAI instance;
    private Animator animator;
    public bool isSitting;


    NavMeshAgent agent;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        isSitting = false;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

  

        
    }

    private void Update()
    {
        //print(GameController.instance.imdat);
        if (Car.instance.isParked)
        {
            if (GameController.instance.imdat)
                SolSedye();
            else if (!GameController.instance.imdat)
                SagSedye();
        }

        
    }

    private void SagSedye() 
    {
        if (!isSitting)
        {
            //agent.SetDestination(new Vector3(-1.06f, 2.03f, -28.95f));
            agent.destination = new Vector3(-1.06f, 2.03f, -28.95f);
        }
        else if (isSitting)
        {
            //eðer oturuyorsa gideceði yolu sýfýrlýyo xd
            agent.ResetPath();
        }
    }

    private void SolSedye()
    {
        if (!isSitting)
        {
            //agent.SetDestination(new Vector3(3.7f, 1.3f, -28.734f));
            agent.destination = new Vector3(3.7f, 1.3f, -28.7f);
        }
        else if (isSitting)
        {
            agent.ResetPath();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SedyeTrigger")
        {
            print("sað sedye");

            isSitting = true;
            gameObject.transform.position = other.transform.position;
            gameObject.transform.rotation = other.transform.rotation;


            animator.SetBool("isSitting", true);


        }
        if (other.gameObject.tag == "SedyeTrigger2")
        {
            print("sol sedye");
            isSitting = true;
            gameObject.transform.position = other.transform.position;
            gameObject.transform.rotation = other.transform.rotation;

            
            animator.SetBool("isSitting", true);           
        }
    }

}

