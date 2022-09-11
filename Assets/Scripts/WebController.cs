using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebController : MonoBehaviour
{
    public Rigidbody rb;
    public Transform trs;
    public Transform playerTrs;
    public float releaseForce;
    public Vector3 direction;
    public float rangeAttackDamage;
    public float freezeTime;
    // Start is called before the first frame update
    void Start()
    {
        // rb = GetComponent<Rigidbody>();
        // releaseForce = Mathf.Sqrt((Vector3.Distance(trs.position, playerTrs.position)) * 9.81f);
        // Debug.Log(releaseForce);
        // direction = trs.TransformDirection(0, releaseForce / Mathf.Sqrt(2), releaseForce / Mathf.Sqrt(2));
        // rb.velocity = direction;
        direction = trs.TransformDirection(0, 0, 10);
        rb.velocity = direction;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(trs.position, playerTrs.position) > 500)
        {
            Destroy(gameObject);
        }
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
