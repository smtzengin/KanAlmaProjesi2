using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

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
    public bool isParticleBomb;

    public Transform tirTransform;
    public Transform sagSedyeTransform;
    public Transform solSedyeTransform;

    public VisualEffect aracPuff;
    public VisualEffect sedyeSagPuff;
    public VisualEffect sedyeSolPuff;


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
        isParticleBomb = false;
        NPC = Instantiate(NPC2, karakterSpawn.transform.position, Quaternion.identity);
    }

    private void Update()
    {
        StartCoroutine(TiriAc());
        SetPuffEffects();
    }

    public void SetPuffEffects()
    {
        if(Car.instance.isParked == true)
        {
            aracPuff.gameObject.SetActive(true);
            aracPuff.Play();
            Destroy(aracPuff.gameObject, 0.5f);
        }
        if (sedye1.activeInHierarchy)
        {
            sedyeSagPuff.gameObject.SetActive(true);
            sedyeSagPuff.Play();
            Destroy(sedyeSagPuff.gameObject, 0.5f);

        }
        if (sedye2.activeInHierarchy)
        {
            sedyeSolPuff.gameObject.SetActive(true);
            sedyeSolPuff.Play();
            Destroy(sedyeSolPuff.gameObject, 0.5f);

        }
    }

    IEnumerator TiriAc()
    {
        if(Car.instance.isParked == true)
        {
            
            kapaliTir.SetActive(false);
            //StartCoroutine(puffEffect(kapaliTir));
            yield return new WaitForSeconds(2f);
            acikTir.SetActive(true);
            yield return new WaitForSeconds(1f);
            sedye1.SetActive(true);
            yield return new WaitForSeconds(1f);
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

    //IEnumerator puffEffect(GameObject obj)
    //{
        
    //    GameObject puffEffect;
    //    if (!isParticleBomb)
    //    {
    //        puffEffect = Instantiate(Resources.Load("puffEffect") as GameObject, obj.transform.position, Quaternion.identity);
    //        isParticleBomb = true;
    //        yield return new WaitForSeconds(2f);
    //        Destroy(puffEffect.gameObject);
    //    }
        
        
    //}

    public void KanTopla()
    {
        GameManager.instance.SetKan(0.1f);
    }
}
