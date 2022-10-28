using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class randomKarakterAI : MonoBehaviour
{
    public static randomKarakterAI instance;


    NavMeshAgent agent;
    public GameObject sedyeTransform;
    public GameObject agentTarget;
    private Vector3 agentTargetVector;
    public bool firstAgentIsOnTarget = false;
    public GameObject FirstAgent;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        firstAgentIsOnTarget = false;
        agent = GetComponent<NavMeshAgent>();
        agentTargetVector = agentTarget.gameObject.transform.position; 



        sedyeTransform = Resources.Load("SedyeDeneme") as GameObject;
    }

    private void Update()
    {

        if (!firstAgentIsOnTarget)
        {
            
            if (agent.SetDestination(agentTargetVector))
            {
                firstAgentIsOnTarget = true;
            }
        }
        
        if (Car.instance.isParked)
        {
            agent.SetDestination(agentTargetVector);
        }
            
    }
}

/*
 * 
 * 
 * kanka soyle yaoiom ba k= simdi
 * gelcek dududududu 1sn AAYNII AMKKKKKK YOK YOK TIPA TIP AYNI .DAN SONRAKI 3 HANESI DE AYNI
 * sonra
 * ayynen
 * ama navmeshle
 * gidicez HAD' G'T SN BEN YAPCAMEYWWOKI
 * joystick fln
 * yok          ayni deil ki
 * sonraaa
 * he
 * niedeniiom suan
 * o da olur bi denim 
 * ama suan sey oluyo
 * 
 * 
 * lan bi dk he yok yok
 * o zaten
 * targetin vecytoru
 * sedyenin
 * 
 * 
 * */
