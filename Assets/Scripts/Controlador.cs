using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Controlador : MonoBehaviour
{
    public TMP_Text timer;
    public GameObject pregunta;
    public float targetTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
        timer.text = String.Format("{0:0}", targetTime);
        
        if (targetTime <= 0)
        {
            timer.text = "0";
        }
    }
}
