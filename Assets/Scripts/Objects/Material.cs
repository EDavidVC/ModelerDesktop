using UnityEngine;

public class Material : MonoBehaviour
{
    private string _nameEN;             // Name in English   exp: SquareBar
    private string _nameES;             // Name in Spanish   exp: Barra Cuadrada
    private string _typeProperty;       // Type of property  exp: (milimeter) mm, (meter) mtr, (centimeter) cntmr, (inch) inch
    private string _properties;         // Properties of     exp: description of maerials how 500mm, 3inchs 
    private string _orientation;        // Orientation can be
    private string _price;              // Price of material for unit
    private string _medeasure;          // Medeasure scale 1 example 3mts
    private string _position;           // can be extern and intern

    public string nameEN            {get{return _nameEN;}       set{_nameEN = value;}}
    public string nameES            {get{return _nameES;}       set{_nameES = value;}}
    public string typeProperty      {get{return _typeProperty;} set{_typeProperty = value;}}
    public string properties        {get{return _properties;}   set{_properties = value;}}
    public string orientation       {get{return _orientation;}  set{_orientation = value;}}
    public string price             {get{return _price;}        set{_price = value;}}
    public string medeasure         {get{return _medeasure;}    set{_medeasure = value;}}
    public string position          {get{return _position;}     set{_position = value;}}

    public Material(){}
    public Material(string nameEN, string nameES, string typeProperty, string properties, string orientation, string price, string medeasure, string position)
    {
        this.nameEN = nameEN;
        this.nameES = nameES;
        this.typeProperty = typeProperty;
        this.properties = properties;
        this.orientation = orientation;
        this.price = price;
        this.medeasure = medeasure;
        this.position = position;
    }
    public Material(string nameEN, string typeProperty, string properties, string orientation, string medeasure, string position)
    {
        this.nameEN = nameEN;
        this.typeProperty = typeProperty;
        this.properties = properties;
        this.orientation = orientation;
        this.medeasure = medeasure;
        this.position = position;
    }
    public Material(string nameEN, string typeProperty, string properties, string orientation, string medeasure)
    {
        this.nameEN = nameEN;
        this.typeProperty = typeProperty;
        this.properties = properties;
        this.orientation = orientation;
        this.medeasure = medeasure;
    }
}
