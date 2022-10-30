using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    private bool isAlkis = false;


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
    }
}
