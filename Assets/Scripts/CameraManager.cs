using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public GameObject panel;
    public TMPro.TextMeshProUGUI tebrikText;
    private int rnd;
    public Button restartBtn;

    private bool isAlkis = false;

    private void Start()
    {
        rnd = Random.Range(5, 25);
    }

    private void Update()
    {
        if(GameManager.instance.slider.value >= 1f)
        {
            ChangeCamera();
            if (!isAlkis)
            {
                GameController.instance.audioSource.PlayOneShot(GameController.instance.Alkis);
                isAlkis = true;
            }
        }
    }

    public void ChangeCamera()
    {
        

        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(true);
        tebrikText.text = "TEBRÝKLER " + rnd + " ÝNSANA UMUT OLDUN!";
        panel.SetActive(true);
        restartBtn.gameObject.SetActive(true);

    }
}
