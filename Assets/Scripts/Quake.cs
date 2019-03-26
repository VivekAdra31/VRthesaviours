using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quake : MonoBehaviour
{
    public float speed_x = 2f;
    public float speed_y = 5f;
    public float speed_z = 1f;

    private float startTime = 0;
    private float x;
    private float y;
    private float z;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        x = speed_x * Time.deltaTime;
        y = speed_y * Time.deltaTime;
        z = speed_z * Time.deltaTime;
        startTime += Time.deltaTime;

        if (startTime <= 0.08)
        {

            transform.Translate(x, y, z);
        }
        else if (startTime <= 0.135)
        {
            transform.Translate(-x, -y, -z);
        }
        else
        {
            startTime = 0;
        }
    }

}
