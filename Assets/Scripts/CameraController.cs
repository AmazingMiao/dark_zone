using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float CameraY;
    public float CameraX;
    public Transform PlayerTrs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = new Vector3(transform.rotation.x, Input.GetAxis("Mouse X"), transform.rotation.z);
        CameraX -= Input.GetAxis("Mouse Y");
        CameraY += Input.GetAxis("Mouse X");
        transform.rotation = Quaternion.Euler(Mathf.Clamp(CameraX, -90, 90), CameraY, transform.rotation.z);
        PlayerTrs.rotation = Quaternion.Euler(PlayerTrs.rotation.x, CameraY, PlayerTrs.rotation.z);
    }
}
