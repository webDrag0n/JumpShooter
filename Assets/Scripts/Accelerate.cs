 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rig = other.gameObject.GetComponent<Rigidbody>();
        rig.AddForce(gameObject.transform.right * rig.mass / 100);
    }
}
