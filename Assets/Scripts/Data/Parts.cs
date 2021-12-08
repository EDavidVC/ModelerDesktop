using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parts : MonoBehaviour
{
    //Parts instiating variables and respective buttons
    public GameObject simpleDoorTp1;
    public Button     simpleDoorTP1_btn;
    public GameObject simpleDoorHeaderTp1;
    public Button     simpleDoorHeaderTp1_btn;
    public GameObject simpleDoorHeaderWindowTp1;
    public Button     simpleDoorHeaderWindowTp1_btn;
    public GameObject simpleDoorMidleSecurityTp1;
    public Button     simpleDoorMidleSecurityTp1_btn;
    public GameObject simpleDoorPartDownSecurityTp1;
    public Button     simpleDoorPartDownSecurityTp1_btn;
    public GameObject simpleDoorPartUpSecurityTp1;
    public Button     simpleDoorPartUpSecurityTp1_btn;
    public GameObject simpleDoorPartDownTp1;
    public Button     simpleDoorPartDownTp1_btn;
    public GameObject simpleDoorPartDownTp2;
    public Button     simpleDoorPartDownTp2_btn;
    public GameObject simpleDoorPartUpTp1;
    public Button     simpleDoorPartUpTp1_btn;
    public GameObject simpleDoorPartUpTp2;
    public Button     simpleDoorPartUpTp2_btn;
    


    //Colleccion of the parts    
    private Dictionary<string, Dictionary<string, Part[]>> partsList;
    
    void Start()
    {
        initComponents();
    }
    public void initComponents(){
        //Initialize the variable part list.
        partsList = new Dictionary<string, Dictionary<string, Part[]>>();
        //Adding Elementos to dictionary.
        partsList.Add("door", new Dictionary<string, Part[]>{
            {"simpleDoor", new Part[]{
                new Part ("body",        simpleDoorTP1_btn,                  "simpleDoor_body_tp1",              simpleDoorTp1,                  new string[]{"bodyDownReference","bodyUpReference","headReference", "midleReference"}, "principal"),
                new Part ("head",        simpleDoorHeaderTp1_btn,            "simpleDoor_header_tp1",            simpleDoorHeaderTp1,            new string[]{"headerReference"}, "headReference"),
                new Part ("head_ac",     simpleDoorHeaderWindowTp1_btn,      "simpleDoor_header_window_tp1",     simpleDoorHeaderWindowTp1,      "headerReference"),
                new Part ("body",        simpleDoorMidleSecurityTp1_btn,     "simpleDoor_midle_security_tp1",    simpleDoorMidleSecurityTp1,     "midleReference"),
                new Part ("security",    simpleDoorPartDownSecurityTp1_btn,  "simpleDoor_partdown_security_tp1", simpleDoorPartDownSecurityTp1,  "bodyDownReference"),
                new Part ("security",    simpleDoorPartUpSecurityTp1_btn,    "simpleDoor_partup_security_tp1",   simpleDoorPartUpSecurityTp1,    "bodyUpReference"),
                new Part ("body",        simpleDoorPartDownTp1_btn,          "simpleDoor_partdown_tp1",          simpleDoorPartDownTp1,          "bodyDownReference"),
                new Part ("body",        simpleDoorPartDownTp2_btn,          "simpleDoor_partdown_tp2",          simpleDoorPartDownTp2,          "bodyDownReference"),
                new Part ("body",        simpleDoorPartUpTp1_btn,            "simpleDoor_partup_tp1",            simpleDoorPartUpTp1,            "bodyUpReference"),
                new Part ("body",        simpleDoorPartUpTp2_btn,            "simpleDoor_partup_tp2",            simpleDoorPartUpTp2,            "bodyUpReference")}
            }
        });
    }
    public void testFunction(){

    }
    public Part[] GetParts(string typeProjectID, string templateSelectedID){
        Part[] tempParts;
        tempParts = partsList[typeProjectID][templateSelectedID];
        if(tempParts.Length > 0 ){
            return tempParts;
        }
        return new Part[]{};
    }
    public Part GetPart(string typeProjectID, string templateSelectedID){
       Part tempParts;
        tempParts = partsList[typeProjectID][templateSelectedID][0];
        if(tempParts != null){
            return tempParts;
        }
        return new Part();
    }
    public Part GetPart(string partName){
       Part[] tempParts;
       ArquitectureState ars = GameObject.Find("globalData").GetComponent<ArquitectureState>();
       
        tempParts = partsList[ars.typeProjectID][ars.templateSelectedID];
        foreach(Part part in tempParts){
            if(part.partName.Equals(partName)){
                return part;
            }
        }
        
        return new Part();
    }
}
