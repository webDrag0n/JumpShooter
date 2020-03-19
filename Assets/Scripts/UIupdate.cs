using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIupdate : MonoBehaviour
{
    public GameObject character;

    public GameObject height_label;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        height_label.GetComponent<TextMeshProUGUI>().text = "Height: " + Mathf.RoundToInt(character.transform.position.y);
    }
}
