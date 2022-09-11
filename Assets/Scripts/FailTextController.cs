using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailTextController : MonoBehaviour
{
    public Text txt;
    public PlayerController_CC player;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.health <= 0)
        {
            txt.enabled = true;
        }
        else
        {
            txt.enabled = false;
        }
    }
}
