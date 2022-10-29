using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int kanMiktari = 0;

    public Slider slider; 
    void Start()
    {
        instance = this;
        slider.value = 0;
    }

    public void SetKan(float kanMiktari)
    {
        slider.value += kanMiktari;
    }
}
