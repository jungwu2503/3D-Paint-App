using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UndoButton : MonoBehaviour, IPointerClickHandler
{
    public ARDrawLine arDrawLine;

    public void OnPointerClick(PointerEventData eventData) 
    {
        arDrawLine.DeleteLastLine();
    }
}
