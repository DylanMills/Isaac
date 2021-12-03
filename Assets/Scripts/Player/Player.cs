using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] int _health = 100;

    [SerializeField] GameObject explosion;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentRoom.SetComplete();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(explosion, transform.position, Quaternion.Euler(0, 0, 0));
        }
    }

    public void TakeDamage(int damage)
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

        render.material.color = Color.white;

        Debug.Log("clear, NOT invincible, normal");
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

            invincibility = true;

            render.material.color = Color.red;

            Debug.Log("damaged, invincible, red");
        }

        Invoke("ResetInvincibility", 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Room collidedRoom = collision.GetComponentInParent<Room>();

            if (collidedRoom != currentRoom)
            {
                currentRoom = collidedRoom;

                Debug.Log(currentRoom.name);

                currentRoom.EnterRoom();
            }
        }

        if (collision.tag == "Explosion" && GetComponent<Renderer>().isVisible)
        {
            TakeDamage(collision.gameObject.GetComponent<Explosion>().GetDamage());
        }
    }
}
