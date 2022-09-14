using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Transform trs;
    public SphereCollider CrouchColl;
    public CapsuleCollider StandColl;
    public float speed;
    public float jumpforce;
    public bool isOnGround;
    public bool isCrouching;
    public bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        trs = GetComponent<Transform>();
        CrouchColl = GetComponent<SphereCollider>();
        StandColl = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Crouch();
        StandUp();
        Movement();
    }

    void FixedUpdate() 
    {
        Jump();    
    }

    void Movement()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, Input.GetAxis("Vertical") * speed );
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y, rb.velocity.z);
        //transform.Translate(new Vector3(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime), Space.Self);
        //transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0), Space.Self);
    }

    void Jump()
    {
        if(Input.GetKey(KeyCode.Space) && isOnGround == true)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpforce, rb.velocity.z);
            isJumping = true;
        }
    }
    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && isOnGround == true && isCrouching == false)
        {
            CrouchColl.enabled = true;
            StandColl.enabled = false;
            isCrouching = true;
            Debug.Log("Crouch");
        }
    }

    void StandUp()
    {
        if (Input.GetKeyUp(KeyCode.LeftControl) && isOnGround == true && isCrouching == true)
        {
            CrouchColl.enabled = false;
            StandColl.enabled = true;
            isCrouching = false;
            Debug.Log("Stand up");
        }
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Ground")
        {
            isOnGround = true;
            isJumping = false;
        }
    }

    private void OnCollisionExit(Collision other) 
    {
        if(other.gameObject.tag == "Ground")
        {
            isOnGround = false;
        }
    }
}
