 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerate : MonoBehaviour
{
    public float accelerate_force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(-Time.time * 1f, 0f));
    }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rig = other.gameObject.GetComponent<Rigidbody>();
        rig.AddForce(-gameObject.transform.right * accelerate_force);
    }
}
