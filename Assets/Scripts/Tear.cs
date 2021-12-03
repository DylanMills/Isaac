using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tear : MonoBehaviour
{
    [SerializeField] float tearSpeed = 75f;
    [SerializeField] int tearDamage = 1;

    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        body.velocity = transform.right * tearSpeed;
    }

    public int GetDamage()
    {
        return tearDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Enemy" && collision.tag != "Floor")
        {
            Destroy(gameObject);
        }
    }
}
