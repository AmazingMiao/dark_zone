using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITrappedController : MonoBehaviour
{
    public Text txt;
    public PlayerController_CC playerStats;

    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerStats.frozen == true)
        {
            txt.enabled = true;
        }
        else
        {
            txt.enabled = false;
        }
    }
}
