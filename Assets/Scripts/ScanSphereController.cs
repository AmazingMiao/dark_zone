using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanSphereController : MonoBehaviour
{
    public Transform trs;
    public Transform plTrs;
    public bool scanning;
    public bool scanCompleted;
    public bool retracting;
    void Start()
    {
        trs = GetComponent<Transform>();
        plTrs = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            scanning = true;
        }
        Scan();
        Retract();
        trs.position = plTrs.position;
    }

    void Scan()
    {
        if(scanning == true)
        {
            trs.localScale += new Vector3(1f * Mathf.Sqrt(trs.localScale.x), 1f * Mathf.Sqrt(trs.localScale.y), 1f * Mathf.Sqrt(trs.localScale.z));
            if(trs.localScale.x > 1500)
            {
                retracting = true;
                scanning = false;
                scanCompleted = true;
            }
        }
    }

    void Retract()
    {
        if(retracting == true)
        {
            //trs.localScale -= new Vector3(1f * Mathf.Pow(2, trs.localScale.x), 1f * Mathf.Pow(2, trs.localScale.y), 1f * Mathf.Pow(2, trs.localScale.z));
            trs.localScale -= new Vector3(20f, 20f, 20f);
            if(trs.localScale.x < 200)
            {
                retracting = false;
            }
        }
    }
}
