using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed = 5f;

    Rigidbody2D rb2D => GetComponent<Rigidbody2D>();
    SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();
    private float xVelocity = 0;
    private float yVelocity = 0;
    private bool spriteFlipped = false;

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

    void flipImage()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
        spriteFlipped = !spriteFlipped;
    }

    private void OnMove(InputValue value){
        Vector2 v = value.Get<Vector2>();
        xVelocity = v.x;
        yVelocity = v.y;

        if(v.x > 0f && !spriteFlipped)
        {
            flipImage();
        }
        if(v.x < 0f && spriteFlipped)
        {
            flipImage();
        }
    }
}
