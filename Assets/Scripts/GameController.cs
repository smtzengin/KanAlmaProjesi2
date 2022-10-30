using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.UI;

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
    public GameObject NPC5;

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

    public GameObject kanAlmaSolBtn;
    public GameObject kanAlmaSagBtn;


    public AudioSource audioSource;
    public AudioClip Otubus;
    public AudioClip Siringa;
    public AudioClip Puff;
    public AudioClip Alkis;


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
        audioSource = GetComponent<AudioSource>();
        isKarakterSpawned = false;
        isParticleBomb = false;
        NPC = Instantiate(NPC2, karakterSpawn.transform.position, Quaternion.identity);
        StartCoroutine(TiriAc());

    }




    IEnumerator TiriAc()
    {
        yield return new WaitForSeconds(1.25f);
        audioSource.PlayOneShot(Otubus);

        yield return new WaitForSeconds(0.25f);
        audioSource.PlayOneShot(Otubus);

        yield return new WaitForSeconds(1.5f);
        if (Car.instance.isParked == true)
        {
            kapaliTir.SetActive(false);
            aracPuff.gameObject.SetActive(true);
            aracPuff.Play();
            audioSource.PlayOneShot(Puff);
            Destroy(aracPuff.gameObject, 1.5f);
            //StartCoroutine(puffEffect(kapaliTir));
            yield return new WaitForSeconds(0.5f);
            acikTir.SetActive(true);
            yield return new WaitForSeconds(1f);
            sedyeSagPuff.gameObject.SetActive(true);
            sedyeSagPuff.Play();
            audioSource.PlayOneShot(Puff);
            Destroy(sedyeSagPuff.gameObject, 1.5f);
            yield return new WaitForSeconds(0.25f);
            sedye1.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            sedyeSolPuff.gameObject.SetActive(true);
            sedyeSolPuff.Play();
            audioSource.PlayOneShot(Puff);
            Destroy(sedyeSolPuff.gameObject, 1.5f);
            yield return new WaitForSeconds(0.25f);
            sedye2.SetActive(true);
       
        }
    }


    public void SpawnCharacter()
    {
        Destroy(NPC);

        randomNumber = Random.Range(1, 5);
      

        if (randomNumber % 5 == 1)
        {
            NPC = Instantiate(NPC2, karakterSpawn.transform.position, Quaternion.identity);
        }
        
        else if (randomNumber % 5 == 2)
        {
            NPC = Instantiate(NPC3, karakterSpawn.transform.position, Quaternion.identity);
        }

        else if (randomNumber % 5 == 3)
        {
            NPC = Instantiate(NPC4, karakterSpawn.transform.position, Quaternion.identity);
        }
        else if (randomNumber % 5 == 4)
        {
            NPC = Instantiate(NPC5, karakterSpawn.transform.position, Quaternion.identity);
        }


        if (imdat)
            imdat = false;
        else
            imdat = true;
      
    }



    public void KanTopla()
    {
        audioSource.PlayOneShot(Siringa);
        GameManager.instance.SetKan(0.2f);
        StartCoroutine(AddDelay(1f));
        kanAlmaSagBtn.SetActive(false);
        kanAlmaSolBtn.SetActive(false);
        print("bastim ki");
    }

    public IEnumerator AddDelay(float f)
    {
        yield return new WaitForSeconds(f);
    }
}
