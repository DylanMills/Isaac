using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 0;
    Transform playerTransform;

    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        playerTransform = GameObject.Find("Isaac").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = (playerTransform.position - transform.position).normalized * speed;
    }
}
