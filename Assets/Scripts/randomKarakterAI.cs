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

            //Quaternion deneme = new Quaternion(gameObject.transform.rotation.w, gameObject.transform.rotation.x , gameObject.transform.rotation.y, gameObject.transform.rotation.z);
            //gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, gameObject.transform.rotation, 5);

            //Vector3 denemeVec = new Vector3(gameObject.transform.position.x + 50, gameObject.transform.position.y + 50, gameObject.transform.position.z + 50);
            //gameObject.transform.Rotate(denemeVec, Space.World);


            if (isRotating)
            {
                Vector3 toRotate = new Vector3(0, 120, 0);
                if (Vector3.Distance(transform.eulerAngles, toRotate) > 0.1f)
                {
                    transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, toRotate, Time.deltaTime);
                }
                else
                {
                    transform.eulerAngles = toRotate;
                    isRotating = false;
                }
            }

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
            animator.SetTrigger("isSitting");

            isSitting = true;
            //gameObject.transform.position = other.transform.position;
            //Quaternion deneme = new Quaternion(gameObject.transform.rotation.w + 50, gameObject.transform.rotation.x + 50, gameObject.transform.rotation.y + 50, gameObject.transform.rotation.z + 50);
            //gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, deneme, 5);


            //Vector3 denemeVec = new Vector3(gameObject.transform.position.x + 50, gameObject.transform.position.y + 50, gameObject.transform.position.z + 50);
            //gameObject.transform.Rotate(denemeVec, Space.Self);

            //animator.SetBool("isSitting", true);


        }           
        if (other.gameObject.tag == "SedyeTrigger2")
        {
            print("sol sedye");
            animator.SetTrigger("isSitting");


            isSitting = true;
             gameObject.transform.position = other.transform.position;
            //Quaternion deneme = new Quaternion(gameObject.transform.rotation.w + 50, gameObject.transform.rotation.x + 50, gameObject.transform.rotation.y + 50, gameObject.transform.rotation.z + 50);
            //gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation , deneme, 5);


            //Vector3 denemeVec = new Vector3(gameObject.transform.position.x + 50, gameObject.transform.position.y + 50, gameObject.transform.position.z + 50);
            //gameObject.transform.Rotate(denemeVec, Space.Self);

            //animator.SetBool("isSitting", true);           
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

