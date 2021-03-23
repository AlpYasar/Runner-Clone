using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ForceCollider : MonoBehaviour
{
    private Vector3 normal = new Vector3(1, 0, 0);
    Vector3 forward;
    private bool _clockwise;

    void Start()
    {
        _clockwise  = GetComponentInParent<Rotator>().clockWise;

    }
    void Update()
    {
        
        forward = _clockwise ? transform.TransformDirection(new Vector3(1,0.4f,0)) * 10 
            : transform.TransformDirection(new Vector3(-1,0.4f,0)) * 10 ;
        
        Debug.DrawRay(transform.position, forward, Color.green);
    }
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Rigidbody>().AddForce(forward * 300f);
        }
    }
    
}
