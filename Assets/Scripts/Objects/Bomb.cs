using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    SpriteRenderer sprite;
    Collider2D col;

    [SerializeField] GameObject explosion;

    float timer = 0f;
    float maxTime = 2f;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float percent = timer / maxTime;

        sprite.color = new Color(1, 1 - percent, 1 - percent);

        timer += Time.deltaTime;

        if (percent >= 1)
        {
            Instantiate(explosion, transform.position, Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);
        }

        col.enabled = !(percent <= .1f);

    }
}
