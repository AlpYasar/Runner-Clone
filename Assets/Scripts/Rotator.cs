using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed;
    public bool clockWise = true;
    public GameObject stickObject;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (!clockWise) speed *= -1;
    }
    
    void Update()
    {
        
        transform.Rotate(0, speed * Time.deltaTime,0 );
    }
    
}
