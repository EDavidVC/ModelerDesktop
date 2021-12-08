using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class templates : MonoBehaviour
{
    //simpleDoor
    public Button door;
    public Sprite sdoor;

    //bigDoor
    public Button bigDoor;
    public Sprite sbigDoor;
    //Templates Door
    public Dictionary<string, Dictionary<Button, Sprite>> doorTemplates;
    //simple Window
    public Button window;
    public Sprite swindow;
    //Templates Window
    public Dictionary<string, Dictionary<Button, Sprite>> windowTemplates;
    void Start()
    {
        doorTemplates = new Dictionary<string, Dictionary<Button, Sprite>>();
        windowTemplates = new Dictionary<string, Dictionary<Button, Sprite>>();
        initTemplates();
    }
    private void initTemplates(){
        doorTemplates.Add("simpleDoor",new Dictionary<Button, Sprite>(){{door, sdoor}});
        doorTemplates.Add("bigDoor", new Dictionary<Button, Sprite>(){{bigDoor, sbigDoor}});
        windowTemplates.Add("simpleWindow",new Dictionary<Button, Sprite>(){{window, swindow}});
    }
}
