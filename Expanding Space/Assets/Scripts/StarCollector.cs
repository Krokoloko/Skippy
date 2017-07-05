using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCollector : MonoBehaviour {

    public GameObject pointObj;
    public pointManager_Two manage;
    public Text outPut;
    private GameObject[] pointsInGame;
    private Star thatStar;
    private int goingOut;
    private int ToGet;
    private AudioSource starEffect;
    
    void Start () {
        manage = pointObj.GetComponent<pointManager_Two>();
        goingOut = 0;
        outPut.text = "0";
        pointsInGame = GameObject.FindGameObjectsWithTag("Star");
        ToGet = pointsInGame.Length;
        starEffect = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (outPut.text == ToGet.ToString())
        {
            outPut.color = Color.green;

        }
        outPut.text = goingOut.ToString();
    }
    void OnTriggerEnter2D(Collider2D questionable)
    {
        
        if(questionable.tag == "Star")
        {
            thatStar = questionable.GetComponent<Star>();
			thatStar.Used ();

            if (thatStar.used == false)
            {
                thatStar.used = true;
                starEffect.Play();
                //Tel de punt op
                goingOut++;
            }
        }
    }
}
