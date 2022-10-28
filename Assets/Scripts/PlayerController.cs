using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    NavMeshAgent PlayerAgent;

    [Header("Movement")]
    public float moveSpeed;

    public Transform orientation;
    public Transform movePosition;


    float horizontalInput;
    float verticalInput;

    

    Rigidbody rb;
    public bool isSedyeTriggered;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayerAgent = GetComponent<NavMeshAgent>();
        isSedyeTriggered = false;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        

    }

    private void Update()
    {
        MyInput();
        SpeedControl();
    }
    private void FixedUpdate()
    {
        if(randomKarakterAI.instance.firstAgentIsOnTarget)
        {
            //MovePlayer();

            PlayerAgent.SetDestination(movePosition.position);

        }
    }

    

        private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    //private void MovePlayer()
    //{
    //    moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
    //    rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    //}

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SedyeTrigger"))
        {
            isSedyeTriggered = true;
        }
    }


    /*
     * 
     * HG
     * micim calismio
     * alo
     * 1 sn
     * bida solesene duymadim
     * konusmaiom hu
     * AMKKKKKKKKK SAMEEETTT
     * ABIII
     * CANVASIN TERSINDE YAPMISIZ DUNYAIY
     * BAK BI BAK BAAKK
     * ABI TAMAM BU BOYE OLR CUNKU EKRANA ETKILESIO DIREKT
     * AMA BAK SIMDI
     * HEEE XD
     * SACMALIO OLEBU BUUMESIN ISYIOM
     * 
     * 
     */
}
