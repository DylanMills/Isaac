using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tear : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float tearSpeed = 75f;
    void Start()
    {
        rigidBody.velocity = transform.right * tearSpeed;
    }
}
