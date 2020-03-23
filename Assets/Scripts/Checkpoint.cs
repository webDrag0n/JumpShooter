using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Material triggered;
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        PlayerPrefs.DeleteAll();
#endif
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetFloat("pos_x", gameObject.transform.position.x);
        PlayerPrefs.SetFloat("pos_y", gameObject.transform.position.y);
        gameObject.GetComponent<MeshRenderer>().material = triggered;
    }

}
