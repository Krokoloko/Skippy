using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class pointManager : MonoBehaviour {

    public Text points;
    private GameObject[] pointsInGame;
    private int totalPoints;
    private int ToGet;

	void Start () {
        points.text = "0";
        totalPoints = 0;
        pointsInGame = GameObject.FindGameObjectsWithTag("Star");
        ToGet = pointsInGame.Length;
	}

    void Update () {
        if (points.text == ToGet.ToString())
        {
            points.color = Color.green;
        }
        points.text = totalPoints.ToString();
    }
    public void countPoint()
    {
        totalPoints++;
        print(totalPoints);
    }
    public void resetOriginPoint()
    {
        totalPoints = 0;
    }
}
