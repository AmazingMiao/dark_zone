using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_CC : MonoBehaviour
{
    public CharacterController chr;
    public Transform trs;
    public GameObject scanSphere;
    public float speed;
    public float crouchingSpeed;
    public float standingSpeed;
    public float jumpforce;
    public float G_speed;
    public int scanSphereCount;
    public Vector3 movement;
    public Vector3 collCenter;
    public bool isCrouching;
    public bool isJumping;
    public float health;
    public float maxHealth;
    public float freezeTime;
    public bool frozen;
    float realSpeed;
    // Start is called before the first frame update
    void Start()
    {
        chr = GetComponent<CharacterController>();
        trs = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Crouch();
        StandUp();
        //Scan();
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate() 
    {
        //Jump();
        Movement();
        Gravity();
        Freeze();
    }

    void Movement()
    {
        if(frozen == true)
        {
            realSpeed = speed / 10;
        }
        else
        {
            realSpeed = speed;
        }
        movement.z = Input.GetAxis("Vertical") * realSpeed * Time.deltaTime;
        movement.x = Input.GetAxis("Horizontal") * realSpeed * Time.deltaTime;
        movement = trs.TransformDirection(movement);
        chr.Move(movement);
    }

    void Gravity()
    {
        if(!chr.isGrounded)
        {
            G_speed += -9.8f * 5 * Time.deltaTime;
            if(G_speed < -10f)
            {
                G_speed = -10f;
            }
        }
        else
        {
            G_speed = 0;
        }
        movement.y = G_speed;
        movement *= Time.deltaTime;
        chr.Move(movement);
    }

    void Jump()
    {
       
    }
    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            collCenter = chr.center;
            collCenter.y = 0.5f;
            chr.center = collCenter;
            chr.height = 1;
            speed = crouchingSpeed;
            isCrouching = true;
            Debug.Log("Crouch");
        }
    }

    void StandUp()
    {
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            collCenter = chr.center;
            collCenter.y = 0f;
            chr.center = collCenter;
            chr.height = 2;
            speed = standingSpeed;
            isCrouching = false;
            Debug.Log("Stand up");
        }
    }

    void Scan()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            scanSphereCount++;
            Instantiate(scanSphere, trs.position, new Quaternion(90, 0, 0, 0));
        }
    }

    void Freeze()
    {
        freezeTime -= Time.deltaTime;
        if(freezeTime > 0)
        {
            frozen = true;
        }
        else
        {
            frozen = false;
        }
    }
}

