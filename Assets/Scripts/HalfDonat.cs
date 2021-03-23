using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDonat : MonoBehaviour

{   [Header("Horizontal")]
    public bool isHorizontal = true;
    [Range(0, 1)] public float offsetA;
    [Range(0, 1)] public float offsetB;
    
    private Vector3 _posA;
    private Vector3 _posB;
    [SerializeField] private float _speed = 0.2f;
    private bool _firstA = true;
    
    [Header("Rotational")]
    
    [SerializeField] private float _rotationSpeed =  -2f;
    [SerializeField] private bool _clockWise = true;

    void Start()
    {
        RouteSetter();
    }
    void Update()
    {

        if (isHorizontal)
        {
            HorizMovement();
        }
        else
        {
            transform.Rotate(_clockWise ? new Vector3(_rotationSpeed, 0, 0) : new Vector3(-_rotationSpeed, 0, 0));
        }
        
        
        
    }
    
    private void RouteSetter()
    {
        var objPos = transform.position;
        _posA = new Vector3(objPos.x, objPos.y, objPos.z + offsetA);
        _posB = new Vector3(objPos.x, objPos.y, objPos.z - offsetB); 
    }
    
    private void HorizMovement()
    {
        var step =  _speed * Time.deltaTime; // calculate distance to move
        if (_firstA) 
        {
            
            if (Vector3.Distance(transform.position, _posA ) > 0.04f)
            {
                transform.position = Vector3.MoveTowards(transform.position, _posA, step);
            }
            else
            {
                _firstA = false; 
            }
            
        }
        else
        {
            
            if (Vector3.Distance(transform.position, _posB ) > 0.04f)
            {
                transform.position = Vector3.MoveTowards(transform.position, _posB, step);
            }
            else
            {
                _firstA = true; 
            }
            
        }
    }
}
