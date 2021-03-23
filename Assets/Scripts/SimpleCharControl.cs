using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR;

public class SimpleCharControl : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private LayerMask _aimLayerMask;
    public Animator animator;
    private Vector3 _movement = new Vector3(1, 0, 0);

    
    [Header("Camera Params")]
    private Vector3 _cameraPosition;
    public float camXOffset;
    public float camOfY;
    public float camOfZ;
    private static readonly int IsRunning = Animator.StringToHash("isRunning");

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        CameraController();
        MauseCountrol();
        FallController();


    }

    private void CameraController()
    {
        _cameraPosition = new Vector3(transform.position.x -camXOffset, camOfY, transform.position.z);
        Camera.main.transform.position = _cameraPosition;
    }

    private void MauseCountrol()
    {
        //Animation is controlled by left mouse click
        
        //Vector3 movement = new Vector3(1, 0, 0);
        //_movement.Normalize();
        //_movement *= _speed * Time.deltaTime;
        _movement *= _speed * Time.deltaTime;
        //transform.Translate(_movement, Space.World);

        if (Input.GetMouseButton(0)) transform.Translate(_movement, Space.World);

        animator.SetBool("isRunning", Input.GetMouseButton(0));

        
        //animator.SetBool("isRunning", false);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitObject, Mathf.Infinity, _aimLayerMask))
        {
            
            
            //Debug.Log("RayCast");
            var direction = hitObject.point - transform.position;
            direction.y = 0f;
            direction.Normalize();
            transform.forward = _movement = direction;
        }
    }

    public void FallController()
    {
        if (transform.position.y < -0.5f)
        {
            transform.position = new Vector3(-1.75f, 1f, Random.Range(-0.25f, 0.25f));
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obs")
        {
            transform.position = new Vector3(-1.75f, 1f, Random.Range(-0.25f, 0.25f));
        }
    }
} 
