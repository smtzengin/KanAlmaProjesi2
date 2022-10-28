using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Touch : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{

    public static bool pressed;


    public static bool IsPressing()
    {
        return pressed;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }

}
