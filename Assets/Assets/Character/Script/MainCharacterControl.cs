using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterControl : MonoBehaviour
{

    private states character_state;
    private enum states
    {
        idle,
        walking,
        runing,
        jumping
    };

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void LateUpdate()
    {
        // decide character's next state at the end of a frame to look smoother

        character_state = states.idle;

        if (Input.GetKey(KeyCode.D))
        {
            character_state = states.walking;
            
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
                break;
            case states.walking:
                animator.SetInteger("state_number", 1);
                break;
            case states.runing:
                animator.SetInteger("state_number", 2);
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
