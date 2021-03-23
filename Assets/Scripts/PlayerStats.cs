using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    
    public GameObject finishCollider;
    public float distance;
    public bool isFinished = true;
    public bool isPlayer= false;


    void Start()
    {
        distance = Vector3.Distance (transform.position, finishCollider.transform.position);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!isFinished)
        {
            distance = Vector3.Distance (transform.position, finishCollider.transform.position);
        }else if (isFinished && !isPlayer)
        {
            gameObject.SetActive(false);
        }
    }
}
