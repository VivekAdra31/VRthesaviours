using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class Example : MonoBehaviour
{

    public Transform target;
    public Vector3 pos_origin= new Vector3(0.0f, 0.72f, 0.0f);
    public Vector3 pos_final = new Vector3(-0.308f, 0.72f, -0.085f);
    public float speed = 1.0f;
    void Start()
    {

    }



    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(pos_origin, pos_final, step);
    }

   
}