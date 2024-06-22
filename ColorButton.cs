using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour, IPointerClickHandler
{
    public ARDrawLine arDrawLine;
    public bool isWhite = true; // setup as true for the beginning
    public Image buttonImage;
    public Sprite whiteSprite;
    public Sprite yellowSprite;

    public void OnPointerClick(PointerEventData eventData) 
    {
        isWhite = !isWhite;
        if (!isWhite) 
        {
            arDrawLine.ChangeLineColor(Color.white);
            buttonImage.sprite = whiteSprite;
        }
        else
        {
            arDrawLine.ChangeLineColor(Color.yellow);
            buttonImage.sprite = yellowSprite;
        }
    }
}
