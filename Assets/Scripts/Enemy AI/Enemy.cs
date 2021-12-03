using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int _health = 1;

    [SerializeField] int enemyContactDamage = 1;

    void Update()
    {
        if (_health < 1)
        {
            Die();
        }
    }

    public int GetContactDamage()
    {
        return enemyContactDamage;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tear" && GetComponent<Renderer>().isVisible)
        {
            TakeDamage(collision.gameObject.GetComponent<Tear>().GetDamage());

            Destroy(collision.gameObject);
        }

        if (collision.tag == "Explosion" && GetComponent<Renderer>().isVisible)
        {
            TakeDamage(collision.gameObject.GetComponent<Explosion>().GetDamage());
        }
    }
}
