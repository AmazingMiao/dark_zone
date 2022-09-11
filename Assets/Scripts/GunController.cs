using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform trs;
    public Transform camTrs;
    public Vector3 bulletSpawnPos;
    public GameObject bullet;
    void Start()
    {
        trs = GetComponent<Transform>();
        camTrs = GetComponent<Transform>();
    }

    void Update()
    {
        bulletSpawnPos = trs.position + new Vector3(-0.054f, 0.0406f, 0);
        Shoot();
    }

    void Shoot()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, bulletSpawnPos, camTrs.rotation);
        }
    }
}
