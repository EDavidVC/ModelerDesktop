using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Part
{
    public string partType = "";
    public string partDependent = "";
    public string partName = "";
    public GameObject partObject;
    public Button partButton;
    public string[] partReferences = new string[]{};
    public string partReferenceAnchorName = "";

    public Part(){}
    /* public Part(string partDependent,string partType, string partName, GameObject partObject, string[] partReferences){
        this.partDependent = partDependent;
        this.partType = partType;
        this.partName = partName;
        this.partObject = partObject;
        this.partReferences = partReferences;
    }
    public Part(string partType, string partName, GameObject partObject, string[] partReferences){
        this.partType = partType;
        this.partName = partName;
        this.partObject = partObject;
        this.partReferences = partReferences;
    } */
    public Part(string partType, Button partButton, string partName, GameObject partObject, string[] partReferences){
        this.partType       = partType;
        this.partButton = partButton;
        this.partName       = partName;
        this.partObject     = partObject;
        this.partReferences = partReferences;
    }
    public Part(string partType, Button partButton, string partName, GameObject partObject, string[] partReferences, string partReferenceAnchorName){
        this.partType                   = partType;
        this.partButton = partButton;
        this.partName                   = partName;
        this.partObject                 = partObject;
        this.partReferences             = partReferences;
        this.partReferenceAnchorName    = partReferenceAnchorName;
    }
    public Part(string partType, Button partButton, string partName, GameObject partObject, string partReferenceAnchorName){
        this.partType       = partType;
        this.partButton = partButton;
        this.partName                   = partName;
        this.partObject                 = partObject;
        this.partReferenceAnchorName    = partReferenceAnchorName;
    }
    public Part(string partType, Button partButton, string partName, GameObject partObject){
        this.partType       = partType;

        this.partButton = partButton;
        this.partName       = partName;
        this.partObject     = partObject;
    }
    public class simplePart : Part{

    }
}
