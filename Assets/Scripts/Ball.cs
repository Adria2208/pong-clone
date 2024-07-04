using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private new Rigidbody2D rigidbody;

    private float baseSpeed = 8f;
    private float maxSpeed = 13f;
    private float currentSpeed;
    private Vector2 currentVelocity;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetBall();
    }

    public void ResetBall()
    {
        transform.position = Vector3.zero;
        AddStartingForce();
    }

    private void AddStartingForce()
    {
        float x = Random.value < 0.5 ? 1f : -1f;
        float y = Random.value < 0.5f ? Random.Range(-1f, -0.5f)
                                      : Random.Range(0.5f, 1f);
        Vector2 direction = new Vector2(x, y).normalized;

        rigidbody.AddForce(direction * baseSpeed, ForceMode2D.Impulse);
        currentSpeed = baseSpeed;
    }

    private void FixedUpdate()
    {
        Vector2 direction = rigidbody.velocity.normalized;
        rigidbody.velocity = direction * currentSpeed;
        currentVelocity = rigidbody.velocity;

        if (currentSpeed == 0)
        {
            ResetBall();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 inDirection = new Vector2(currentVelocity.x, currentVelocity.y);
        Vector2 inNormal = collision.GetContact(0).normal;
        Vector2 newVelocity = Vector2.Reflect(inDirection, inNormal);
        if (currentSpeed < maxSpeed)
        {
            currentSpeed = currentSpeed + 1f;
        }

        rigidbody.velocity = newVelocity;
        currentVelocity = newVelocity;
    }

}
