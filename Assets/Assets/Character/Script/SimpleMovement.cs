using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(0.06f * (0.7f + 0.3f * Mathf.Sin(Time.time * 10)), 0, 0);
        transform.position += new Vector3(0.045f, 0, 0);
    }
}
