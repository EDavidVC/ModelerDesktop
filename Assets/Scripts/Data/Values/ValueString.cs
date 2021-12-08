using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueString : MonoBehaviour
{
    private Dictionary<string, string> templateName;
    public static readonly List<string> decorables = new List<string>()
    {
        "Iron"
    };
    private Dictionary<string, string> materialname;
    public ValueString(){



        templateName = new Dictionary<string, string>();
        materialname = new Dictionary<string, string>();

        templateName.Add("door","Puerta");
        templateName.Add("window","Ventana");
        templateName.Add("desk","Mueble");

        templateName.Add("simpleDoor","Puerta de una Seja");
        templateName.Add("bigDoor","Porton de dos Sejas");
        templateName.Add("simpleWindow","Ventana sin Ventilacion");

        materialname.Add("SquareBar", "Barra Cuadrada");
        materialname.Add("Tees", "TE 'T'");
        materialname.Add("Angle", "Angulo");
        materialname.Add("TubeSquare", "Tubo Cuadrado");
        materialname.Add("TubeRound", "Tubo Circular");
        materialname.Add("TubeRetangular", "Tubo Rectangulo");
        materialname.Add("Iron", "Plancha Metalica");

    }

    public string getName(string name){
        string translateName;
        try{
            translateName = templateName[name];
            return translateName;            
        }catch{
            return "";
        }
    }
    public string getNameMaterial(string name){
        string translateName = "";
        try{
            translateName = materialname[name];
            return translateName;            
        }catch{
            return name;
        }
    }

    public Material formatTextToMaterial(string materialName){

        string NameEN               = "" ;
        string TypeProperties       = "" ;
        string Properties           = "" ;
        string Orientation          = "" ;
        string medeasure            = "" ;
        string Position             = "" ;

        string[] parts = new string[]{NameEN, TypeProperties, Properties, Orientation, medeasure, Position};
        int position = 0;

        for(int i = 0; i < materialName.Length; i++){
            
            if(materialName.Substring(i, 1) == "_"){
                position++;
            }else if(materialName.Substring(i, 1) == "."){
                i = materialName.Length + 10;
            }else{
                parts[position] += materialName.Substring(i , 1);
            }

        }

        print(
            parts[0] +    // Name
                parts[1] +   // Type Property
                parts[2] +   // Property
                parts[3] +   // Orientation
                parts[4] +   // Medeashure
                parts[5] 
        );

        if( parts[5] != "" ){
            Material tempMaterial;
            tempMaterial = new Material(
                parts[0],   // Name
                parts[1],   // Type Property
                parts[2],   // Property
                parts[3],   // Orientation
                parts[4],   // Medeashure
                parts[5]    // Position
            );
            return tempMaterial;
            
        }else{
            Material error = new Material();
            error.nameEN = "coco";
            return error;
        }
        
    }
}
