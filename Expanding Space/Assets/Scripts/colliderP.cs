using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderP : MonoBehaviour {

    public double slower =1;
    public double faster =1;
    public double higher =1;
    private float n = 0;
    private int timeQuee;

    void OnTriggerEnter(Collider detect)
    {
        if (detect.tag == "Slow")
        {
            slower = 0.8;
            print("too slow");
        }

        if (detect.tag == "Speed")
        {
            faster = 1.6;
            print("too fast");
        }
        
        if(detect.tag == "Jump")
        {
            higher = 1.5;
            print("too high");

        }
        Destroy(detect.gameObject);
        
    }
    
}
