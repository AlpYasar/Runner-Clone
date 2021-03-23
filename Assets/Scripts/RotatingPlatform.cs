using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [SerializeField] private bool clockWise = false;
    public float rotationSpeed = 0.2f;
    private float _speed;
    void Update()
    {
        _speed = (clockWise) ? -rotationSpeed : rotationSpeed;
        transform.Rotate(clockWise ? new Vector3(0f, 0, rotationSpeed) : new Vector3(0f, 0, -rotationSpeed));
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player is on the RotatingPlatform");
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0.1f, 0f, _speed * (float) Math.PI);
        }

    }
}
