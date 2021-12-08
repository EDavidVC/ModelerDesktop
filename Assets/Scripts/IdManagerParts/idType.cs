using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idType : MonoBehaviour
{
    public string idTypeText {get;}
    void Start()
    {
        
    }
    public idType(){
        idTypeText="dontSelected";
    }
    public idType(string idType){
        this.idTypeText = idType;
    }
}
