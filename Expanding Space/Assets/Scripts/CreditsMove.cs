using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CreditsMove : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3 move;

    void Start () {
    	    
	}
	
	// Update is called once per frame
	void Update () {
        float translation = speed * Time.deltaTime;

        transform.Translate(move * translation);
	}
    public void initialize(float speed, Vector3 direction)
    {
        this.speed = speed;
        this.move = direction;
    }
}

