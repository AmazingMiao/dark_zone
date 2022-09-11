using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Transform trs;
    public int destroyCountdown;
    public float bulletSpeed;
    void Start()
    {
        trs = GetComponent<Transform>();
    }

    void Update()
    {
        if(destroyCountdown > 300)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        destroyCountdown++;
        trs.Translate(new Vector3(-bulletSpeed * Time.deltaTime, 0, 0), Space.Self);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<SpiderController>().DecreaseHp(1);;
            Destroy(gameObject);
        }
    }
}
