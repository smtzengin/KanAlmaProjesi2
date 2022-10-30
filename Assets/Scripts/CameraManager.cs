using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;


    private void Update()
    {
        if(GameManager.instance.slider.value >= 1f)
        {
            ChangeCamera();
        }
    }

    public void ChangeCamera()
    {
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(true);
    }
}
