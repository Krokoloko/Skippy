using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class finishLvl : MonoBehaviour {

    public bool finishLevel = false;
    private int _toGoForStars;
    private int _whatIHave = 0;
    private GameObject[] inGameStars;
    
    void Update()
    {
        inGameStars = GameObject.FindGameObjectsWithTag("Star");
        _toGoForStars = inGameStars.Length;
       //print(_toGoForStars);

        if (_toGoForStars == _whatIHave) print("no stars   : (");
        if (_whatIHave == _toGoForStars && !finishLevel)
        {
            print("Ready to escape");
            finishLevel = true;
            SceneManager.LoadScene("WinScreen");
        }
    }
}