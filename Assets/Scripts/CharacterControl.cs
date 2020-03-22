using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public float speed;
    public Vector3 jump_vector;

    private Vector3 start_pos;

    // Start is called before the first frame update
    void Start()
    {
        start_pos = gameObject.transform.position;
#if UNITY_EDITOR
        PlayerPrefs.DeleteAll();
#endif
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        // reload checkpoint
        if (Input.GetKey(KeyCode.R))
        {
            float pos_x = PlayerPrefs.GetFloat("pos_x", start_pos.x);
            float pos_y = PlayerPrefs.GetFloat("pos_y", start_pos.y);
            gameObject.transform.position = new Vector3(pos_x, pos_y, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(0, 0, gameObject.GetComponent<Rigidbody>().mass * speed));
        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(0, 0, -gameObject.GetComponent<Rigidbody>().mass * speed));
        }

        if (Input.GetKey(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(jump_vector);
        }
    }
}
