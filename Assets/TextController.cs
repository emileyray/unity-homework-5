using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public AnimationStateController asc;
    private TextMeshProUGUI tmp;
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        float velocityX = asc.getVelocityX();
        float velocityZ = asc.getVelocityZ();
        
        float velocity = Mathf.Sqrt(velocityX * velocityX + velocityZ * velocityZ);
        tmp.text = "velocity: " + String.Format("{0:0.00}", velocity);  
    }
}
