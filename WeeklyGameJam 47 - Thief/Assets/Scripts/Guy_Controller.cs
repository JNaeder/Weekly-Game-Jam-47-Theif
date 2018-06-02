using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guy_Controller : MonoBehaviour {


    public float speed, jump, fallMult, jumpMult;

    float h;
    bool isTouchingGround, isCrouching;

    Animator anim;
    Rigidbody2D rB;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rB = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update() {
        h = Input.GetAxis("Horizontal");
        Vector3 transScale = transform.localScale;
        anim.SetFloat("hspeed", Mathf.Abs(h));
        anim.SetBool("isTouchingGround", isTouchingGround);
        anim.SetBool("isCrouching", isCrouching);

        //Move
        if (!isCrouching) {
            if (isTouchingGround) {

                transform.position += new Vector3(h * Time.deltaTime * speed, 0, 0);
            }
            else {
                transform.position += new Vector3(h * Time.deltaTime * speed * 0.8f, 0, 0);

            }
        }
    
        
        
        //Flip
        if (h < 0)
        {
            transScale = new Vector3(-1, 1, 1);
        }
        else if (h > 0) {
            transScale = new Vector3(1, 1, 1);
        }
        transform.localScale = transScale;

        // Jumping
        if (isTouchingGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rB.AddForce(Vector2.up * 100 * jump);

            }
        }
        //Crouching
        if (Input.GetAxis("Vertical") < 0)
        {
            isCrouching = true;
        }
        else {
            isCrouching = false;
        }

        //Fall Better
        if (rB.velocity.y < 0) {
            rB.velocity += Vector2.up * Time.deltaTime * (fallMult - 1) * Physics2D.gravity.y;
        }
        if (rB.velocity.y > 0)
        {
            rB.velocity += Vector2.up * Time.deltaTime * (jumpMult - 1) * Physics2D.gravity.y;
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        isTouchingGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isTouchingGround = false;
    }
}
