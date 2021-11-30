using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] int _health = 100;

    Renderer renderer;

    private bool invincibility = false;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (_health < 1)
        {
            Die();
        }
    }

    public void takeDamage(int damage)
    {
        _health -= damage;
    }

    public void Die()
    {
        Debug.Log("You (technically) Died");
        SceneManager.LoadScene("SampleScene");
    }

    void ResetInvincibility()
    {
        invincibility = false;

        renderer.material.color = Color.white;

        Debug.Log("clear, NOT invincible, normal");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!invincibility && collision.gameObject.tag == "Enemy" && GetComponent<Renderer>().isVisible)
        {
            takeDamage(collision.gameObject.GetComponent<Enemy>().GetContactDamage());

            invincibility = true;

            renderer.material.color = Color.red;

            Debug.Log("damaged, invincible, red");
        }

        Invoke("ResetInvincibility", 1f);
    }
}
