using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ad : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.left;
        if (transform.position.x <= -30f)
            transform.position = new Vector3(25, transform.position.y, transform.position.z);
    }
}
