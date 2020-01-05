using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    Rigidbody2D myRd2d;
    AudioSource myAudi;
    Animator myAni;
    public float HP = 100;
    public float Speed, jumpspeed,HitX,HitY;
    public bool isGround,HaveKey;
    public int Satus;
    public AudioClip Jump,hit,PickUPCoin,PickUPKey;
    public Image HPBAR;
    public GameObject Main;




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
                    myAudi.PlayOneShot(Jump);
                }

                HPBAR.fillAmount = HP / 100;

                if (HP<=0)
                {
                    Satus = 1;
                }

                break;
            case 1: //死亡
                myAni.SetBool("Die", true);
                Main.GetComponent<Main>().Fail();
                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
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
        if (other.name == "DieZone")
        {
            Satus = 1;
        }
    }

    public void GetKey()
    {
        HaveKey = true;
        myAudi.PlayOneShot(PickUPKey);
    }
    public void GetCoin()
    {
        myAudi.PlayOneShot(PickUPCoin);
    }
    public void GetHit()
    {
        if (Satus == 0)
        {
            myAudi.PlayOneShot(hit);
            //this.transform.position = this.transform.position - new Vector3(0.5f, -0.3f);
            myRd2d.AddForce(new Vector2(HitX, HitY));
            HP = HP - 10;
        }
    }

    
}
