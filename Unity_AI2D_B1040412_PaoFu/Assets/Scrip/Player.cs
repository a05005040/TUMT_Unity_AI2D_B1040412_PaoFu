using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D myRd2d;
    AudioSource myAudi;
    Animator myAni;
    public int HP = 100;
    public float Speed, jumpspeed;
    public bool isGround;
    public int Satus;



    // Start is called before the first frame update
    void Start()
    {
        myRd2d = GetComponent<Rigidbody2D>();
        myAudi = GetComponent<AudioSource>();
        myAni = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (Satus)
        {
            case 0: //進行
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    Turn();
                }
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    Turn(180);
                }

                if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
                {
                    isGround = false;
                    myRd2d.AddForce(new Vector2(0, jumpspeed));
                }

                break;
            case 1:
                break;
        }

    }

    private void FixedUpdate()
    {
        if (Satus==0)
        {
            Walk();
        }
        
    }

    public void Walk()
    {
        if (myRd2d.velocity.magnitude < 10)
        {
            myRd2d.AddForce(new Vector2(Speed * Input.GetAxisRaw("Horizontal"), 0));
            myAni.SetBool("isWalk", Input.GetAxisRaw("Horizontal") != 0);
        }
            
    }
    private void Turn(int direction = 0)
    {
        transform.eulerAngles = new Vector3(0, direction, 0);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "GROUND")
        {
            isGround = true;
        }
    }
}
