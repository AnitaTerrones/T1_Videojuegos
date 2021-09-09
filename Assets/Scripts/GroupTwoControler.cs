using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupTwoControler : MonoBehaviour
{
    private Rigidbody2D rb;

    public float velocityY= 15;
    private const int LAYER_GROUND = 6;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision con el suelo -  salta
        if (collision.gameObject.layer == LAYER_GROUND)
        {
            rb.velocity = new Vector2(rb.velocity.x, velocityY);//cambia velocidad en Y
        }
    }
}
