using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    SpriteRenderer sprite;

    bool isTinted;

    [SerializeField] Sprite tintedRock;
    [SerializeField] GameObject soulHeart;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();

        if (Random.Range(0, 19) == 0 &! isTinted)
        {
            isTinted = true;
            sprite.sprite = tintedRock;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Explosion")
        {
            if (isTinted)
            {
                Instantiate(soulHeart, transform.position + Vector3.right, Quaternion.Euler(Vector3.zero));
                Instantiate(soulHeart, transform.position - Vector3.right, Quaternion.Euler(Vector3.zero));
            }

            Destroy(gameObject);
        }
    }
}
