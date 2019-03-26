using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sinking : MonoBehaviour
{

    public float speed_x = 2f;
    public float speed_y = 5f;
    public float speed_z = 1f;

    private float startTime = 0;
    private float x;
    private float y;
    private float z;
    private int count = 0;

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

        //Debug.Log(x);
        //Debug.Log(y);
        //Debug.Log(z);
        //Debug.Log(Time.deltaTime);
        if (count <= 200)
        {
            if (startTime <= 0.08)
            {
                transform.Translate(x, y, z);
            }
            else if (startTime <= 0.16)
            {
                transform.Translate(-x, -y, -z);
            }
            else
            {
                startTime = 0;
            }
            count++;
        }
        else
        {
            SceneManager.LoadScene("Scenes/death");
        }
    }
}
