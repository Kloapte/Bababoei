using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;

    public float maxSpeed = 10f;
    private bool facingRight = true;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    //Called on a static interval(Time.deltaTime update)
    private void FixedUpdate()
    {
        //float move = Input.GetAxis("Horizontal");
        float move = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move = -1f * maxSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            move = 1f * maxSpeed;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            move *= 2;
        }

        Debug.Log("Speed: " + Mathf.Abs(move));
        anim.SetFloat("Speed", Mathf.Abs(move));
        rigidbody2D.velocity = new Vector2(move, rigidbody2D.velocity.y);

        if(move > 0 && !facingRight)
        {
            Flip();
        }
        else if(move < 0 && facingRight)
        {
            Flip();
        }
    }


    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
