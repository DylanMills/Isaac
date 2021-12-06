using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    Player player;
    PlayerMovement playerMove;
    Shoot shooter;

    [SerializeField] GameObject bomb;
    [SerializeField] public float shootDelay = 0.1f;

    float timeToNextShot;
    private void Awake()
    {
        player = GetComponent<Player>();
        playerMove = GetComponent<PlayerMovement>();
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

        playerMove.SetInputVector(inputVector);

        if (CanShoot() && (Mathf.Abs(hFire) > 0 || Mathf.Abs(vFire) > 0))
        {
            shooter.Projectile(hFire, vFire);
        }

        if (Input.GetKeyDown(KeyCode.E) && player._bombs > 0)
        {
            player._bombs--;
            Instantiate(bomb, transform.position - transform.up, Quaternion.Euler(0, 0, 0));
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
