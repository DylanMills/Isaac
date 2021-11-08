using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearDirection : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float tearSpeed = 75f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody.velocity = transform.right * tearSpeed;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("")
    //    Destroy(gameObject)
    //}
}
