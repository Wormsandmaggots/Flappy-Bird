using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpPower;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        OnTapJump();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Dead();
    }

    private void OnTapJump()
    {
        if((Input.touchCount > 0 && (Input.GetTouch(0).tapCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpPower;
        }
    }

    private void Dead()
    {
        GameManager.instance.GameOver();
    }
}
