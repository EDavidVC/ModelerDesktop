using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class messageControl : MonoBehaviour
{
    public void closeThis(){
        controlViews cv = GameObject.Find("globalData").GetComponent<controlViews>();
        cv.closeView("FloatViewSelected");
    }
}
