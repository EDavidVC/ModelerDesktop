using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class templateButtons : MonoBehaviour, IPointerClickHandler
{
    public Sprite defaultSprite;
    public Sprite selectedSprite;

    public Sprite actualSprite;
    private Button thisButton;
    private ArquitectureState localAS;
    void Start(){
        thisButton = GetComponent<Button>();
        defaultSprite = thisButton.image.sprite;
        localAS = GameObject.Find("globalData").GetComponent<ArquitectureState>();
        
    }
    public void setDefaultSprite(){
        thisButton.image.sprite = defaultSprite;
        localAS.templateSelectedID = "none";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        
        GameObject[] templatesLoads = GameObject.FindGameObjectsWithTag("Template");
        if(templatesLoads.Length != 0){
            foreach(GameObject obj in templatesLoads){
                obj.GetComponent<templateButtons>().setDefaultSprite();
            }
        }
        localAS.templateSelectedID = gameObject.name;
        if(thisButton.image.sprite == defaultSprite){
            thisButton.image.sprite = selectedSprite;
        }else{thisButton.image.sprite = defaultSprite;}
    }
}
