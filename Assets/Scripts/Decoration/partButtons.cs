using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class partButtons : MonoBehaviour, IPointerClickHandler
{
    private Sprite defaultSprite;
    public Sprite selectedSprite;
    private Button thisButton;
    private Part partRepresent;
    private ArquitectureState globalArquitecture;
    void Start(){
        thisButton = GetComponent<Button>();
        defaultSprite = thisButton.image.sprite;

        partRepresent = GameObject.Find("globalData").GetComponent<Parts>().GetPart(gameObject.name.ToString());
        globalArquitecture = GameObject.Find("globalData").GetComponent<ArquitectureState>();
    }
    public void setDefaultSprite(){
        thisButton.image.sprite = defaultSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        /* GameObject[] templatesLoads = GameObject.FindGameObjectsWithTag("Template");
        if(templatesLoads.Length != 0){
            foreach(GameObject obj in templatesLoads){
                obj.GetComponent<templateButtons>().setDefaultSprite();
            }
        } */
    
        /* if(thisButton.image.sprite == defaultSprite){
            thisButton.image.sprite = selectedSprite;
        }else{thisButton.image.sprite = defaultSprite;} */

        globalArquitecture.addPart(partRepresent);
    }
}
