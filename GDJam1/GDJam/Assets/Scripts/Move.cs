using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float xvelocity;
    public float Gravity;

    private bool inAir = false;

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

        Vector2 temp = rigidbody2D.velocity;

        if (temp.y > 0 && temp.y < 0.03)
        {
            inAir = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            xvelocity = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            xvelocity = 1;
        }

        if (Input.GetKey(KeyCode.Space) && !inAir)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            inAir = true;
        }
        
        rigidbody2D.AddRelativeForce(Vector2.down * Gravity + Vector2.right * xvelocity * speed);

        GetComponent<Transform>().rotation = Quaternion.identity;

        if (!inAir)
        {
            if (xvelocity >= 1) GetComponent<Animator>().Play("Moving Right");
            if (xvelocity <= -1) GetComponent<Animator>().Play("Moving Left");
            if (xvelocity == 0) GetComponent<Animator>().Play("Idle");
        }
        else
        {
            if (xvelocity >= 1) GetComponent<Animator>().Play("Jump Right");
            if (xvelocity <= -1) GetComponent<Animator>().Play("Jump Left");
            if (xvelocity == 0) GetComponent<Animator>().Play("Jump");
        }
        
        xvelocity = 0;
    }
}
