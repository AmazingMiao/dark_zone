using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiderHealthBarController : MonoBehaviour
{
    public Image img;
    public SpiderController chr;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        img.fillAmount = chr.health / chr.maxHealth;
    }
}
