using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    CarMovement car;
    Shoot shooter;

    [SerializeField] float shootDelay = 0.1f;

    float timeToNextShot;
    private void Awake()
    {
        car = GetComponent<CarMovement>();
        shooter = GetComponent<Shoot>();
    }
    // Update is called once per frame
    void Update()
    {
        float hFire = Input.GetAxis("HFire");
        float vFire = Input.GetAxis("VFire");
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");
        if (hFire != 0)
        {
            vFire = 0;
        }
        car.SetInputVector(inputVector);
        if (CanShoot()&& (Mathf.Abs(hFire)>0 || Mathf.Abs(vFire) > 0))
        {
            shooter.Projectile(hFire, vFire);
        }

    }
    private bool CanShoot()
    {
        if (timeToNextShot < Time.realtimeSinceStartup)
        {
            timeToNextShot = Time.realtimeSinceStartup + shootDelay;
            return true;
        }
        else
        {
            return false;
        }
    }
}
