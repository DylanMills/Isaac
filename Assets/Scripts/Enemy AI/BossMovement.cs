using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    float speed = 20f;
    float attackDelay;

    bool halfHealth;
    bool isMoving;

    Vector2 attackDirection;

    Enemy enemy;
    Rigidbody2D body;
    SpriteRenderer sprite;

    Transform playerTransform;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
        sprite = GetComponent<SpriteRenderer>();

        playerTransform = GameObject.Find("Isaac").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.GetHealth() < 100)
        {

            if (Time.realtimeSinceStartup >= attackDelay)
            {
                Attack();
                isMoving = true;
            }

            if (Time.realtimeSinceStartup >= attackDelay + 1f)
            {
                isMoving = false;

                body.velocity = Vector2.zero;

                if (!halfHealth)
                {
                    attackDelay = Time.realtimeSinceStartup + 1f;
                }
                else
                {
                    attackDelay = Time.realtimeSinceStartup + .5f;

                    sprite.color = new Color(1, .5f, .5f);
                }
            }

            halfHealth = enemy.GetHealth() <= 50;
        }
        else
        {
            attackDelay = Time.realtimeSinceStartup + .2f;
        }
    }

    void Attack()
    {
        if (!isMoving)
        {
            attackDirection = (playerTransform.position - transform.position).normalized;
        }

        if (!halfHealth)
        {
            body.velocity = attackDirection * speed;
        }
        else
        {
            body.velocity = attackDirection * speed * 2f;
        }
    }
}
