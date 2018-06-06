using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Guy_Controller : MonoBehaviour {


    public float speed, jump, fallMult, jumpMult;
    public ParticleSystem bloodPS;

    float h;
	bool isTouchingGround;
	public bool isHanging, isDead, isCaught;

	GameManager gM;

    Animator anim;
    Rigidbody2D rB;
    Vector3 transScale;
	Collider2D coll;

	Rigidbody2D[] rBs;

    [FMODUnity.EventRef]
    public string footstepsSound, landSound, jumpSound, deathSound, caughtSound;



    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rB = GetComponent<Rigidbody2D>();
		gM = FindObjectOfType<GameManager>();
		rBs = GetComponentsInChildren<Rigidbody2D>();
		coll = GetComponent<Collider2D>();
	}

    // Update is called once per frame
    void Update() {
        h = Input.GetAxis("Horizontal");
        transScale = transform.localScale;
        anim.SetFloat("hspeed", Mathf.Abs(h));
        anim.SetBool("isTouchingGround", isTouchingGround);
		anim.SetBool("isDead", isDead);
        anim.SetBool("isCaught", isCaught);
		anim.SetBool("isHanging", isHanging);

        //Move
        Movement();
        

    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		FMODUnity.RuntimeManager.PlayOneShot(landSound, transform.position);
	}




	private void OnCollisionStay2D(Collision2D collision)
    {
		if (collision.gameObject.tag == "Enemy")
		{
			//Collider2D coll = collision.gameObject.GetComponent<Collider2D>();
			//coll.enabled = false;
			//print("Shit!");
			Death();
		}
		else
		{         
			isTouchingGround = true;
            
        }
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy")
        {
            Death();
        }
	}

	private void OnCollisionExit2D(Collision2D collision)
    {
        isTouchingGround = false;
    }


	public void Death(){
        Instantiate(bloodPS, transform.position, Quaternion.identity);


        if (isDead == false) {
            FMODUnity.RuntimeManager.PlayOneShot(deathSound, transform.position);
        }


		anim.enabled = false;
		foreach(Rigidbody2D r in rBs){
			r.bodyType = RigidbodyType2D.Dynamic;
		}
		coll.enabled = false;



		isDead = true;




        gM.RestartScreen();

	}

    public void ResetEverything()
    {
        isDead = false;
        isCaught = false;
        anim.enabled = true;
        coll.enabled = true;
        foreach (Rigidbody2D r in rBs)
        {
            r.bodyType = RigidbodyType2D.Kinematic;
        }
        rB.bodyType = RigidbodyType2D.Dynamic;
        anim.SetBool("isDead", isDead);
        anim.Play("Movement");
    }

    public void GetCaught() {
        if (isCaught == false) {
            FMODUnity.RuntimeManager.PlayOneShot(caughtSound, transform.position);
        }
        isCaught = true;
        gM.CaughtScreen();
        

    }


    void Movement() {
		if (!isHanging)
		{
			if (!isDead)
			{
				if (!isCaught)
				{
					if (isTouchingGround)
					{

						transform.position += new Vector3(h * Time.deltaTime * speed, 0, 0);
					}
					else
					{
						transform.position += new Vector3(h * Time.deltaTime * speed * 0.8f, 0, 0);

					}




					//Flip

					if (h < 0)
					{
						transScale = new Vector3(-1, 1, 1);
					}
					else if (h > 0)
					{
						transScale = new Vector3(1, 1, 1);
					}
					transform.localScale = transScale;


					// Jumping
					if (!gM.isPaused)
					{
						if (isTouchingGround)
						{
							if (Input.GetButtonDown("Jump"))
							{
								rB.AddForce(Vector2.up * 100 * jump);
								FMODUnity.RuntimeManager.PlayOneShot(jumpSound, transform.position);

							}
						}
					}



					//Fall Better
					if (rB.velocity.y < 0)
					{
						rB.velocity += Vector2.up * Time.deltaTime * (fallMult - 1) * Physics2D.gravity.y;
					}
					if (rB.velocity.y > 0 && !Input.GetButton("Jump"))
					{
						rB.velocity += Vector2.up * Time.deltaTime * (jumpMult - 1) * Physics2D.gravity.y;
					}
				}
			}
		}
    }


    


    public void PlayFootstepSound() {
        if (isTouchingGround)
        {
            FMODUnity.RuntimeManager.PlayOneShot(footstepsSound, transform.position);
        }

    }


	public void Hanging(){
		isHanging = true;
		rB.gravityScale = 0;

	}
}
