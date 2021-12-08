using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    GameObject door;
    public bool up = false, down=false, left=false, rigth=false, zoomInc = false, zoomDec;

    public bool upRotate = false, downRotate=false, leftRotate=false, rigthRotate=false;
    void Start()
    {
        try{
            door = GameObject.Find("ConfigDoor");
        }catch{}
    }

    // Update is called once per frame
    void Update()
    {
        if(up)      GameObject.Find("modelContainer/modelerCamera").transform.Translate(new Vector3(0f,-0.3f, 0f)* Time.deltaTime);
        if(down)    GameObject.Find("modelContainer/modelerCamera").transform.Translate(new Vector3(0f,0.3f, 0f)* Time.deltaTime);
        if(left)    GameObject.Find("modelContainer/modelerCamera").transform.Translate(new Vector3(-0.3f,0f, 0f)*Time.deltaTime);
        if(rigth)   GameObject.Find("modelContainer/modelerCamera").transform.Translate(new Vector3(0.3f,0f, 0f)*Time.deltaTime);
        if(zoomInc) GameObject.Find("modelContainer/modelerCamera").transform.Translate(new Vector3(0f,0f, 0.3f)*Time.deltaTime);
        if(zoomDec) GameObject.Find("modelContainer/modelerCamera").transform.Translate(new Vector3(0f,0f, -0.3f)*Time.deltaTime);

        if(upRotate)    GameObject.Find("modelContainer/principal").transform.Rotate(new Vector3(-60f, 0f, 0f)*Time.deltaTime);
        if(downRotate)  GameObject.Find("modelContainer/principal").transform.Rotate(new Vector3(60f, 0f, 0f)*Time.deltaTime);
        if(leftRotate)  GameObject.Find("modelContainer/principal").transform.Rotate(new Vector3(0f, -60f, 0f)*Time.deltaTime);
        if(rigthRotate) GameObject.Find("modelContainer/principal").transform.Rotate(new Vector3(0f, 60f, 0f)*Time.deltaTime);
        
    }
    public void OnPointerDown(PointerEventData eventData){
        if(gameObject.name == "upButton") up = true;
        if(gameObject.name == "downButton") down = true;
        if(gameObject.name == "leftButton") left = true;
        if(gameObject.name == "rigthButton") rigth = true;
        if(gameObject.name == "zoomInc") zoomInc = true;
        if(gameObject.name == "zoomDec") zoomDec = true;

        if(gameObject.name == "upRotate") upRotate = true;
        if(gameObject.name == "downRotate") downRotate = true;
        if(gameObject.name == "leftRotate") leftRotate = true;
        if(gameObject.name == "rigthRotate") rigthRotate = true;
    }
    public void OnPointerUp(PointerEventData eventData){
        if(gameObject.name == "upButton") up = false;
        if(gameObject.name == "downButton") down = false;
        if(gameObject.name == "leftButton") left = false;
        if(gameObject.name == "rigthButton") rigth = false;
        if(gameObject.name == "zoomInc") zoomInc = false;
        if(gameObject.name == "zoomDec") zoomDec = false;

        if(gameObject.name == "upRotate") upRotate = false;
        if(gameObject.name == "downRotate") downRotate = false;
        if(gameObject.name == "leftRotate") leftRotate = false;
        if(gameObject.name == "rigthRotate") rigthRotate = false;
    }
}
