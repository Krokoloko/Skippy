using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointManager_Two : MonoBehaviour {

    public Text outPut;
    public int goingOut;

	void Start () {
        goingOut = 0;
        outPut.text = "0";
	}
	
    void Update () {
        outPut.text = goingOut.ToString();

	}
    public void countingPoint()
    {
        goingOut++;
    }
    public void resetOriginPoint()
    {
        goingOut = 0;
    }
}
