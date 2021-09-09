using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaControler : MonoBehaviour
{
    //public properties
    public float velocityX = 15;
    public float JumpForce = 50;
    
    //private components
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;

    
    private const int ANIMATION_RUN = 0;
    private const int ANIMATION_JUMP = 1;
    private const int ANIMATION_DEAD = 2;
    private const int ANIMATION_IDLE = 3;
    
    private bool isDead = false;

    void Start()
    {
       sr = GetComponent<SpriteRenderer>();
       rb = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Si el Nija esta vivo
        if(!isDead)
        {
            rb.velocity = new Vector2(velocityX, rb.velocity.y);
            changeAnimation(ANIMATION_RUN);

            //Saltar
            if(Input.GetKeyUp(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
                changeAnimation(ANIMATION_JUMP);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision con zombie
        if (collision.gameObject.tag == "Zombie")
        {
            Debug.Log("muere");
            isDead = true;
            changeAnimation(ANIMATION_DEAD);
        }
    }
    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
}

