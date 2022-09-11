using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTextController : MonoBehaviour
{
    public Text txt;
    public PlayerController_CC player;
    public SpiderController enemy;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.health >= 0 && enemy.health <= 0)
        {
            txt.enabled = true;
        }
        else
        {
            txt.enabled = false;
        }
    }
}