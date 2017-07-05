using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitGame : MonoBehaviour
{
    public void noPlay()
    {
        print("Ready to terminate game");
        Application.Quit();
        print("Game is gone??");
    }
}