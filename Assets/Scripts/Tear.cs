using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tear : MonoBehaviour
{
    [SerializeField] float tearSpeed = 75f;
    [SerializeField] int tearDamage = 1;

    Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.velocity = transform.right * tearSpeed;
    }

    public int GetDamage()
    {
        return tearDamage;
    }
}
