using System;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private Rigidbody2D body;

    [SerializeField] private float accelerationPower;
    [SerializeField] private float hInput = 0;
    [SerializeField] private float vInput = 0;
    [SerializeField] private float forceY = 0;
    [SerializeField] private float forceX = 0;
    [SerializeField] private float maxSpeed;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
    }

    private void ApplyForce()
    {
        if (body.velocity.magnitude > maxSpeed)
        {
          forceX *= 0.8f;
            forceY *= 0.8f;
        }

        if (body.velocity.y < maxSpeed && body.velocity.y > -maxSpeed)
        {
            body.AddForce(transform.up * forceY, ForceMode2D.Force);
        }
        if (body.velocity.x < maxSpeed && body.velocity.x > -maxSpeed)
        {
            body.AddForce(transform.right * forceX, ForceMode2D.Force);
        }

    }

    private void FixedUpdate()
    {
        ApplyForce();
    }

    public void SetInputVector(Vector2 inputVector)
    {
        vInput = inputVector.y;
        hInput = inputVector.x;
        forceY = Math.Abs(inputVector.y) * inputVector.y * accelerationPower;
        forceX = Math.Abs(inputVector.x) * inputVector.x * accelerationPower;
    }
}