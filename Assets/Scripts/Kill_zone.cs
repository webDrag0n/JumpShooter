using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill_zone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("player_dead", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerPrefs.SetInt("player_dead", 1);
    }
}
