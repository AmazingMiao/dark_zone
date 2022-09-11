using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public GameObject attackTarget;
    public Transform player;
    Vector3 playerDelayTarget;
    public Transform trs;
    public CharacterController chr;
    public Animator anim;
    Vector3 movement;
    Quaternion lookRotation;
    float lookAtDelay;
    public float speed;
    float G_speed;
    float attackDelay;
    public float attackCD;
    public float lookAtRange;
    public float moveRange;
    public float attackRange;
    float rangeAttackDelay;
    public float rangeAttackCD;
    public GameObject spiderWeb;
    Vector3 spiderWebPos;
    bool targetLocked;
    public float attackDamage;
    public GameObject tinySpider;
    bool tinySpiderSummoned;
    void Start()
    {
        trs = GetComponent<Transform>();
        chr = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Gravity();
        animMovement();
        float distance = Vector3.Distance(trs.position, player.position);
        if (distance < attackRange)
        {
            LookAt();
            if(attackDelay <= 0)
            {
                animAttack();
                attackDelay = attackCD;
            }
        }
        else if(distance < moveRange || targetLocked)
        {
            if(rangeAttackDelay <= 0 && distance > attackRange)
            {
                RangeAttack();
                rangeAttackDelay = rangeAttackCD;
            }
            else if(distance > attackRange)
            {
                Movement();
                LookAt();
            }
            targetLocked = true;
        }
        else if(distance < lookAtRange)
        {
            LookAt();
        }
        else if(health != maxHealth)
        {
            targetLocked = true;
        }
        spiderWebPos = trs.position + new Vector3(0, 1, 1.7f);
        if(health <= maxHealth / 2 && tinySpiderSummoned == false)
        {
            SummonTinySpider();
        }
    }

    private void FixedUpdate()
    {
        attackDelay -= Time.deltaTime;
        rangeAttackDelay -= Time.deltaTime;
    }

    void LookAt()
    {
        playerDelayTarget = Vector3.Lerp(playerDelayTarget, player.position, 5f * Time.deltaTime);
        trs.LookAt(new Vector3(playerDelayTarget.x, trs.position.y, playerDelayTarget.z));
    }

    void Movement()
    {
        movement.z = speed * Time.deltaTime;
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

    void animMovement()
    {
        if(movement.z != 0 || movement.x != 0)
        {
            anim.SetBool("walking", true);
        }
        if(movement.z == 0 || movement.x == 0)
        {
            anim.SetBool("walking", false);
        }
    }

    void animAttack()
    {
        anim.SetTrigger("attack");
    }

    public void Attack()
    {

        attackTarget.GetComponent<PlayerController_CC>().health -= attackDamage;
    }

    void Die()
    {
        anim.SetBool("dead", true);
        anim.SetBool("walking", false);
        anim.SetBool("idle", false);
    }

    void clearBody()
    {
        Destroy(gameObject);
    }

    private void OnTriggerStay(Collider other) 
    {
        if(other.tag == "Player")
        {
            attackTarget = other.gameObject;
        }
    }

    public void DecreaseHp(float h)
    {
        health -= h;
        if(health <= 0)
        {
            Die();
        }
    }

    void RangeAttack()
    {
        Instantiate(spiderWeb, spiderWebPos, trs.rotation);
    }

    void SummonTinySpider()
    {
        Instantiate(tinySpider, trs.position + new Vector3(0, 0, 5), trs.rotation);
        tinySpiderSummoned = true;
    }
}
