using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;


    public GameObject kapaliTir;
    public GameObject acikTir;
    public GameObject sedye1;
    public GameObject sedye2;
    public GameObject karakter;
    public GameObject karakterSpawn;
    private GameObject NPC;
    public GameObject NPC2;
    public GameObject NPC3;
    public GameObject NPC4;
    public bool isKarakterSpawned;
    public int randomNumber;
    public bool imdat = true;


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
        isKarakterSpawned = false;
    }

    private void Update()
    {
        TiriAc();

    }

    public void TiriAc()
    {
        if(Car.instance.isParked == true)
        {
            kapaliTir.SetActive(false);
            acikTir.SetActive(true);
            sedye1.SetActive(true);
            sedye2.SetActive(true);

        }
    }


    public void SpawnCharacter()
    {
        Destroy(NPC);

        randomNumber = Random.Range(1, 4);

        

        if (randomNumber % 4 == 1)
        {
            NPC = Instantiate(NPC2, karakterSpawn.transform.position, Quaternion.identity);
        }
        
        else if (randomNumber % 4 == 2)
        {
            NPC = Instantiate(NPC3, karakterSpawn.transform.position, Quaternion.identity);
        }

        else if (randomNumber % 4 == 3)
        {
            NPC = Instantiate(NPC4, karakterSpawn.transform.position, Quaternion.identity);
        }


        if (imdat)
            imdat = false;
        else
            imdat = true;

        
    }
}
