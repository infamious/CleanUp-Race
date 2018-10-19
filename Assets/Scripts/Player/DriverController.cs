using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverController : MonoBehaviour
{
    public float xspeep = 0f;
    public float power = 0.001f;
    public float friction = 0.95f;
    public bool right = false;
    public bool left = false;

    public float fuel = 2;


    // Use this for initialization
    void FixedUpdate()
    {


        if (right)
        {
            xspeep += power;
            fuel -= power;
        }
        if (left)
        {
            xspeep -= power;
            fuel -= power;
        }


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("z"))
        {
            right = true;
        }
        if (Input.GetKeyUp("z"))
        {
            right = false;
        }
        if (Input.GetKeyDown("s"))
        {
            left = true;
        }
        if (Input.GetKeyUp("s"))
        {
            left = false;
        }

        if (fuel < 0)
        {

            xspeep = 0;

        }

        xspeep *= friction;
        transform.Translate(Vector3.right * -xspeep);

    }
}

