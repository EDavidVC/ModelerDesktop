using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlViews : MonoBehaviour
{
    //Views - Windows shows
    public GameObject mainView;
    public GameObject modelerView;
    //FloatViews - Alerts shows or confirmation or forms
    public GameObject selectTypeProjectFloatView;
    public GameObject confirmationMessage;
    public Dictionary<string, GameObject> Views; //V
    public Dictionary<string, GameObject> FloatView; //FV
    // Start is called before the first frame update
    void Start()
    {
        Views = new Dictionary<string, GameObject>();
        FloatView = new Dictionary<string, GameObject>();

        //Add Views
        Views.Add("mainView", mainView);
        Views.Add("modelerView", modelerView);
        //Add Float Views
        FloatView.Add("selectTypeProjectFloatView", selectTypeProjectFloatView);
        FloatView.Add("confirmationMessage", confirmationMessage);
        

        //View Main On
        switchView("mainView");
    }

    // Update is called once per frame
    public void switchView (string nameView)
    {
        //Find if is some view selected
        GameObject someView = GameObject.Find("ViewSelected");
        if(someView){Destroy(someView);}


        GameObject tempView = Instantiate(Views[nameView], new Vector3(), Quaternion.identity);
        tempView.name = "ViewSelected";   
    }
    public void switchFloatView(string nameFloatView){

GameObject someFloatViewContent = GameObject.Find("FloatViewSelected");
        if(someFloatViewContent){Destroy(someFloatViewContent);}

        GameObject tempFloatView = Instantiate(FloatView[nameFloatView], new Vector3(), Quaternion.identity);
        tempFloatView.name = "FloatViewSelected";     
    }
    public void closeView(string typeView){
        GameObject someFloatViewContent = GameObject.Find(typeView);
        if(someFloatViewContent){Destroy(someFloatViewContent);}
    }
}
