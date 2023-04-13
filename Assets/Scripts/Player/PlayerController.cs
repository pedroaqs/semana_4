using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    
    const int IDLE = 0;
    const int RUN = 1;
    const int JUMP = 2;

    const int velocidad1 = 5;
    const int velocidad2 = 10;
    const int velocidad3 = 15;
    const int fuerzaSalto = 5;
    public int velocidad;

    public Pies pies;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        velocidad = velocidad1;
    }

 
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);  
        _setAnimacion(IDLE);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocidad, rb.velocity.y);
          
            sr.flipX = false;
            _setAnimacion(RUN);   
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);
           sr.flipX = true;
           _setAnimacion(RUN);   
          
        }

        if (Input.GetKeyDown(KeyCode.Space) && pies.puedeSaltar)
        {
           
            rb.AddForce(new Vector2(0,fuerzaSalto),ForceMode2D.Impulse);
            _setAnimacion(JUMP);
           pies.puedeSaltar = false;
        }

    }

    private void _setAnimacion(int animacion)
    {
        animator.SetInteger("Estado", animacion);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        

         if(other.gameObject.tag == "Zombie"){
            velocidad = velocidad2;
         }

          if(other.gameObject.tag == "Zombie2"){
            velocidad = velocidad3;
         }


    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag == "Enemy"){
            Time.timeScale = 0;
         }
    }
}
