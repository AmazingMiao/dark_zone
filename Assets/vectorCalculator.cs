using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vectorCalculator : MonoBehaviour
{
    public Vector3 a;
    public Vector3 b;
    public Vector3 c;
    // Start is called before the first frame update
    void Start()
    {
        c = Vector3.Cross(a, b);
        Debug.Log(c);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
