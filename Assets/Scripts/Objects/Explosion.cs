using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    float explosionForce = 4f;
    
    [SerializeField] int damage = 2;

    void Awake()
    {
        Destroy(gameObject, .1f);
    }

    public int GetDamage()
    {
        return damage;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D body;
        if (other.gameObject.TryGetComponent<Rigidbody2D>(out body))
        {
            Vector2 outwardForce = Vector3.Normalize(other.transform.position - transform.position);

            body.AddForce(outwardForce * explosionForce, ForceMode2D.Impulse);
        }
    }
}
