using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour {

	private BoxCollider _platformCollider;

	void Awake	() {
		_platformCollider = GetComponent<BoxCollider>();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

