using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LineButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public ARDrawLine arDrawLine; 
    public bool isPressed = false;

    public void OnPointerDown(PointerEventData eventData) 
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData) 
    {
        isPressed = false;
        arDrawLine.StopDrawLine();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            arDrawLine.StartDrawLine();
        }
    }
}
