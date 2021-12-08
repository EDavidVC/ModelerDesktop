using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class interactiveActions : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Text text;
    private Color defaultColor;
    private FontStyle fontStyleDefault;
    void Start(){
        text = (Text) GetComponent< Text >();
        defaultColor = text.color;
        fontStyleDefault = text.fontStyle;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = new Color(255, 131, 0);
        text.fontStyle = FontStyle.Bold;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = defaultColor;
        text.fontStyle = fontStyleDefault;
    }
}
