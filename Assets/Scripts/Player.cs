using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private new Rigidbody2D rigidbody;
    private float xPosition;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        xPosition = rigidbody.position.x;
    }

    private void Update()
    {
        rigidbody.MovePosition(new Vector2(xPosition, GetMouseY()));
    }

    private float GetMouseY()
    {
        
        return Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
    }

}
