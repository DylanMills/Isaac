using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject explosion;

    public int _health = 100;
    public int _soulHealth = 0;
    public int _money = 0;
    public int _bombs = 1;

    Renderer render;

    Room currentRoom;

    private bool invincibility = false;

    void Start()
    {
        render = GetComponent<Renderer>();
    }

    void Update()
    {
        if (_health < 1)
        {
            Die();
        }
        _health = Mathf.Clamp(_health, 0, 100);
        _soulHealth = Mathf.Clamp(_soulHealth, 0, 100);
    }

    public void TakeDamage(int damage)
    {
        if (_soulHealth == 0)
        {
            _health -= damage;
            render.material.color = Color.red;
        }
        else
        {
            _soulHealth -= damage;
            if (_soulHealth < 0)
            {
                _health += _soulHealth;
                render.material.color = Color.red;
            }
            else
            {
                render.material.color = Color.magenta;
            }
        }

        invincibility = true;
        Invoke("ResetInvincibility", 1f);
    }

    public void Die()
    {
        gameObject.SetActive(false);

        Invoke("ResetGame", 2f);
    }

    void ResetInvincibility()
    {
        invincibility = false;

        render.material.color = Color.white;
    }

    void ResetGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public Room GetCurrentRoom()
    {
        return currentRoom;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!invincibility && collision.gameObject.tag == "Enemy" && GetComponent<Renderer>().isVisible)
        {
            TakeDamage(collision.gameObject.GetComponent<Enemy>().GetContactDamage());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Room collidedRoom = collision.GetComponentInParent<Room>();

            if (collidedRoom != currentRoom)
            {
                currentRoom = collidedRoom;

                currentRoom.EnterRoom();
            }
        }

        if (collision.tag == "Explosion" && GetComponent<Renderer>().isVisible)
        {
            TakeDamage(collision.gameObject.GetComponent<Explosion>().GetDamage());
        }
    }
}
