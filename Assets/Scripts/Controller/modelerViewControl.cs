using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class modelerViewControl : MonoBehaviour
{
    public InputField height, width;
    public Vector2 dimencion = new Vector2(0, 0);
    private bool IsWorking;
    private string partTypeSelected;
    public GameObject Container;
    public GameObject modelContainer;
    private ArquitectureState ars;
    private Part[] partsProject;
    private int PartsSize;
    // Start is called before the first frame update
    void Start()
    {
        IsWorking = false;
        partTypeSelected = "none";

        ars = GameObject.Find("globalData").GetComponent<ArquitectureState>();
        PartsSize = ars.parts.Count;

        partsProject = GameObject.Find("globalData").GetComponent<Parts>().GetParts(ars.typeProjectID, ars.templateSelectedID);
    }
    public GameObject principal;
    Texture2D icon;
    public Rect boxRect;

    public void TakeSnapShot(){

        IsWorking = true;
        GameObject camera = GameObject.Find("modelContainer/modelerCamera");

        SnapshotCameraTest snapshotCameraTest = camera.GetComponent<SnapshotCameraTest>();


        GameObject principal = GameObject.Find("modelContainer/principal");

        GameObject cloneTemp = Instantiate(principal);

        foreach(Transform child in cloneTemp.transform){

            Vector3 positionTemp = child.position;

            float x = positionTemp.x - 0.8f;
            float y = positionTemp.y + 0.9f;
            float z = positionTemp.z - 0.0f;

            Vector3 newPosition = new Vector3(x, y, z);

            child.position = newPosition;

        }


        snapshotCameraTest.TakePicture(cloneTemp);
        Destroy(cloneTemp);

        IsWorking = false;


    }
    public void SetPartTypeSelected(string type){
        if(type == "accesories"){
            if(!partTypeSelected.Contains("_ac")){
                partTypeSelected+="_ac";
            }
        }else if(type == "default"){
            if(partTypeSelected.Contains("_ac")){
                partTypeSelected = partTypeSelected.Remove(partTypeSelected.IndexOf("_"), 3);
            }
        }else{
            partTypeSelected = type;
        }        
        reloadButtons();

    }
    private void reloadButtons(){
        GameObject[] visibleParts = GameObject.FindGameObjectsWithTag("partButton");
        foreach(GameObject visiblePart in visibleParts){
            Destroy(visiblePart);
        }
        foreach(Part part in partsProject){
            if(part.partType == partTypeSelected){
                Button tempButton = Instantiate(part.partButton, new Vector3(), Quaternion.identity); 
                tempButton.transform.SetParent(Container.transform);
                tempButton.transform.localPosition = new Vector3(0,0,0);
                tempButton.gameObject.name = part.partName;         
            }
        }
    }
    void Update(){
        if(!IsWorking){
            PartsSize = ars.parts.Count;
            GameObject principal = GameObject.Find("modelContainer/principal");
            //Delete Actual Structure
            GameObject[] actualStructure = GameObject.FindGameObjectsWithTag("Part");
            if(actualStructure.Length > 0){
                foreach(GameObject partEstructure in actualStructure){
                    Destroy(partEstructure);
                }
            }

            foreach(Part part in ars.parts){
                GameObject tempPart = Instantiate(part.partObject);
                tempPart.transform.SetParent(principal.transform);
                tempPart.gameObject.name = part.partName;
                
                if(part.partReferenceAnchorName == "principal"){
                    tempPart.transform.localPosition = new Vector3(0f, 0f, 0f);                  
                }else{
                    GameObject reference = GameObject.Find(part.partReferenceAnchorName);
                    if(reference){
                        tempPart.transform.position = reference.transform.position;
                        //tempPart.transform.rotation = principal.transform.rotation;
                    }
                }
                Vector3 selfRotate = new  Vector3(
                    tempPart.transform.eulerAngles.x + principal.transform.eulerAngles.x,
                    tempPart.transform.eulerAngles.y + principal.transform.eulerAngles.y,
                    tempPart.transform.eulerAngles.z + principal.transform.eulerAngles.z
                    );

                tempPart.transform.eulerAngles = selfRotate;
                tempPart.transform.localScale = principal.transform.localScale;
                
                
            }
        }
    }
    public void exportPDF(){
        TakeSnapShot();
        Estructurer printingManager = GameObject.Find("globalData").GetComponent<Estructurer>();

        if(printingManager){
            printingManager.GenerateFile();
        }

        controlViews cv = GameObject.Find("globalData").GetComponent<controlViews>();
        cv.switchFloatView("confirmationMessage");
    }
    public void exportModel(){
        infoExport info = new infoExport();

        ArquitectureState arquitectureState = GameObject.Find("globalData").GetComponent<ArquitectureState>();
        List<Part> part = arquitectureState.parts;

        info.gerateJson(arquitectureState);
    }
    public void redimencionar(){
        int heigthValue = int.Parse(height.text);
        int widthValue = int.Parse(width.text);

        float scaleX = heigthValue / dimencion.y;
        float scaleY = widthValue / dimencion.x;

        principal.transform.localScale = new Vector3(scaleX, scaleY, principal.transform.localScale.z);

        
    }
}
