using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject tear;
    GameObject bullet;

    public void Projectile(float h, float v)
    {
        var dir = Quaternion.Euler(new Vector3(0, 0, 0));

        if (h > 0)
        {
            dir = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        if (h < 0)
        {
            dir = Quaternion.Euler(new Vector3(0, 0, 180));
        }
        if (v > 0)
        {
            dir = Quaternion.Euler(new Vector3(0, 0, 90));
        }
        if (v < 0)
        {
            dir = Quaternion.Euler(new Vector3(0, 0, 270));

        }
        bullet = Instantiate(tear, shootPoint.position, dir);
        Destroy(bullet, 1);
    }
}
