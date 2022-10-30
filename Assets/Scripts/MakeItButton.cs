
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MakeItButton : MonoBehaviour
{
    public static MakeItButton instance;
    public UnityEvent unityEvent = new UnityEvent();
    public GameObject button;
    public bool isClicked;
    public float ButtonReactiveDelay = 1f;

    
    private void Start()
    {
        button = this.gameObject;
        isClicked = false;
    }
    private void Awake()
    {
        if(instance == null)
            instance = this;
    }
    private void Update()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray,out hit) && hit.collider.gameObject == gameObject)
            {
                unityEvent.Invoke();
            }
        }
    }

 


}
