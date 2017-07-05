using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {



    public Transform _target;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    //private Rigidbody _rigidBody;


    void LateUpdate()
    {
        //origin = _transform. (_transform.position.x, _transform.position.y);
        transform.position = new Vector3(Mathf.Clamp(_target.position.x, minX, maxX),Mathf.Clamp(_target.position.y, minY, maxY),transform.position.z);
        
    }
}
