using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebControllerWithG : MonoBehaviour
{
    public Rigidbody rb;
    public Transform trs;
    public Transform playerTrs;
    public Vector3 displacement;
    public GameObject spider;
    public float rangeAttackDamage;
    public float freezeTime;
    public float gravity;
    public float distance;
    public float trajectoryTime;
    // Start is called before the first frame update
    void Start()
    {
        //Fixed the Bug by initialing Player Transform below
        playerTrs = GameObject.Find("Player").GetComponent<Transform>().transform;


        rb = GetComponent<Rigidbody>();
        trs.position = spider.transform.position + new Vector3(0, 1, 1.7f);
        distance = playerTrs.position.z - trs.position.z;
    } 

    // Update is called once per frame
    void Update()
    {
       // return;
        if(Vector3.Distance(trs.position, playerTrs.position) > 500)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        //return;
        //distance = Vector3.Distance(trs.position, playerTrs.position);

        gravity -= 9.81f * Time.fixedDeltaTime;
        displacement.x = 0f;
        displacement.z = distance / (trajectoryTime);
        displacement.y = trajectoryTime * 9.81f / 2 + gravity;
        rb.velocity = displacement;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerController_CC>().health -= rangeAttackDamage;
            other.GetComponent<PlayerController_CC>().freezeTime = freezeTime;
        }
    }
}