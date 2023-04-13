using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieConroller : MonoBehaviour
{
    SpriteRenderer sr;
    Animator animator;
    public float velocity = 1f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _setAnimacion(1);
        rb.velocity = new Vector2 (-velocity,0);
        sr.flipX = true;
        
    }
    private void _setAnimacion(int animacion)
    {
        animator.SetInteger("Estado", animacion);
    }
}
