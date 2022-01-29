using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed = 5f;

    Rigidbody2D rb2D => GetComponent<Rigidbody2D>();
    private float xVelocity = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb2D.velocity = new Vector2(xVelocity * movementSpeed, rb2D.velocity.y);
    }

    private void OnMove(InputValue value){
        xVelocity = value.Get<Vector2>().x;
    }
}
