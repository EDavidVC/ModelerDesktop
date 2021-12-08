using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;
using System.IO;
public class mainViewControl : MonoBehaviour, IPointerClickHandler
{
    private controlViews cv;
    private string[] extencions = {"Json File", "json"};
    ArquitectureState arquitectureState;
    void Start(){

        cv = GameObject.Find("globalData").GetComponent<controlViews>();

        arquitectureState = GameObject.Find("globalData").GetComponent<ArquitectureState>();

    }
    private void openProject(){

        var path = EditorUtility.OpenFilePanelWithFilters("Seleccionar Fichero JSON", "", extencions);
        if(File.Exists(path)){

            string textJson = File.ReadAllText(path);

            print(textJson);

            ConfigProject obj = JsonUtility.FromJson<ConfigProject>(textJson);

            arquitectureState.setPartFromJson(obj);
            
        }

    }
    private void createProject(){
        cv.switchFloatView("selectTypeProjectFloatView");
    }
    private void loadAndPrevizualice(){}
    private void about(){}
    private void selectTypeProject(){}

    public void OnPointerClick(PointerEventData eventData)
    {
        string nameActioned = gameObject.name;
        switch (nameActioned)
        {

            case "createNewText":
            createProject();
            break;

            case "openText":
            openProject();
            break;

        }
    }
}
