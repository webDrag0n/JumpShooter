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

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        Rigidbody2D rig = collision.gameObject.GetComponent<Rigidbody2D>();
        rig.AddForce(gameObject.transform.right * accelerate_force);
    }
    
}
