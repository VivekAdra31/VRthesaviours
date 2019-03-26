using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherOne : MonoBehaviour
{
    public Transform target;
    public Vector3 pos_origin = new Vector3(0.0f, 0.0f, 0.0f);
    public Vector3 pos_final = new Vector3(1.0f, 0.72f, -0.085f);
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(pos_origin, pos_final, step);
    }
}

