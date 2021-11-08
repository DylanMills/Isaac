using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject tearObject;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Projectile();
        }
    }

    void Projectile()
    {
        Instantiate(tearObject, shootPoint.position, shootPoint.rotation);
    }
}
