using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tear : MonoBehaviour
{
    [SerializeField] float tearSpeed = 75f;
    int tearDamage = 1;

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

    public void SetDamage(int damage)
    {
        tearDamage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D bodyOther) && collision.tag != "Enemy")
        {
            bodyOther.AddForce(body.velocity.normalized * 10f, ForceMode2D.Impulse);
        }

        if (collision.tag != "Enemy" && collision.tag != "Floor")
        {
            Destroy(gameObject);
        }
    }
}
