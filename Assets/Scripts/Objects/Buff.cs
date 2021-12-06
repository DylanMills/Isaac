using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    string type;
    string uiText;

    [SerializeField] GameObject bombGood;
    [SerializeField] GameObject bombBad;

    UIControl ui;

    void Awake()
    {
        ui = GameObject.Find("UIController").GetComponent<UIControl>();

        switch (Random.Range(0, 5))
        {
            case 0: type = "speed"; uiText = "SPEED UP!!";  break;
            case 1: type = "power"; uiText = "DMG UP!"; break;
            case 2: type = "fire"; uiText = "TEARS UP!"; break;
            case 3: type = "bombs!"; uiText = "BOMBS!!"; break;
            case 4: type = "bombs."; uiText = "BOMBS...?"; break;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (type)
            {
                case "speed": collision.gameObject.GetComponent<PlayerMovement>().maxSpeed += 5; break;
                case "power": collision.gameObject.GetComponent<Shoot>().damage += 2; break;
                case "fire": collision.gameObject.GetComponent<InputHandler>().shootDelay *= .65f; break;
                case "bombs!": Bombs(false); break;
                case "bombs.": Bombs(true); break;
            }
            ui.SetSplash(uiText);

            Destroy(gameObject);
        }
    }

    void Bombs(bool bad)
    {
        GameObject bomb;

        if (bad)
        {
            bomb = bombBad;
        }
        else
        {
            bomb = bombGood;
        }

        Instantiate(bomb, transform.position + Vector3.up * 3, Quaternion.Euler(Vector3.zero));
        Instantiate(bomb, transform.position + Vector3.right * 3, Quaternion.Euler(Vector3.zero));
        Instantiate(bomb, transform.position - Vector3.right * 3, Quaternion.Euler(Vector3.zero));
    }
}
