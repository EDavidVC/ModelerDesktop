using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class infoExport : MonoBehaviour
{
     FileStream fileStream;
     string path;
     string directory = "";
     string filename = "";
    public infoExport()
    {
        directory = directory != "" ? Directory.CreateDirectory(directory).FullName : Directory.CreateDirectory(Path.Combine(Application.dataPath, "../Exportado/Proyectos")).FullName;
        filename = "modelo-"+System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-ffff") + ".json";
        
        string filepath = Path.Combine(directory, filename);

        Estructurer estructurer = GameObject.Find("globalData").GetComponent<Estructurer>();
        if(estructurer){
            estructurer.lastImageUrl = filepath;
        }
        path = filepath;
    }
    public void gerateJson(ArquitectureState arquitectureState){
        
        filename = "modelo-"+System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-ffff") + ".json";
        string filepath = Path.Combine(directory, filename);
        path = filepath;

        List<Part> parts = arquitectureState.parts;

        string type = arquitectureState.typeProjectID;
        string template = arquitectureState.templateSelectedID;
        

        List<string> partsDic = new List<string>();

        

        Dictionary<string, object> estructureModel = new Dictionary<string, object>();
        estructureModel.Add("typeProjectID", type);
        estructureModel.Add("templateSelectedID", template);
       

        foreach(Part part in parts){
            partsDic.Add(part.partName);
        }
        
        estructureModel.Add("parts", partsDic);

        string json = Newtonsoft.Json.JsonConvert.SerializeObject(estructureModel, Formatting.Indented);



        //System.IO.File.WriteAllText(Application.persistentDataPath + "/ModelData.json", json);

        File.WriteAllText(path, json);

        print(json);

    }    
    
    
    
    [System.Serializable]
    public class myPart : Part
    { }
}
