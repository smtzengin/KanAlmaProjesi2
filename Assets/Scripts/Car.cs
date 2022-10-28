using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public static Car instance;

    public Transform hedefYer;
    public bool isParked;

    private void Awake()
    {
        isParked = false;

        if(instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        ParkEt();       
    }

    public void ParkEt()
    {
        if (!isParked)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, hedefYer.position, 25f * Time.deltaTime);
            if (gameObject.transform.position == hedefYer.position)
            {
                isParked = true;
            }
        }
    }
    
}
