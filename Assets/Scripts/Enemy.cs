using UnityEngine;

public class Enemy : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private float xPosition;
    [SerializeField] Ball ball;

    private float speed = 2.5f;

    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        xPosition = rigidbody.position.x;
    }

    private void FixedUpdate()
    {
        Rigidbody2D ballRigidBody = ball.GetComponent<Rigidbody2D>();

        if (ballRigidBody.velocity.x > 0f)
        {
            Vector3 ballPosition = ball.GetComponent<Transform>().position;

            if (ballPosition.y > rigidbody.position.y)
            {
                rigidbody.AddForce(Vector2.up * speed);
            }
            else if (ballPosition.y < rigidbody.position.y)
            {
                rigidbody.AddForce(Vector2.down * speed);
            }
        }
        else if (ballRigidBody.velocity.x < 0f)
        {
            if (transform.position.y > 0)
            {
                rigidbody.AddForce(Vector2.down * (speed * rigidbody.velocity.y));
            }
            else if (transform.position.y < 0)
            {
                rigidbody.AddForce(Vector2.up * (speed * -rigidbody.velocity.y));
            }
        }


        //rigidbody.MovePosition(new Vector2(xPosition, GetBallY()));
    }

    private float GetBallY()
    {
        return ball.GetComponent<Transform>().position.y;
    }
}
