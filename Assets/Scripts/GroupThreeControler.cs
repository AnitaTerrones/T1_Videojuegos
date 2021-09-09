using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupThreeControler : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    public float velocityY= 15;
    private const int LAYER_GROUND = 6;

    private int Cont = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision con el suelo -  salta
        if(Cont==0)
        {
            if (collision.gameObject.layer == LAYER_GROUND)
            {
                rb.velocity = new Vector2(rb.velocity.x, velocityY);//cambia velocidad en Y
                sr.flipX = false;
                Cont++;
            }
        }
        else if(Cont==1)
        {
            if (collision.gameObject.layer == LAYER_GROUND)
            {
                rb.velocity = new Vector2(rb.velocity.x, velocityY);//cambia velocidad en Y
                sr.flipX = true;
                Cont = 0;
            }
        }
    }
}
