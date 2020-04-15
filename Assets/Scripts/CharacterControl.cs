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

#if UNITY_EDITOR
        PlayerPrefs.DeleteAll();
#endif
        PlayerPrefs.DeleteAll();


        start_pos = gameObject.transform.position;

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
            PlayerPrefs.SetInt("player_dead", 0);
            float pos_x = PlayerPrefs.GetFloat("pos_x", start_pos.x);
            float pos_y = PlayerPrefs.GetFloat("pos_y", start_pos.y);
            gameObject.transform.position = new Vector3(pos_x, pos_y, 0);
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        // disable all input after dead
        // this need to be after R action to allow player respawn after dead
        
        if (PlayerPrefs.GetInt("player_dead") == 0)
        {
            if (Input.GetKey(KeyCode.A))
            {
                gameObject.GetComponent<Rigidbody2D>().AddTorque(gameObject.GetComponent<Rigidbody2D>().mass * speed);
            }

            if (Input.GetKey(KeyCode.D))
            {
                gameObject.GetComponent<Rigidbody2D>().AddTorque(-gameObject.GetComponent<Rigidbody2D>().mass * speed);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(jump_vector);
            }
        }

        
    }
}
