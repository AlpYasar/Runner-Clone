using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finisher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Working on trigger");
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerStats>().isFinished = true;
            Debug.Log("Working with player");
            
        }
    }
}
