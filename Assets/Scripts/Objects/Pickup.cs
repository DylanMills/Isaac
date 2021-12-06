using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] string type;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player p = collision.gameObject.GetComponent<Player>();

            switch (type)
            {
                case "penny": p._money++; break;
                case "nickel": p._money += 5; break;
                case "bomb": p._bombs++; break;
                case "heart": p._health += 10; break;
                case "halfHeart": p._health += 5; break;
                case "soulHeart": p._soulHealth += 10; break;
            }

            Destroy(gameObject);
        }
    }
}
