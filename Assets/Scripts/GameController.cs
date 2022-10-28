using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject kapaliTir;
    public GameObject acikTir;
    public GameObject sedye1;
    public GameObject sedye2;
    public GameObject karakter;
    public GameObject karakterSpawn;
    public bool isKarakterSpawned;


    private void Start()
    {
        isKarakterSpawned = false;
        karakter = Resources.Load("randomKarakter") as GameObject;
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
        if(Car.instance.isParked && PlayerController.instance.isSedyeTriggered)
        {
            Instantiate(Resources.Load("randomKarakter") as GameObject, karakterSpawn.transform.position, Quaternion.identity);
            isKarakterSpawned = true;
        }
    }
}
