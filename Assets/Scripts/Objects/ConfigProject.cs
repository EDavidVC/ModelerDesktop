using System.Collections.Generic;

[System.Serializable]
public class ConfigProject
{
    public string typeProjectID;
    public string templateSelectedID;
    public List<string> parts;

    public ConfigProject()
    {
    }

    public ConfigProject(string typeProjectID, string templateSelectedID, List<string> parts)
    {
        this.typeProjectID = typeProjectID;
        this.templateSelectedID = templateSelectedID;
        this.parts = parts;
    }
}
