using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class randomKarakterAI : MonoBehaviour
{
    public static randomKarakterAI instance;
    private Animator animator;
    public bool isSitting;
    public bool isRotating;
    public bool isGoing;
    public bool isLeftSedye;
    public bool isRightSedye;


    NavMeshAgent agent;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        isSitting = false;
        isRotating = true;
        isGoing = true;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        isRightSedye = false;
        isLeftSedye = false;
  

        
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

        if (isSitting)
        {

            if (isGoing)
            {
                Vector3 toDir = new Vector3(transform.position.x - 1.6f, transform.position.y, transform.position.z);

                transform.position = toDir;

                isGoing = false;

            }



        }

    }

    private void SagSedye() 
    {
        if (!isSitting)
        {
            //agent.SetDestination(new Vector3(-1.06f, 2.03f, -28.95f));
            if(GameController.instance.acikTir.gameObject.activeInHierarchy == true)
                agent.destination = new Vector3(-1.06f, 2.03f, -28.95f);
        }
    }

    private void SolSedye()
    {
        if (!isSitting)
        {

            //agent.SetDestination(new Vector3(3.7f, 1.3f, -28.734f));
            if(GameController.instance.acikTir.gameObject.activeInHierarchy == true)
                agent.destination = new Vector3(3.7f, 1.3f, -28.7f);
        }     

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SedyeTrigger")
        {
            print("sað sedye");
            animator.SetTrigger("isSitting");

            isSitting = true;

            Transform deneme = other.transform;

            agent.enabled = false;
            gameObject.transform.position = new Vector3(deneme.position.x +2.3f,deneme.position.y+2.1f,deneme.position.z + 1.7f);
            gameObject.transform.rotation = Quaternion.Euler(0, 40f, 0);
            isRightSedye = true;

            GameController.instance.kanAlmaSagBtn.SetActive(true);
            GameController.instance.kanAlmaSolBtn.SetActive(false);
            

        }           
        if (other.gameObject.tag == "SedyeTrigger2")
        {
            print("sol sedye");
            animator.SetTrigger("isSitting");

            agent.enabled = false;
            Transform deneme = other.transform;
            isSitting = true;
            gameObject.transform.position = new Vector3(deneme.position.x , deneme.position.y + 1.7f, deneme.position.z);
            isLeftSedye = true;
            GameController.instance.kanAlmaSagBtn.SetActive(false);
            GameController.instance.kanAlmaSolBtn.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
    }
    private void OnCollisionStay(Collision collision)
    {
        print(collision.gameObject.name);

    }
}

