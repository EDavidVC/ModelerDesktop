using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArquitectureState : MonoBehaviour
{
    //Prpierties of the project
    public string typeProjectID {get;set;}
    public string templateSelectedID {get;set;}
    public List<Part> parts;
    controlViews cv;

    
    
    void Start(){
        
        typeProjectID       = "none";
        templateSelectedID  = "none";
        parts               = new List<Part>();
        cv = GameObject.Find("globalData").GetComponent<controlViews>();

    }
    public void addPart(Part part){

        bool isAdded = false;
        foreach(Part ownPart in parts){
            if(ownPart.partReferenceAnchorName.Equals(part.partReferenceAnchorName)){
                removePart(ownPart);
            }
        }
        
        if(!parts.Contains(part)){
            
            if(part.partReferenceAnchorName == "principal"){

                GameObject gameObject = part.partObject;
                int height = 0;
                int width = 0;

                foreach (Transform child in gameObject.transform)
                {
                    Material material = new ValueString().formatTextToMaterial(child.gameObject.name);
                    if(!material.nameEN.Equals("coco")){
                        if(height == 0 && material.orientation.Equals("h")){
                            height = int.Parse(material.medeasure);
                        }
                        if(width == 0 && material.orientation.Equals("v")){
                            width = int.Parse(material.medeasure);
                        }
                    }
                    
                }

                print(part.partName);

                modelerViewControl modelerView = GameObject.Find("ViewSelected").GetComponent<modelerViewControl>();
                modelerView.height.text = ""+height;
                modelerView.width.text = ""+width;

                modelerView.dimencion = new Vector2(width, height);
                
                parts.Add(part);
                isAdded = true;

            }else{
                foreach(Part ownPart in parts){
                    
                    foreach(string ivailableReferences in ownPart.partReferences){
                        if(part.partReferenceAnchorName == ivailableReferences){
                            parts.Add(part);
                            isAdded = true;
                        }
                    }

                    if(isAdded){
                        break;
                    };

                }
            }
                            
        }else{
            removePart(part);
        }
        print(parts.Count);
    }
    private void removePart(Part part){
        if(part.partReferenceAnchorName.Equals("principal")){
            GameObject gameObject = part.partObject;
            int height = 0;
            int width = 0;

            modelerViewControl modelerView = GameObject.Find("ViewSelected").GetComponent<modelerViewControl>();
            modelerView.height.text = ""+height;
            modelerView.width.text = ""+width;

            modelerView.dimencion = new Vector2(width, height);
        }
        
        parts.Remove(part);

    }
    private void updateParts(){
    }
    public void setPartFromJson(ConfigProject config){

        typeProjectID = config.typeProjectID;
        templateSelectedID = config.templateSelectedID;

        chargeModelerView();

        foreach(string singlePlartName in config.parts){

            Part partRepresent = GameObject.Find("globalData").GetComponent<Parts>().GetPart(singlePlartName);
            if(partRepresent != null){
                addPart(partRepresent);
            }
            
        }

    }
    private void chargeModelerView(){
        if(!(typeProjectID == "none") && !(templateSelectedID == "none")){
            cv.switchView("modelerView");
        }
        close();
    }
    private void close(){
        cv.closeView("FloatViewSelected");
    }
}
