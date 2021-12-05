using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] int _health = 100;
    [SerializeField] Text deathText;

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
        deathText.text = "You Died";
        Invoke("ResetLevel", 5);
    }

    void ResetLevel()
    {
        SceneManager.LoadScene("SampleScene");
        deathText.text = "";
    }

    void ResetInvincibility()
    {
        invincibility = false;

        renderer.material.color = Color.white;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!invincibility && collision.gameObject.tag == "Enemy" && GetComponent<Renderer>().isVisible)
        {
            takeDamage(collision.gameObject.GetComponent<Enemy>().GetContactDamage());

            invincibility = true;

            renderer.material.color = Color.red;
        }

        Invoke("ResetInvincibility", 1f);
    }
}
