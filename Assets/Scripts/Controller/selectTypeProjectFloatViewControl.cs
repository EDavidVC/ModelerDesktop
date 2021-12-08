using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class selectTypeProjectFloatViewControl : MonoBehaviour, IPointerClickHandler
{
    private controlViews cv;
    private templates templates;
    public  GameObject templateContent;
    private ArquitectureState localAS;
    public void OnPointerClick(PointerEventData eventData)
    {
        string nameActioned = gameObject.name;
        switch (nameActioned)
        {
            case "closeButton":
            close();
            break;

            case "windowText":
            localAS.typeProjectID = "window";
            localAS.templateSelectedID = "none";
            deleteTemplatesLoaded();
            chargeWindowTemplate();
                        
            break;

            case "doorText":
            localAS.typeProjectID = "door";
            localAS.templateSelectedID = "none";
            deleteTemplatesLoaded();
            chargeDoorTemplate();            
            break;

            case "cancelButton":
            close();
            break;

            case "confirmButton":
            chargeModelerView();

            break;

            default:
            print("not define");
            break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cv = GameObject.Find("globalData").GetComponent<controlViews>();
        this.templates = GameObject.Find("globalData").GetComponent<templates>();
        localAS = GameObject.Find("globalData").GetComponent<ArquitectureState>();
    }
    private void close(){
        cv.closeView("FloatViewSelected");
    }
    private void deleteTemplatesLoaded(){
        GameObject[] templatesLoads = GameObject.FindGameObjectsWithTag("Template");
        if(templatesLoads.Length != 0){
            foreach(GameObject obj in templatesLoads){
                Destroy(obj);
            }
        }
    }
    private void chargeDoorTemplate(){
        foreach(string objName in templates.doorTemplates.Keys){
            Dictionary<Button, Sprite> tempDict;
            tempDict = templates.doorTemplates[objName];
            foreach(Button tempButton in tempDict.Keys){
                Sprite spriteTmp = tempDict[tempButton];
                Button tempObj = Instantiate(tempButton, new Vector3(), Quaternion.identity);
                
                tempObj.transform.SetParent(templateContent.transform);
                tempObj.name = objName;
                tempObj.GetComponent<templateButtons>().selectedSprite = spriteTmp;
            }
        }
    }
    private void chargeWindowTemplate(){
        foreach(string objName in templates.windowTemplates.Keys){
            Dictionary<Button, Sprite> tempDict;
            tempDict = templates.windowTemplates[objName];
            foreach(Button tempButton in tempDict.Keys){

                Sprite spriteTmp = tempDict[tempButton];
                Button tempObj = Instantiate(tempButton, new Vector3(), Quaternion.identity);
                
                tempObj.transform.SetParent(templateContent.transform);
                tempObj.name = objName;
                tempObj.GetComponent<templateButtons>().selectedSprite = spriteTmp;
                
            }
        }
    }
    private void chargeModelerView(){
        if(!(localAS.typeProjectID == "none") && !(localAS.templateSelectedID == "none")){
            cv.switchView("modelerView");
            close();
        }
    }
    
}
