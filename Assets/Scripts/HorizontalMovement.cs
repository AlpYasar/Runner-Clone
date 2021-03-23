using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour 
{
    [Header("Points")]
    [Range(0, 1)] public float offsetA;
    [Range(0, 1)] public float offsetB;
    
    public bool isHorizontal = true;
    
    [Header("Paremeters")]
    
    [DrawIf("isHorizontal", true)][SerializeField] private float _speed = 0.2f;
    [DrawIf("isHorizontal", true)][SerializeField] private bool _firstA = true;
    private Vector3 _posA;
    private Vector3 _posB;
    
    private Vector3 _centerPosition;
    private float _angle = 0;
    [DrawIf("isHorizontal", false)] [Range(0, 1)] public float radius = 0.25f;
    [DrawIf("isHorizontal", false)] [SerializeField] private float _roundPerSecond = 4f;
    [DrawIf("isHorizontal", false)] public bool clockWise = true;
    

    // Start is called before the first frame update
    void Start()
    {
        RouteSetter();

        var position = transform.position;
        _centerPosition = new Vector3(position.x-radius, position.y, position.z);
        Debug.Log(_centerPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (isHorizontal)
        {
            HorizMovement();
        }
        else
        {
            CircularMovement();
        }
    }
    
    //These Gizmos help level desing
    void OnDrawGizmosSelected()
    {
        if (!Application.isPlaying)
        {
            RouteSetter();
        }

        Gizmos.color = new Color(1, 0, 0, 0.5f);
        if (isHorizontal)
        {
            // Draw two semitransparent red cube at the A and the B positions
            Gizmos.DrawCube(_posA, new Vector3(0.05f,0.2f, 0.05f));
            Gizmos.DrawCube(_posB, new Vector3(0.05f,0.2f, 0.05f));
        }
        else
        {
            // Draw a Sphere to show curcilar movement radius
            var position = transform.position;
            Gizmos.DrawWireSphere(new Vector3(position.x - radius , position.y - 0.12f, position.z), radius);
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
    
    private void CircularMovement()
    {
        
        //2*PI s is 360, dividing will make slower
        float speed = (2 * Mathf.PI) / _roundPerSecond; 
        
        
        //DirectionChanger
        if (clockWise) _angle -= speed*Time.deltaTime; 
        else _angle += speed*Time.deltaTime; 
        
        transform.position = new Vector3((_centerPosition.x + Mathf.Cos(_angle)*radius), _centerPosition.y,_centerPosition.z + Mathf.Sin(_angle)*radius);
        
    }
}
