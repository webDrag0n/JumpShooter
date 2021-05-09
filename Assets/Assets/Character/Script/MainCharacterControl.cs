using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterControl : MonoBehaviour
{
    // use velocity vector to control movement
    // therefore manual friction could be applied
    private Vector3 velocity;

    private states character_state;
    private enum states
    {
        idle,
        walking,
        runing,
        jumping
    };

    private direction facing_towards;
    private enum direction
    {
        right,
        left
    }

    private Animator animator;
    private int speed_hash;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        // init velocity
        velocity = Vector3.zero;
        speed_hash = animator.GetFloat("speed").GetHashCode();
    }
    private void LateUpdate()
    {
        // decide character's next state at the end of a frame to look smoother

        character_state = states.idle;

        if (Input.GetKey(KeyCode.D))
        {
            character_state = states.walking;
            if (facing_towards == direction.left)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                facing_towards = direction.right;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            character_state = states.walking;
            if (facing_towards == direction.right)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                facing_towards = direction.left;
            }
        }

        // in another words, walking and running
        if (Input.GetKey(KeyCode.LeftShift) && character_state != states.idle)
        {
            character_state = states.runing;

            animator.SetInteger("state_number", 2);
        }

        animator.SetBool("is_jump", false);
        if (Input.GetKey(KeyCode.Space) && character_state != states.jumping)
        {
            character_state = states.jumping;

            animator.SetBool("is_jump", true);
        }


        switch (character_state)
        {
            case states.idle:
                // walk 1, run 2, idle 0, jump -1 trigger
                animator.SetInteger("state_number", 0);
                if (velocity.x < 0.1f)
                {
                    velocity = Vector3.zero;
                } else
                {
                    velocity = Vector3.Lerp(velocity, new Vector3(0, 0, 0), 13 * Time.deltaTime);
                }
                break;
            case states.walking:
                animator.SetInteger("state_number", 1);
                velocity = Vector3.Lerp(velocity, new Vector3(1, 0, 0), 5 * Time.deltaTime);
                break;
            case states.runing:
                animator.SetInteger("state_number", 2);
                velocity = Vector3.Lerp(velocity, new Vector3(2, 0, 0), 5 * Time.deltaTime);
                break;
        }
        animator.SetFloat("speed", velocity.x);
    }

    private void FixedUpdate()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
